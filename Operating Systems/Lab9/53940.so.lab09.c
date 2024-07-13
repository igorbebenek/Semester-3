// SO IS1 224A LAB09
// Igor Bębenek
// bi53940@zut.edu.pl
#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <windows.h>

int main(int argc, char *argv[]) {
    if (argc != 2) {
        fprintf(stderr, "Błąd: nieprawidłowa liczba argumentów\n");
        return 1;
    }

    int length = strlen(argv[1]);
    if (length == 0 || length > 25) {
        fprintf(stderr, "Błąd: nieprawidłowa długość argumentu\n");
        return 1;
    }

    for (int i = 0; i < length; i++) {
        if (!isdigit(argv[1][i])) {
            fprintf(stderr, "Błąd: argument zawiera niecyfrowe znaki\n");
            return 1;
        }
    }

    if (length == 1) {
        return argv[1][0] - '0';
    }

    int half = length / 2;
    char firstHalf[half + 1];
    char secondHalf[length - half + 1];

    strncpy(firstHalf, argv[1], half);
    firstHalf[half] = '\0';
    strcpy(secondHalf, argv[1] + half);

    STARTUPINFOA si;
    PROCESS_INFORMATION pi;
    PROCESS_INFORMATION pi2;
    ZeroMemory(&si, sizeof(si));
    ZeroMemory(&pi, sizeof(pi));
    ZeroMemory(&pi2, sizeof(pi2));
    si.cb = sizeof(si);

    char progPath[MAX_PATH];
    GetModuleFileNameA(NULL, progPath, MAX_PATH);

    char prog1[40 + MAX_PATH];
    snprintf(prog1, sizeof(prog1), "%s %s", progPath, firstHalf);

    char prog2[40 + MAX_PATH];
    snprintf(prog2, sizeof(prog2), "%s %s", progPath, secondHalf);


    if (!CreateProcessA(NULL, prog1, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi)) {
        fprintf(stderr, "Nie udalo sie utworzyc procesu 1: %d\n", GetLastError());
        return 1;
    }

    if (!CreateProcessA(NULL, prog2, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi2)) {
        fprintf(stderr, "Nie udalo sie utworzyc procesu 2: %d\n", GetLastError());
        return 1;
    }

    WaitForSingleObject(pi.hProcess, INFINITE);
    WaitForSingleObject(pi2.hProcess, INFINITE);

    DWORD status1, status2;
    GetExitCodeProcess(pi.hProcess, &status1);
    GetExitCodeProcess(pi2.hProcess, &status2);

    printf("Rodzic: %d Dziecko: %d %s %d\n", GetCurrentProcessId(), pi.dwProcessId, firstHalf, status1);
    printf("Rodzic: %d Dziecko: %d %s %d\n", GetCurrentProcessId(), pi2.dwProcessId, secondHalf, status2);

    CloseHandle(pi.hProcess);
    CloseHandle(pi.hThread);
    CloseHandle(pi2.hProcess);
    CloseHandle(pi2.hThread);

    return status1 + status2;
}
