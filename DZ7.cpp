﻿// ConsoleApplication127.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <vector>
#include <Windows.h>

using namespace std;

class Product {
private:
    string name;
    int id;
    double price;
    int quantity;

public:
    Product(string n, int i, double p, int q)
        : name(move(n)), id(i), price(p), quantity(q) {}

    double getPrice() const { return price; }
    int getQuantity() const { return quantity; }
    void setPrice(double newPrice) { price = newPrice; }
    void setQuantity(int newQuantity) { quantity = newQuantity; }
    int getId() const { return id; }

    bool operator<(const Product& other) const {
        return name < other.name;
    }
};

class Warehouse {
private:
    vector<Product> products;

public:
    void addProduct(const Product& product) {
        products.push_back(product);
    }

    void removeProductById(int id) {
        auto it = find_if(products.begin(), products.end(),
            [id](const Product& p) { return p.getId() == id; });
        if (it != products.end()) {
            products.erase(it);
        }
    }

    int getQuantityById(int id) const {
        auto it = find_if(products.begin(), products.end(),
            [id](const Product& p) { return p.getId() == id; });
        return (it != products.end()) ? it->getQuantity() : 0;
    }

    void filterProducts(function<bool(const Product&)> filterFunction) {
        for (const auto& product : products) {
            if (filterFunction(product)) {
                SetConsoleCP(1251);
                SetConsoleOutputCP(1251);

                cout << "Имя: " << product.getName() << ", Цена: " << product.getPrice()
                    << ", Количество: " << product.getQuantity() << endl;
            }
        }
    }
};

