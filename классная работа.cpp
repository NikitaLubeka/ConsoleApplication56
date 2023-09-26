﻿#include <iostream>
#include <string>
#include <Windows.h>

using namespace std;

class BankAccount {
private:
    string ownerName;
    int accountNumber;
    double balance;

public:
    BankAccount(const string& name, int accNumber, double initialBalance)
        : ownerName(name), accountNumber(accNumber), balance(initialBalance) {}

    void Deposit(double amount) {
        SetConsoleCP(1251);
        SetConsoleOutputCP(1251);
        if (amount > 0) {
            balance += amount;
            cout << "Внесено " << amount << " на рахунок." << endl;
        }
        else {
            cout << "Неправильна сума для внесення." << endl;
        }
    }

    void Withdraw(double amount) {
        if (amount > 0 && amount <= balance) {
            balance -= amount;
            cout << "Знято " << amount << " з рахунку." << endl;
        }
        else {
            cout << "Недостатньо коштів на рахунку або неправильна сума для зняття." << endl;
        }
    }

    double GetBalance() const {
        return balance;
    }

    void DisplayInfo() const {
        SetConsoleCP(1251);
        SetConsoleOutputCP(1251);
        cout << "Ім'я власника: " << ownerName << endl;
        cout << "Номер рахунку: " << accountNumber << endl;
        cout << "Поточний баланс: " << balance << endl;
    }
};

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    BankAccount account1("Богдан Хмельницкий ", 123456, 1000.0);
    BankAccount account2("Маруся Чурай ", 789012, 500.0);

    account1.Deposit(200.0);
    account1.DisplayInfo();

    account2.Deposit(300.0);
    account2.DisplayInfo();

    account1.Withdraw(50.0);
    account1.DisplayInfo();

    account2.Withdraw(1000.0);
    account2.DisplayInfo();

    return 0;
}
