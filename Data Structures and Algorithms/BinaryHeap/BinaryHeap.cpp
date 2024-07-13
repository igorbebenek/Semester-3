//ALGO2 IS1 224A LAB05
//Igor Bębenek
//bi53940@zut.edu.pl
#include <iostream>
#include <sstream>
#include <cmath>

using namespace std;

template<typename T>
class kopiec_binarny {
public:


    //konstruktor
    kopiec_binarny() {
        capacity = 10;
        size = 0;
        dynamic_array = new T[capacity];
    }

  

    void heapUp(unsigned int i) {
        while (i && dynamic_array[i] < dynamic_array[(i - 1) / 2]) {
            swap(dynamic_array[i], dynamic_array[(i - 1) / 2]);
            i = (i - 1) / 2;
        }

    }
    void heapDown(unsigned int i) {

        int min;
        int n = size - 1; //indeks ostatniego elementu kopca
        do {
            int l = 2 * i + 1;
            int r = l + 1;
            if ((l <= n) && (dynamic_array[l] < dynamic_array[i]))
                min = l; //sprawdzamy czy istnieje i czy mniejsze od biezacego wezla
            else min = i;
            if ((r <= n) && (dynamic_array[r] < dynamic_array[i]) && (dynamic_array[r] < dynamic_array[l])) min = r; //sprawdzenie czy prawe istnieje i czy mniejsze niz bierzacy wezel i lewe dziecko
            if (i != min) {
                swap(dynamic_array[i], dynamic_array[min]); //zamiana miejscami bieżącego węzła z jego mniejszym dzieckiem
                i = min;
            }
            else break;
        } while (i < n);

    }
    


    void add(const T& dane) {
        if (size < capacity) {
            dynamic_array[size++] = dane;
        }
        else {
            capacity = capacity * 2 + 1;
            T* tempArray = new T[capacity];

            for (int i = 0; i < size; i++) {
                tempArray[i] = dynamic_array[i];
            }

            delete[] dynamic_array;
            dynamic_array = tempArray;
            dynamic_array[size++] = dane;

        }
        heapUp(size - 1);
    }

    




    void clear() {
        delete[] dynamic_array;
        dynamic_array = NULL;
        size = 0;
        capacity = 0;
    }

    void out() const {
        int i = 0;
        while (i < size) {
            cout << dynamic_array[i] << " ";
            cout << endl;
            i++;
        }
    }
    //usuniecie i zwrocenie maksymalnego
    T removeMax() {
        T temp = dynamic_array[0];
        dynamic_array[0] = dynamic_array[--size];
        heapDown(0);
        return temp;
    }

private:
    T* dynamic_array;
    int capacity;
    unsigned int size = 0;
};

struct some_object {
    int field_1;
};

std::ostream& operator<<(std::ostream& out, const some_object& o) {
    out << o.field_1;
    return out;
}

bool operator<(const some_object& a, const some_object& b) {
    return a.field_1 < b.field_1 || a.field_1 == b.field_1;

}

bool operator==(const some_object& so1, const some_object& so2) {
    return so1.field_1 == so2.field_1;
}





//int main() {
//    binary_heap<some_object>* l = new binary_heap<some_object>;
//    some_object o1 = { 1 }, o2 = { 3 }, o3 = { 6 }, o4 = { 5 }, o5 = { 9 }, o6 = { 8 };
//
//    clock_t start, end;
//    double cpu_time_used;
//
//    // Dodaj elementy z pomiarem czasu
//    start = clock();
//    l->add(o1);
//    l->add(o2);
//    l->add(o3);
//    l->add(o4);
//    l->add(o5);
//    l->add(o6);
//    end = clock();
//    cpu_time_used = ((double)(end - start)) / CLOCKS_PER_SEC;
//    cout << "Czas dodawania elementow: " << cpu_time_used << " sekund" << endl;
//
//    // Wyświetl kopiec
//    cout << "Stan kopca po dodaniu elementow:" << endl;
//    l->out();
//    cout << endl;
//
//    // Usuń i wyświetl maksymalny element z pomiarem czasu
//    start = clock();
//    cout << "Usunieto: " << l->removeMax() << endl;
//    end = clock();
//    cpu_time_used = ((double)(end - start)) / CLOCKS_PER_SEC;
//    cout << "Czas usunięcia maksymalnego elementu: " << cpu_time_used << " sekund" << endl;
//    cout << "Stan kopca po usunięciu maksymalnego elementu:" << endl;
//    l->out();
//    cout << endl;
//
//    // Czyszczenie kopca
//    l->clear();
//    cout << "Stan kopca po czyszczeniu:" << endl;
//    l->out();
//    cout << endl;
//
//    // Dodaj ponownie jeden element i wyświetl kopiec
//    l->add(o1);
//    cout << "Stan kopca po dodaniu jednego elementu:" << endl;
//    l->out();
//    cout << endl;
//
//    delete l; // Zwalnianie pamięci
//    return 0;
//}


//1
/// \
//3     6
/// \ /
//5   9 8








//3
/// \
//5     6
/// \
//8   9





int main() {
    const int NUM_ELEMENTS = 10000; // Liczba elementów do dodania
    kopiec_binarny<some_object>* l = new kopiec_binarny<some_object>;

    clock_t start, end;
    double cpu_time_used;

    // Dodaj dużą liczbę elementów z pomiarem czasu
    start = clock();
    for (int i = 0; i < NUM_ELEMENTS; i++) {
        some_object temp = { rand() % 1000 }; // Losowe wartości
        l->add(temp);
    }
    end = clock();
    cpu_time_used = ((double)(end - start)) / CLOCKS_PER_SEC;
    cout << "Czas dodawania " << NUM_ELEMENTS << " elementow: " << cpu_time_used << " sekund" << endl;

   //  Wyświetl kopiec
    /*cout << "Stan kopca po dodaniu elementów:" << endl;
    l->out();
    cout << endl;*/

    // Usuń elementy z pomiarem czasu
    start = clock();
    for (int i = 0; i < NUM_ELEMENTS; i++) {
        l->removeMax();
    }
    end = clock();
    cpu_time_used = ((double)(end - start)) / CLOCKS_PER_SEC;
    cout << "Czas usuwania " << NUM_ELEMENTS << " elementow: " << cpu_time_used << " sekund" << endl;

    // Wyświetl kopiec
    cout << "Stan kopca po usunięciu elementow:" << endl;
    l->out();
    cout << endl;

    delete l; // Zwalnianie pamięci
    return 0;
}
