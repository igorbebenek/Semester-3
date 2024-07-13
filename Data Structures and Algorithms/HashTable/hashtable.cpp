//ALGO2 IS1 224A LAB06
//Igor Bêbenek
//bi53940@zut.edu.pl
#include <iostream>
#include <vector>
#include <forward_list>
#include <sstream>
#include <cmath>
#include <algorithm>
#include <ctime>
using namespace std;
template<typename V>

class Hash {
public:
    Hash() {
        t.resize(4);
        n = 0;
    }

 

    V* search(const string& key) {
        size_t idx = compute_idx(key);
        for (auto& e : t[idx]) {
            if (e.first == key) {
                return &e.second;
            }
        }
        return nullptr;
    }

    void add(const string& key, const V& va)
    {
        if (n >= 0.75 * t.size()) {
            rehash();
        }
        size_t idx = compute_idx(key);
        for (auto& e : t[idx]) {
            if (e.first == key) {
                e.second = va;
                return;
            }
        }

        t[idx].push_front(make_pair(key, va)); //Jeœli klucz nie zosta³ znaleziony w istniej¹cych elementach tworzy now¹ parê klucz-wartoœæ
        n++;
    }

    bool remove(const string& key) {
        size_t idx = compute_idx(key);
        for (auto& e : t[idx]) {
            if (e.first == key) {
                t[idx].remove(e);
                return true;
            }
        }
        return false;
    }

    void clear() {
        t.clear();
        n = 0;
        cout << "Tablica zostala wyczyszczona" << endl;
    }

    size_t compute_idx(string key) const {
        size_t h = 0; //przechowuje wartosc hash

        for (size_t i = 0; i < key.length(); i++) {
            h = h * 31 + key[i]; //liczenie hash poprzez mno¿enie aktualnej wartoœci h przez 31 i dodanie kodu ASCII bie¿¹cego znaku.
        }

        return h % t.size();
    }

  



  

    string toString() {
        stringstream ss;
        for (int i = 0; i < t.size(); i++) {
            if (!t[i].empty()) {
                ss << i << " -> ";
                for (auto& e : t[i]) {
                    ss << "(" << e.first << ", " << e.second << ") ";
                }
                ss << "\n";
            }
        }
        return ss.str();
    }
    void print_stats() { //skrotowa reprezentacja tablicy
        cout << "Rozmiar: " << n << endl;

        int blank = 0; //zlicza puste sloty tablciy
        int max = 0;  // sledzenie maksymalnej glebokosci slotu
        int min = numeric_limits<int>::max();  // sledzenie minimalnej glebokosci slotu
        int bucketItemCount; //zliczanie elementow w slocie

        for (int i = 0; i < t.size(); i++) {
            if (t[i].empty()) {
                blank++;
            }
            else { //Dla ka¿dego niepustego slotu, zlicza liczbê elementów w tym slocie.
                bucketItemCount = 0;
                for (auto& e : t[i]) {
                    bucketItemCount++;
                }
                if (max < bucketItemCount) max = bucketItemCount; //aktualizacja w zaleznosci od liczby elementow
                if (min > bucketItemCount) min = bucketItemCount;
            }
        }

        cout << "Puste sloty: " << blank << endl;
        cout << "Max glebokosc slotu: " << max << endl;
        cout << "Min glebokosc slotu: " << (min == numeric_limits<int>::max() ? 0 : min) << endl;
    }

private:
    vector<forward_list<pair<string, V>>> t;
    size_t n;

    void rehash()
    {
        vector<forward_list<pair<string, V>>> o;
        o = t;
        t.clear();
        t.resize(o.size() * 2 + 1);
        for (auto& e : o) {
            for (auto& f : e) {
                size_t idx = compute_idx(f.first);
                t[idx].push_front(f);
            }
        }
    }


};

struct some_object {
    int value;
};

string random_key(const int length) {
    static const char dictionary[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ""abcdefghijklmnopqrstuvwxyz";
    string tmp;
    for (int i = 0; i < length; i++) {
        tmp += dictionary[rand() % (sizeof(dictionary) - 1)];
    }
    return tmp;
}

std::ostream& operator<<(std::ostream& out, const some_object& o) {
    out << o.value;
    return out;
}

bool operator==(const some_object& o1, const some_object& o2) {
    return o1.value == o2.value;
}

string operator+(const string& s, const some_object& o2) {
    return s + to_string(o2.value);
}

int main() {
    some_object o1 = { 2 };
    some_object o2 = { 5 };
    Hash<some_object> hashTable;

    // Dodawanie pocz¹tkowych elementów
    hashTable.add("aqwefa", o1);
    hashTable.add("eadgfd", o1);
    hashTable.add("fsdfzb", o1);
    hashTable.add("ffgjhs", o1);
    hashTable.add("iwdgjs", o1);
    hashTable.add("pmlaiw", o1);
    hashTable.add("mauwns", o1);
    hashTable.add("nsywmf", o1);
    hashTable.add("powmsj", o1);
    hashTable.add("ffgjhs", o1);
    cout << "Poczatkowy stan tablicy:\n" << hashTable.toString();

    
    //hashTable.add(random_key(6), o1);
    //hashTable.add(random_key(6), o2);
    //cout << "Stan tablicy po dodaniu losowych kluczy:\n" << hashTable.toString();

    // Operacje wyszukiwania i usuwania
    cout << "Szukanie 'eadgfd': " << *(hashTable.search("eadgfd")) << endl;
    cout << "Usuwanie 'aqwefa': " << hashTable.remove("aqwefa") << endl;
    cout << "Usuwanie 'eeeeee' (nieistniejacego): " << hashTable.remove("eeeeee") << endl;
    cout << "Aktualny stan tablicy:\n" << hashTable.toString();

    // Dodatkowe testy wydajnoœciowe
    const int MAX_ORDER = 7;
    for (int o = 1; o <= MAX_ORDER; o++) {
        int n = pow(10, o);

        // Dodawanie do tablicy mieszaj¹cej
        clock_t t1_add = clock();
        for (int i = 0; i < n; i++)
            hashTable.add(random_key(6), some_object{ rand() % 100 });
        clock_t t2_add = clock();

        double add_time = double(t2_add - t1_add) / CLOCKS_PER_SEC;
        cout << "Czas dodawania " << n << " elementow: " << add_time << " sekund" << endl;

        hashTable.print_stats();
        cout << endl;

        // Wyszukiwanie w tablicy mieszaj¹cej
        int hits = 0;
        clock_t t1_search = clock();
        for (int i = 0; i < pow(10, 4); i++) {
            if (hashTable.search(random_key(6)) != NULL)
                hits++;
        }
        clock_t t2_search = clock();

        double search_time = double(t2_search - t1_search) / CLOCKS_PER_SEC / n;
        cout << "Sredni czas wyszukiwania: " << search_time << " sekund" << endl << endl;

        // Czyszczenie tablicy mieszaj¹cej przed kolejnym cyklem testów

    }
    hashTable.clear();
    hashTable.toString();
    delete& hashTable;

    return 0;
}