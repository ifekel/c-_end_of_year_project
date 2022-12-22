using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime DateRegistered { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int NumberOfBooksInCustody { get; set; }
    }

    public class Admin
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }

    public class LibraryManagementSystem
    {
        public List<Book> books;
        public List<User> users;
        public Admin admin;

        public LibraryManagementSystem()
        {
            books = new List<Book>();
            users = new List<User>();
            admin = new Admin();
        }

        public void AddBookToInventory(Book book)
        {
            books.Add(book);
        }

        public Book GetBook(string name)
        {
            foreach (Book book in books)
            {
                if (book.Name == name)
                {
                    return book;
                }
            }
            return null;
        }

        public void RemoveBookFromInventory(string name)
        {
            Book bookToRemove = GetBook(name);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User GetUser(string name)
        {
            foreach (User user in users)
            {
                if (user.Name == name)
                {
                    return user;
                }
            }
            return null;
        }

        public void RemoveUser(string name)
        {
            User userToRemove = GetUser(name);
            if (userToRemove != null)
            {
                if (userToRemove.NumberOfBooksInCustody == 0)
                {
                    users.Remove(userToRemove);
                }
            }
        }

        public void BorrowBook(string userName, string bookName)
        {
            User user = GetUser(userName);
            Book book = GetBook(bookName);

            if (user != null && book != null && user.NumberOfBooksInCustody < 5)
            {
                user.NumberOfBooksInCustody++;
            }
        }

        public void ReturnBook(string userName, string bookName)
        {
            User user = GetUser(userName);
            Book book = GetBook(bookName);
            if (user != null && book != null)
            {
                user.NumberOfBooksInCustody--;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LibraryManagementSystem library = new LibraryManagementSystem();

            Book book1 = new Book();
            book1.Name = "Harry Potter and the Sorcerer's Stone";
            book1.Author = "J. K. Rowling";
            book1.DateRegistered = DateTime.Now;

            Book book2 = new Book();
            book2.Name = "The Great Gatsby";
            book2.Author = "F. Scott Fitzgerald";
            book2.DateRegistered = DateTime.Now;
            
            Book book3 = new Book();
            book3.Name = "Diary of a wimpy kid";
            book3.Author = "O. Ifeanyi";
            book3.DateRegistered = DateTime.Now;

            library.AddBookToInventory(book1);
            library.AddBookToInventory(book2);
            library.AddBookToInventory(book3);

            Console.WriteLine("Books in inventory:");
            foreach (Book book in library.books)
            {
                Console.WriteLine($"Name: {book.Name}, Author: {book.Author}, Date Registered: {book.DateRegistered}");
            }

            Console.WriteLine("\n");

            User user1 = new User();
            user1.Name = "John Smith";
            user1.Age = 30;
            user1.Address = "123 Main Street";
            user1.NumberOfBooksInCustody = 0;

            library.AddUser(user1);

            library.BorrowBook(user1.Name, book1.Name);

            Console.WriteLine($"{user1.Name} has {user1.NumberOfBooksInCustody} books in their custody.");

            library.ReturnBook(user1.Name, book1.Name);

            Console.WriteLine($"{user1.Name} has {user1.NumberOfBooksInCustody} books in their custody.");
            
            library.BorrowBook(user1.Name, book3.Name);

            Console.WriteLine($"{user1.Name} has {user1.NumberOfBooksInCustody} books in their custody.");
        }
    }
}