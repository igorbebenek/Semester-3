// SO IS1 224A LAB11
// Igor Bębenek 
// bi53940@zut.edu.pl
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
HANDLE mutex;
float *t;
float suma_globalna = 0.0;

typedef struct {
    int start;
    int koniec;
    float suma;
    unsigned long idWatku;
} DaneWatku;

DWORD WINAPI funkcjaWatku(LPVOID arg) {
DaneWatku *dane = (DaneWatku *)arg;
dane->idWatku = GetCurrentThreadId();
dane->suma = 0.0;

printf("Watek #%lu rozmiar=%d\n", dane->idWatku, dane->koniec - dane->start);

for (int i = dane->start; i < dane->koniec; ++i) {
dane->suma += t[i];
}

WaitForSingleObject(mutex, INFINITE);
suma_globalna += dane->suma;
ReleaseMutex(mutex);

return 0;
}

int main(int argc, char *argv[]) {
    if (argc != 3) {
        fprintf(stderr, "Uzycie: %s <n> <w>\n", argv[0]);
        return 1;
    }

    int n = atoi(argv[1]);
    int w = atoi(argv[2]);
    if (n <= 0 || n >= 1000000 || w <= 0 || w >= n) {
        fprintf(stderr, "Nieprawidlowe argumenty.\n");
        return 1;
    }

    t = (float *)malloc(n * sizeof(float));
    srand(0);
    for (int i = 0; i < n; i++) {
        t[i] = 1000.0f * rand() / RAND_MAX;
    }

    mutex = CreateMutex(NULL, FALSE, NULL);
    DaneWatku *daneWatku = malloc(w * sizeof(DaneWatku));
    HANDLE *watki = malloc(w * sizeof(HANDLE));

    LARGE_INTEGER czestotliwosc, start, koniec;
    QueryPerformanceFrequency(&czestotliwosc);

    QueryPerformanceCounter(&start);
    int zakres = n / w;
    for (int i = 0; i < w; ++i) {
        daneWatku[i].start = i * zakres;
        daneWatku[i].koniec = (i == w - 1) ? n : (i + 1) * zakres;
        watki[i] = CreateThread(NULL, 0, funkcjaWatku, &daneWatku[i], 0, NULL);
    }

    for (int i = 0; i < w; ++i) {
        WaitForSingleObject(watki[i], INFINITE);
        printf("Watek #%lu suma=%.9f\n", daneWatku[i].idWatku, daneWatku[i].suma);
        CloseHandle(watki[i]);
    }

    QueryPerformanceCounter(&koniec);
    double czas_watkow = (double)(koniec.QuadPart - start.QuadPart) / czestotliwosc.QuadPart;
    printf("z/Watkami: suma=%.9f, czas=%.6lfsek\n", suma_globalna, czas_watkow);

    suma_globalna = 0.0;
    QueryPerformanceCounter(&start);
    for (int i = 0; i < n; ++i) {
        suma_globalna += t[i];
    }
    QueryPerformanceCounter(&koniec);
    double czas_bez_watkow = (double)(koniec.QuadPart - start.QuadPart) / czestotliwosc.QuadPart;
    printf("bez/Watkow: suma=%.9f, czas=%.6lfsek\n", suma_globalna, czas_bez_watkow);

    printf("%.9f\n", suma_globalna);

    CloseHandle(mutex);
    free(t);
    free(watki);
    free(daneWatku);
    return 0;
}