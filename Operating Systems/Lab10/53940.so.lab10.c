// SO IS1 224A LAB10
// Igor Bębenek 
// bi53940@zut.edu.pl
#include <pthread.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long double suma_globalna = 0.0;
pthread_mutex_t mutex;

long double oblicz_wyraz_ciagu(int k) {
    long double licznik = 4.0;
    long double mianownik = (2 * k + 2) * (2 * k + 3) * (2 * k + 4);
    return mianownik == 0 ? 0 : licznik * (k % 2 == 0 ? 1 : -1) / mianownik;
}

void *funkcja_watku(void *arg) {
    int *data = (int *)arg;
    int start = data[0];
    int koniec = data[1];
    long double suma = 0.0;

    printf("Wątek %lx rozmiar=%d pierwszy==%d\n", (unsigned long)pthread_self(), koniec - start, start);

    for (int i = start; i < koniec; ++i) {
        suma += oblicz_wyraz_ciagu(i);
    }

    printf("Wątek %lx suma=%.20Lf\n", (unsigned long)pthread_self(), suma);

    pthread_mutex_lock(&mutex);
    suma_globalna += suma;
    pthread_mutex_unlock(&mutex);

    free(arg);
    return NULL;
}

int main(int argc, char *argv[]) {
    if (argc != 3) {
        fprintf(stderr, "Sposób użycia: %s <n> <w>\n", argv[0]);
        return 1;
    }

    int n = atoi(argv[1]);
    int w = atoi(argv[2]);
    if (n <= 1 || n >= 1000000 || w <= 1 || w >= (n < 100 ? n : 100)) {
        fprintf(stderr, "Nieprawidłowe argumenty.\n");
        return 1;
    }

    pthread_t watki[w];
    pthread_mutex_init(&mutex, NULL);

    struct timespec czas_poczatkowy, czas_koncowy;
    clock_gettime(CLOCK_MONOTONIC, &czas_poczatkowy);

    int zakres = n / w;
    for (int i = 0; i < w; ++i) {
        int *data = malloc(2 * sizeof(int));
        data[0] = i * zakres;
        data[1] = (i == w - 1) ? n : (i + 1) * zakres;
        pthread_create(&watki[i], NULL, funkcja_watku, data);
    }

    for (int i = 0; i < w; ++i) {
        pthread_join(watki[i], NULL);
    }

    clock_gettime(CLOCK_MONOTONIC, &czas_koncowy);
    double czas_wykonania = czas_koncowy.tv_sec - czas_poczatkowy.tv_sec +
                            (czas_koncowy.tv_nsec - czas_poczatkowy.tv_nsec) / 1000000000.0;

    printf("PI z wątkami=%.20Lf czas=%.6f\n", 3.0 + suma_globalna, czas_wykonania);

    long double suma = 0.0;
    clock_gettime(CLOCK_MONOTONIC, &czas_poczatkowy);
    for (int i = 0; i < n; ++i) {
        suma += oblicz_wyraz_ciagu(i);
    }
    clock_gettime(CLOCK_MONOTONIC, &czas_koncowy);
    czas_wykonania = czas_koncowy.tv_sec - czas_poczatkowy.tv_sec +
                     (czas_koncowy.tv_nsec - czas_poczatkowy.tv_nsec) / 1000000000.0;

    printf("PI bez wątków=%.20Lf czas=%.6f\n", 3.0 + suma, czas_wykonania);

    pthread_mutex_destroy(&mutex);
    return 0;
}