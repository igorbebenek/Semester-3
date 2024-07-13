// SO IS1 224A LAB08
// Igor Bębenek 
// bi53940@zut.edu.pl
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <sys/wait.h>

int main(int argc, char **argv) {
    if (argc != 2 || strlen(argv[1]) > 25 || strlen(argv[1]) < 1) {
        fprintf(stderr, "Błąd: Nieprawidłowa liczba argumentów lub długość argumentu\n");
        return 1;
    }

    for (int i = 0; argv[1][i]; i++) {
        if (!isdigit(argv[1][i])) {
            fprintf(stderr, "Błąd: Argument zawiera niedozwolone znaki\n");
            return 1;
        }
    }

    if (strlen(argv[1]) == 1) {
        return argv[1][0] - '0';
    }

    int length = strlen(argv[1]);
    int mid = length / 2;
    char a[mid + 1];
    char b[length - mid + 1];

    strncpy(a, argv[1], mid);
    a[mid] = '\0';

    strncpy(b, argv[1] + mid, length - mid);
    b[length - mid] = '\0';

    int p1 = fork();

    if (p1 == 0) {

        execl("./lab8", "lab8", a, NULL);
    } else {
        int p2 = fork();

        if (p2 == 0) {
            execl("./lab8", "lab8", b, NULL);
        } else {

            int status1, status2;
            int child1 = waitpid(p1, &status1, 0);
            int child2 = waitpid(p2, &status2, 0);

            printf("Parent: %d, Child: %d, Arg: %s, Exit code: %d\n", getpid(), child1, a, WEXITSTATUS(status1));
            printf("Parent: %d, Child: %d, Arg: %s, Exit code: %d\n", getpid(), child2, b, WEXITSTATUS(status2));

            return WEXITSTATUS(status1) + WEXITSTATUS(status2);
        }
    }

    return 0;
}