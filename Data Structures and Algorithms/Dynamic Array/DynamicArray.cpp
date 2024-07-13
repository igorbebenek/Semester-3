//ALGO2 IS1 224A LAB02
// Igor Bêbenek
// bi53940@zut.edu.pl
#include <iostream>
#include "time.h"
#include <sstream>
#include <cmath>
#include <algorithm>

using namespace std;

template <typename T>
class TablicaDynamiczna 
{
private:
	T* tablica;  // wskaŸnik do dynamicznie alokowanej tablicy

public:
	int pojemnosc;  // aktualna pojemnoœæ tablicy
	unsigned int rozmiar = 0;  // aktualny rozmiar tablicy

	// Konstruktor domyœlny
	TablicaDynamiczna() 
	{
		pojemnosc = 10;
		rozmiar = 0;
		tablica = new T[pojemnosc];  // alokacja pamiêci na pocz¹tkowe 10 elementów
	}

	//  a dodawanie elementu na koñcu tablicy
	void DodajNaKoniec(const T& dane) 
	{
		if (rozmiar < pojemnosc) 
		{
			tablica[rozmiar++] = dane;
		}
		else 
		{
			// Jeœli tablica jest pe³na, zwiêksz jej pojemnoœæ
			pojemnosc *= 2;
			T* tempTablica = new T[pojemnosc];

			// Kopiowanie elementów ze starej do nowej tablicy
			for (int i = 0; i < rozmiar; ++i) 
			{
				tempTablica[i] = tablica[i];
			}

			// Zast¹pienie starej tablicy now¹ i dodanie elementu
			delete[] tablica;
			tablica = tempTablica;
			tablica[rozmiar] = dane;
			++rozmiar;
		}

	}

	// b zwraca i-ty element tablicy
	T& get(int n) 
	{
		if (n < rozmiar && n >= 0) 
		{
			return tablica[n];
		}
		else throw "brak elementu";
	}

	// c ustawia wartoœæ i-tego elementu tablicy
	void UstawIty(int n, const T& dane) 
	{
		if (n < rozmiar && n >= 0) {
			tablica[n] = dane;
		}
		else throw "brak elementu";
	}

	// d usuwa zawartoœæ tablicy
	void Usun() 
	{
		delete[] tablica;
		tablica = NULL;
		rozmiar = 0;
		pojemnosc = 0;
	}

	//  e wyœwietla zawartoœæ tablicy
	void WyswietlZawartosc() const 
	{
		for (int i = 0; i < rozmiar; i++) {
			cout << tablica[i] << " ";
		}
		cout << endl;
	}

	//  f sortuje tablicê metod¹ b¹belkow¹
	void SortowanieBabelkowe() 
	{
		for (int i = 0; i < rozmiar - 1; i++) 
		{
			for (int j = 0; j < rozmiar - i - 1; j++) 
			{
				if (tablica[j + 1] < tablica[j]) 
				{
					swap(tablica[j], tablica[j + 1]);
				}
			}
		}
	}

	// Destruktor klasy - zwalnia zaalokowan¹ pamiêæ
	~TablicaDynamiczna() 
	{
		delete[] tablica;
	}
};

// Struktura przyk³adowa do przechowywania w tablicy
struct PewienObiekt 
{
	int pole1;
	char pole2;
};

// Operator wyjœcia dla struktury
std::ostream& operator<<(std::ostream& out, const PewienObiekt& o) 
{
	out << o.pole1 << " " << o.pole2;
	return out;
}

// Operator porównania dla struktury
bool operator <(const PewienObiekt& a, const PewienObiekt& b) 
{
	return a.pole1 < b.pole1 || (a.pole1 == b.pole1 && a.pole2 < b.pole2);
}

int main() 
{
	//// Tworzenie dynamicznej tablicy zdolnej do przechowywania wskaŸników do obiektów typu PewienObiekt

	TablicaDynamiczna<PewienObiekt*>* da = new TablicaDynamiczna<PewienObiekt*>();
	// Sta³a okreœlaj¹ca rz¹d wielkoœci iloœci elementów w tablicy
	const int rzad = 7;
	// Obliczenie ca³kowitej liczby elementów (10 podniesione do potêgi okreœlonej przez wartoœæ zmiennej rzad)
	const int n = pow(10, rzad);

	// Pomiar czasu dodawania elementów
	clock_t t1 = clock();
	double maksCzasNaElement = 0.0;
	int maksCzasIndeks = -1;

	// Dodawanie n losowych obiektów do tablicy
	int i = 0;
	while (i < n) {
		PewienObiekt* so = new PewienObiekt{ rand() % 20, static_cast<char>('a' + rand() % 26) }; // Pole1 otrzymuje losow¹ wartoœæ od 0 do 19, a pole2 losow¹ literê z zakresu 'a' do 'z'.
		clock_t t1_element = clock();
		da->DodajNaKoniec(so);
		clock_t t2_element = clock();

		// Pomiar czasu dla ka¿dego dodanego elementu
		double time_per_element = static_cast<double>(t2_element - t1_element);
		if (time_per_element > maksCzasNaElement) {
			maksCzasNaElement = time_per_element;
			maksCzasIndeks = i;
			cout << " Maks czas " << maksCzasNaElement << "s przy indeksie " << maksCzasIndeks << endl;
		}

		i++;
	}

	//Pobieranie bie¿¹cego czasu procesora dla punktu koñcowego pomiaru
	clock_t t2 = clock();
	// Obliczanie ca³kowitego czasu trwania operacji w sekundach
	double pelnyCzas = static_cast<double>(t2 - t1) / CLOCKS_PER_SEC;
	// Obliczanie œredniego czasu jednej operacji 
	double sredniCzas = pelnyCzas / n;

	// Wyœwietlanie pierwszych 10 elementów tablicy
	for (int i = 0; i < min<int>(10, da->rozmiar); i++) {
		cout << *(da->get(i)) << " ";
	}
	cout << "..." << endl;

	cout << "Czas razem: " << pelnyCzas << "s" << endl;
	cout << "Sredni czas na operacje: " << sredniCzas << "s" << endl;

	// Zwalnianie pamiêci
	for (int i = 0; i < da->rozmiar; i++) {
		delete da->get(i);  // zwolnienie pamiêci dla obiektów
	}
	da->Usun();
	delete da;

	return 0;
}
