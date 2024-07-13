//ALGO2 IS1 224A LAB01
// Igor Bębenek
// bi53940@zut.edu.pl
#include <iostream>
#include "time.h"
#include <sstream>
#include <cmath>

using namespace std;

template <typename T>

class ListaDwukierunkowa {
private:

public:
	struct Node {
		Node* nastepny, * poprzedni;
		T wartosc;
	};


// a dodanie nowego elementu na koniec listy (argument: dane)

	void dodajNaKoncu(const T& dane) {
		Node* n = new Node();
		n->wartosc = dane;
		n->nastepny = nullptr;

		if (size == 0) {
			ogon = glowa = n;
			n->poprzedni = nullptr;
		}
		else {
			ogon->nastepny = n;
			n->poprzedni = ogon;
			ogon = n;
		}
		size++;
	}

	// b dodanie nowego elementu na poczatku listy 

	void dodajNaPoczatku(const T& dane) {
		Node* n = new Node();
		n->wartosc = dane;
		n->poprzedni = nullptr;

		if (size == 0) {
			glowa = ogon = n;
			n->nastepny = nullptr;
		}
		else {
			glowa->poprzedni = n;
			n->nastepny = glowa;
			glowa = n;
		}
		size++;
	}

	// c usuniecie ostatniego elementu

	void usunOstatni() {
		if (size == 0) {
			return;
		}

		else if (size == 1) {
			delete glowa;
			glowa = nullptr;
			ogon = nullptr;
			size--;
		}
		else {
			Node* pom = ogon->poprzedni;
			delete ogon;
			pom->nastepny = nullptr;
			ogon = pom;
			size--;
		}
	}

	// d usuniecie pierwszego elementu

	void usunPierwszy() {
		if (size == 0) {
			return;
		}

		else if (size == 1) {
			delete glowa;
			glowa = nullptr;
			ogon = nullptr;
			size--;
		}
		else {
			Node* pom = glowa->nastepny;
			delete glowa;
			pom->poprzedni = nullptr;
			glowa = pom;
			size--;
		}
	}
	// e zwroccenie danych itego elementu

	T& get(int n)const {
		if (n < size) {

			Node* ity = glowa;

			for (int i = 0; i < n; i++) {
				ity = ity->nastepny;
			}
			return ity->wartosc;
		}
		else throw "brak elementu";
	}
	// f ustawienie itego elementu

	void ustawElement(int n, const T& dane) {
		if (n < size) {
			Node* ity = glowa; //wskaznik na pierwszy element listy
			int i = 0;
			while (i < n) {
				ity = ity->nastepny;
				i++;
			}
			ity->wartosc = dane;


		}
		else throw "brak elementu"; //obsluzony wyjatek

	}
	// g wyszukiwanie elementu

	T* wyszukaj(const T& dane) const {
		Node* ity = glowa;
		while (ity != nullptr && !(ity->wartosc == dane)) {
			ity = ity->nastepny;
		}
		return ity != nullptr ? &(ity->wartosc) : nullptr; //conditional operator


	}

	// h wyszukanie i usunięcie elementu

	bool usun(const T& dane) {
		Node* it = glowa;
		while (it != nullptr && !(it->wartosc == dane)) {
			it = it->nastepny;
		}
		if (it != nullptr) {

			if (it == ogon) {
			usunOstatni();
			}

			else if(it == glowa) {
				usunPierwszy();
			}
			
			else {
				it->poprzedni->nastepny = it->nastepny;
				it->nastepny->poprzedni = it->poprzedni;
				size--;
				delete it;
			}


			return true;


		}
		else {
			return false;
		}

	}
	// i  dodanie nowego elementu z wymuszeniem porządku

	void dodajZPorzadkiem(const T& dane) {
		if (size == 0) {
			dodajNaPoczatku(dane);
		}
		else if (dane < glowa->wartosc || dane == glowa->wartosc) {
			dodajNaPoczatku(dane);
		}
		else if (ogon->wartosc < dane || ogon->wartosc == dane) {
			dodajNaKoncu(dane);
		}
		else {
			Node* it = glowa;

			while (it->wartosc < dane) {
				it = it->nastepny;
			}
			Node* n = new Node();
			n->wartosc = dane;
			n->poprzedni = it->poprzedni;
			n->nastepny = it;
			it->poprzedni->nastepny = n;
			it->poprzedni = n;
			size++;
		}

	}


	// j czyszczenie listy 

	void wyczysc() {
		Node* it = glowa;
		while (it != nullptr) {
			Node* pom = it->nastepny;
			delete it;
			it = pom;
		}
		glowa = ogon = nullptr;
		size = 0;
	}


	// k  zwrócenie napisowej reprezentacji listy, wypisywanie listy

	string to_string() const
	{
		ostringstream out;
		Node* ity = glowa;
		while (ity != nullptr) {
			out << ity->wartosc << endl;
			ity = ity->nastepny;
		}

		return out.str();
	}

	//destrukor

	~ListaDwukierunkowa() {
		wyczysc();
	}
private:
	Node* glowa = nullptr, * ogon = nullptr;
	unsigned int size = 0;

};

struct PewienObiekt
{
	private:

	public:
		int pole1;
		char pole2;


};
//przeciazone operatory dla PewienObiekt:

// Operator strumieniowy umożliwiający wypisanie obiektu klasy some_object.

std::ostream& operator<<(std::ostream& out, const PewienObiekt& o)
{
	out << o.pole1 << " " << o.pole2;
	return out;
}

// dla wyszukaj i usun

bool operator==(const PewienObiekt& so1, const PewienObiekt& so2)
{
	return so1.pole1 == so2.pole1 && so1.pole2 == so2.pole2;
}

// i dodanie nowego elementu z wymuszeniem porządku

bool operator <(const PewienObiekt& a, const PewienObiekt& b)
{
	return a.pole1 < b.pole1 || a.pole1 == b.pole1 && a.pole2 < b.pole2;

}


int main() {
	
 ListaDwukierunkowa<PewienObiekt> l;
 int i = 0;
 while (i < 6) //tworzymy szesc obiektów z losową wartością pole1
 {
	 PewienObiekt so = PewienObiekt();
	 so.pole1 = rand();
	 l.dodajZPorzadkiem(so);
	 i++;
 }

 //wypisujemy je

 cout<<l.to_string();

 srand(time(NULL));

 // maksymalny rzad wielkosci rozmiaru dodawanych danych

const int maksymalnyRzad = 6;

// stworzenie listy

ListaDwukierunkowa < PewienObiekt  >* listaDynamiczna = new ListaDwukierunkowa < PewienObiekt  >() ; 

// petla po kolejnych rzedach wielkosci

for (int j = 1; j <= maksymalnyRzad; j++) 
{
	const int n = pow(10, j); // ustalanie rozmiaru danych
	cout << "n=" << n << endl;

	
	clock_t t1 = clock(); //dodawanie elementow do listy
	for (int i = 0; i < n; i++)
	{
		//dane losowe
		PewienObiekt so = PewienObiekt(); 
		so.pole1 = rand() % 10000;
		so.pole2 = (rand() % ('z' - 'a') + 'a');
		listaDynamiczna->dodajNaKoncu(so);
	}
	clock_t t2 = clock();
	cout << "Sredni czas dodawania " << double(t2 - t1) / n << endl;

	// wyszukiwanie i usuwanie z listy

	const int m = pow(10, 4); // proby wyszukiwania
	t1 = clock();
	int i = 0;
	while (i < m)
	{
		PewienObiekt obiekt1 = PewienObiekt();  // losowe dane jako wzorzec do wyszukiwania (obiekt chwilowy)
		obiekt1.pole1 = rand() % 10000;
		obiekt1.pole2 = (rand() % ('z' - 'a')) + 'a';
		listaDynamiczna->usun(obiekt1);
		i++;
	}
	t2 = clock();
	cout << "Sredni czas usuwania " << double(t2 - t1) / n << endl;

	// czyszczenie listy wraz z uwalnianiem pamieci

	listaDynamiczna->wyczysc();
}

	delete listaDynamiczna ;
	


	return 0;
}

