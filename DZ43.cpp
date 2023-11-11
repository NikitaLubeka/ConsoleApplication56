
#include <iostream>

using namespace std;

class MorseCodeConverter {
private:
    static const int MAX_MORSE_LENGTH = 5;
    static const int NUM_OF_LETTERS = 26;
    char alphabet[NUM_OF_LETTERS];
    const char* morseCodes[NUM_OF_LETTERS];

public:
    MorseCodeConverter() {
        char* letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const char* morse[NUM_OF_LETTERS] = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

        for (int i = 0; i < NUM_OF_LETTERS; i++) {
            alphabet[i] = letters[i];
            morseCodes[i] = morse[i];
        }
    }

    string textToMorse(const string& text) {
        string morseCode;
        for (char c : text) {
            if (isalpha(c)) {
                char upperC = toupper(c);
                int index = upperC - 'A';
                morseCode += morseCodes[index];
                morseCode += ' ';
            }
            else if (c == ' ') {
                morseCode += ' ';
            }
            else {
            }
        }
        return morseCode;
    }

    string morseToText(const string& morseCode) {
        string text;
        string currentMorseSymbol;
        for (char c : morseCode) {
            if (c == ' ' && !currentMorseSymbol.empty()) {
                int index = -1;
                for (int i = 0; i < NUM_OF_LETTERS; i++) {
                    if (strcmp(morseCodes[i], currentMorseSymbol.c_str()) == 0) {
                        index = i;
                        break;
                    }
                }

                if (index != -1) {
                    text += alphabet[index];
                }
                else {
                }
                currentMorseSymbol.clear();
            }
            else if (c != ' ') {
                currentMorseSymbol += c;
            }
        }

        if (!currentMorseSymbol.empty()) {
            int index = -1;
            for (int i = 0; i < NUM_OF_LETTERS; i++) {
                if (strcmp(morseCodes[i], currentMorseSymbol.c_str()) == 0) {
                    index = i;
                    break;
                }
            }

            if (index != -1) {
                text += alphabet[index];
            }
            else {
            }
        }

        return text;
    }
};

int main() {
    MorseCodeConverter converter;

    string text = "HELLO";
    string morseCode = converter.textToMorse(text);
    cout << "Текст в азбуке Морзе: " << morseCode << endl;
    string decodedText = converter.morseToText(morseCode);
    cout << "Азбука Морзе в текст: " << decodedText << endl;

    return 0;
}


