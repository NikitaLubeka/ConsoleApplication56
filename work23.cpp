#include <iostream>
#include <ctime>

using namespace std;

class RandomDateTime {
public:
    RandomDateTime() {
        months_ = { "January", "February", "March", "April", "May", "June",
                   "July", "August", "September", "October", "November", "December" };
    }

    void generateAndPrint() {
        cout << "Введите число: ";
        cin >> number_;

        if (number_ % 2 == 0) {
            time_t now;
            time(&now);
            tm* ltm = localtime(&now);

            int randomDay = rand() % 31 + 1;
            int randomHour = rand() % 24;
            int randomMinute = rand() % 60;
            cout << "Дата и время: ";
            cout << randomDay << " " << months_[ltm->tm_mon] << " " << randomHour << ":" << randomMinute << endl;
        }
        else {
            cout << "Вы ввели нечетное число." << endl;
        }
    }

private:
    int number_;
    const char* months_[12];
};

int main() {
    srand(static_cast<unsigned>(time(0)));
    RandomDateTime randomDateTime;
    randomDateTime.generateAndPrint();

    return 0;
}
has context menu
Compose