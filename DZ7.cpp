#include <iostream>
#include <string>

using namespace std;

class Book {
private:
    string title;
    string author;
    int year;
    string isbn;
    bool available;

public:
    Book(const string& _title, const string& _author, int _year, const string& _isbn)
        : title(_title), author(_author), year(_year), isbn(_isbn), available(true) {}

    const string& GetTitle() const { return title; }
    const string& GetAuthor() const { return author; }
    int GetYear() const { return year; }
    const string& GetISBN() const { return isbn; }
    bool IsAvailable() const { return available; }
};

class Library {
private:
    static const int MAX_BOOKS = 100;
    Book catalog[MAX_BOOKS];
    int numBooks;

public:
    Library() : numBooks(0) {}

    void AddBook(const Book& book) {
        if (numBooks < MAX_BOOKS) {
            catalog[numBooks++] = book;
        }
        else {
            cout << "Library is full. Cannot add more books." << endl;
        }
    }

    void RemoveBook(const string& isbn) {
        for (int i = 0; i < numBooks; ++i) {
            if (catalog[i].GetISBN() == isbn) {
                for (int j = i; j < numBooks - 1; ++j) {
                    catalog[j] = catalog[j + 1];
                }
                numBooks--;
                cout << "Book removed successfully." << endl;
                return;
            }
        }
        cout << "Book with ISBN " << isbn << " not found." << endl;
    }

    void SearchByAuthor(const string& author) {
        cout << "Books by author '" << author << "':" << endl;
        for (int i = 0; i < numBooks; ++i) {
            if (catalog[i].GetAuthor() == author) {
                cout << "Title: " << catalog[i].GetTitle() << ", ISBN: " << catalog[i].GetISBN() << endl;
            }
        }
    }

    void SearchByTitle(const string& title) {
        cout << "Books with title '" << title << "':" << endl;
        for (int i = 0; i < numBooks; ++i) {
            if (catalog[i].GetTitle() == title) {
                cout << "Author: " << catalog[i].GetAuthor() << ", ISBN: " << catalog[i].GetISBN() << endl;
            }
        }
    }

    void ListAvailableBooks() {
        cout << "Available books:" << endl;
        for (int i = 0; i < numBooks; ++i) {
            if (catalog[i].IsAvailable()) {
                cout << "Title: " << catalog[i].GetTitle() << ", Author: " << catalog[i].GetAuthor() << ", ISBN: " << catalog[i].GetISBN() << endl;
            }
        }
    }
};

int main() {
    Library library;

    Book book1("Book Title 1", "Author 1", 2020, "ISBN123");
    Book book2("Book Title 2", "Author 2", 2019, "ISBN456");

    library.AddBook(book1);
    library.AddBook(book2);

    while (true) {
        cout << "Menu:" << endl;
        cout << "1. Add Book" << endl;
        cout << "2. Remove Book" << endl;
        cout << "3. Search by Author" << endl;
        cout << "4. Search by Title" << endl;
        cout << "5. List Available Books" << endl;
        cout << "6. Exit" << endl;

        int choice;
        cin >> choice;

        switch (choice) {
        case 1: {
            string title, author, isbn;
            int year;
            cout << "Enter title: ";
            cin.ignore();
            getline(cin, title);
            cout << "Enter author: ";
            getline(cin, author);
            cout << "Enter year: ";
            cin >> year;
            cout << "Enter ISBN: ";
            cin.ignore();
            getline(cin, isbn);
            Book newBook(title, author, year, isbn);
            library.AddBook(newBook);
            cout << "Book added successfully." << endl;
            break;
        }
        case 2: {
            string isbn;
            cout << "Enter ISBN of the book to remove: ";
            cin >> isbn;
            library.RemoveBook(isbn);
            break;
        }
        case 3: {
            string author;
            cout << "Enter author name: ";
            cin.ignore();
            getline(cin, author);
            library.SearchByAuthor(author);
            break;
        }
        case 4: {
            string title;
            cout << "Enter book title: ";
            cin.ignore();
            getline(cin, title);
            library.SearchByTitle(title);
            break;
        }
        case 5: {
            library.ListAvailableBooks();
            break;
        }
        case 6: {
            cout << "Exiting the program." << endl;
            return 0;
        }
        default:
            cout << "Invalid choice. Please try again." << endl;
        }
    }

    return 0;
}
