#include <iostream>
#include <ctime>
#include <windows.h>
using namespace std;
class Weapon {

protected:
    unsigned short damage;
    unsigned short weight;
    unsigned short numberOfCartridgesInTheClip;
    unsigned short numberOfClips;
    unsigned short accuracy; 
    double rateOfFire;      
public:
    unsigned short getDamage() const { return this->damage; }
    unsigned short getWeight() const { return this->weight; }
    unsigned short getNumberOfCartridgesInTheClip() const { return this->numberOfCartridgesInTheClip; }
    unsigned short getNumberOfClips() const { return this->numberOfClips; }
    unsigned short getAccuracy() const { return this->accuracy; }
    double getRateOfFire() const { return this->rateOfFire; }

};

class Empty : public Weapon {
public:

    Empty() {
        this->damage = 5;
        this->weight = 0;
        this->numberOfCartridgesInTheClip = 1000;
        this->numberOfClips = 0;
        this->accuracy = 0.6;
        this->rateOfFire = 0.9;

    }

};

class Glock : public Weapon {
public:

    Glock() {
        this->damage = 15;
        this->weight = 25;
        this->numberOfCartridgesInTheClip = 17;
        this->numberOfClips = 5;
        this->accuracy = 0.6;
        this->rateOfFire = 0.7;

    }

};

class AK47 : public Weapon {
public:

    AK47() {

        this->damage = 55;
        this->weight = 90;
        this->numberOfCartridgesInTheClip = 30;
        this->numberOfClips = 4;
        this->accuracy = 0.7;
        this->rateOfFire = 0.9;
    }

};

class M4A1 : public Weapon {
public:
    M4A1() {

        this->damage = 50;
        this->weight = 80;
        this->numberOfCartridgesInTheClip = 20;
        this->numberOfClips = 4;
        this->accuracy = 0.8;
        this->rateOfFire = 0.9;
    }

};

class ShotGun : public Weapon {
public:

    ShotGun() {

        this->damage = 90;
        this->weight = 80;
        this->numberOfCartridgesInTheClip = 7;
        this->numberOfClips = 4;
        this->accuracy = 0.4;
        this->rateOfFire = 0.6;

    }

};

class Player {

protected:
    string name;
    unsigned short hp;
    Weapon weapon;

public:

    Player(const string& playerName) : name(playerName), hp(100) {
        getWeapon();
    }

    void getWeapon() {
        srand(time(0));
        int weaponType = rand() % 5;
        switch (weaponType) {
        case 0:
            weapon = Empty();
            break;
        case 1:
            weapon = Glock();
            break;
        case 2:
            weapon = AK47();
            break;
        case 3:
            weapon = M4A1();
            break;
        case 4:
            weapon = ShotGun();
            break;
        default:
            cerr << "Неверный тип оружия!" << endl;

        }

    }

    void openFire(Player& target) {
        double hitChance = (rand() % 9 + 1) / 10.0;
        if (hitChance <= weapon.getAccuracy()) {
            unsigned short damageDealt = weapon.getDamage();
            cout << name << " стреляет в " << target.name << ", нанося " << damageDealt << " урона!" << endl;
            target.receiveDamage(damageDealt);

        }

        else {
            cout << name << " промахивается в выстреле по " << target.name << "!" << endl;

        }

    }

    void receiveDamage(unsigned short damage) {
        unsigned short effectiveDamage = damage > weapon.getDamage() ? damage - weapon.getDamage() : 0;
        hp = hp > effectiveDamage ? hp = effectiveDamage : 0;
        cout << name << " получает " << effectiveDamage << " урона. Текущее здоровье: " << hp << endl;

    }
    void displayInfo() const {
        cout << "Игрок: " << name << ", Здоровье: " << hp << ", Оружие: "
            << "Урон: " << weapon.getDamage() << ", Вес: " << weapon.getWeight()
            << ", Боеприпасы: " << weapon.getNumberOfCartridgesInTheClip() << ", Точность: " << weapo.getAccuracy()
            << ", Скорость стрельбы: " << weapon.getRateOfFire() << endl;

    }

};

class Bot : public Player {
public:
    Bot() : Player("Бот") {}
    void receiveDamage(unsigned short damage) override {
        unsigned short effectiveDamage = damage > weapon.getDamage()  damage - weapon.getDamage() : 
        hp = hp > effectiveDamage ? hp - effectiveDamage : 0;
        cout << name << " получает " << effectiveDamage << " урона. Текущее здоровье бота: " << hp << endl;

    }

};

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Player first("Игрок 1");
    Player second("Игрок 2");
    Bot bot;
    first.displayInfo();
    second.displayInfo();
    bot.displayInfo();
    for (int i = 0; i < 5; ++i) {
        first.openFire(second);
        second.openFire(first);
        first.openFire(bot);
        bot.openFire(first);

    }

    first.displayInfo();
    second.displayInfo();
    bot.displayInfo();
    return 0;

}

