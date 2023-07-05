

#include <iostream>

#include <string>

#include <Windows.h>



using namespace std;



double convertLength(double value, int from, int to) {

    double ratios[] = { 1.0, 0.01, 0.001, 100.0, 1000.0 };

    return value * ratios[from] / ratios[to];

}



double convertMass(double value, int from, int to) {

    double ratios[] = { 1.0, 0.001, 0.000001, 1000.0 };

    return value * ratios[from] / ratios[to];

}



int main() {

    SetConsoleCP(1251);

    SetConsoleOutputCP(1251);

    int choice;



    do {

        cout << "Выберите вариант конвертации:\n"

            << "1. Длина\n"

            << "2. Масса\n"

            << "0. Выход\n"

            << "Введите номер варианта: ";

        cin >> choice;



        if (choice == 1) {

            int from, to;

            double value;

            cout << "Введите значение: ";

            cin >> value;

            cout << "Выберите исходную единицу:\n"

                << "1. Метры\n"

                << "2. Сантиметры\n"

                << "3. Миллиметры\n"

                << "4. Километры\n"

                << "5. Мили\n"

                << "Введите номер единицы: ";

            cin >> from;

            cout << "Выберите целевую единицу:\n"

                << "1. Метры\n"

                << "2. Сантиметры\n"

                << "3. Миллиметры\n"

                << "4. Километры\n"

                << "5. Мили\n"

                << "Введите номер единицы: ";

            cin >> to;



            string units[] = { "м", "см", "мм", "км", "миль" };



            double result = convertLength(value, from, to);

            cout << value << " " << units[from - 1] << " = " << result << " " << units[to - 1] << "\n";

        }

        else if (choice == 2) {

        }

    } while (choice != 0);



    return 0;

}
