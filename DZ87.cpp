// ConsoleApplication115.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>

using namespace std;

class StringManager {
private:
    static const int MAX_SIZE = 6;
    string strings[MAX_SIZE];

public:
    StringManager(const string& s1, const string& s2, const string& s3, const string& s4, const string& s5, const string& s6) {
        strings[0] = s1;
        strings[1] = s2;
        strings[2] = s3;
        strings[3] = s4;
        strings[4] = s5;
        strings[5] = s6;
    }

    void SortByName() {
        for (int i = 0; i < MAX_SIZE - 1; ++i) {
            for (int j = 0; j < MAX_SIZE - i - 1; ++j) {
                if (strings[j] > strings[j + 1]) {
                    swap(strings[j], strings[j + 1]);
                }
            }
        }
    }

    void SortByLength() {
        for (int i = 0; i < MAX_SIZE - 1; ++i) {
            for (int j = 0; j < MAX_SIZE - i - 1; ++j) {
                if (strings[j].length() > strings[j + 1].length()) {
                    swap(strings[j], strings[j + 1]);
                }
            }
        }
    }

    void Display() {
        for (const auto& str : strings) {
            cout << str << " ";
        }
        cout << endl;
    }
};

int main() {
    StringManager lol("Hello", "A", " ", "123abc", "a B", "");
    lol.SortByName();
    lol.Display();

    return 0;
}

