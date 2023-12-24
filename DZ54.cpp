#include <iostream>
#include <vector>
#include <string>

using namespace std;

int main() {
    auto add = [](int a, int b) { return a + b; };

    auto square = [](int x) { return x * x; };

    auto isEven = [](int x) { return x % 2 == 0; };

    auto sum = [](const vector<int>& vec) {
        int result = 0;
        for (int num : vec) {
            result += num;
        }
        return result;
    };

    auto printMessage = [](const string& message) {
        cout << message << endl;
    };

    auto isPalindrome = [](const string& str) {
        for (size_t i = 0; i < str.size() / 2; ++i) {
            if (str[i] != str[str.size() - 1 - i]) {
                return false;
            }
        }
        return true;
    };

    auto multiply = [](int a, int b) { return a * b; };
    auto greet = [](const string& name) { cout << "Hello, " << name << "!" << endl; };
    auto isPositive = [](int x) { return x > 0; };

    return 0;
}

