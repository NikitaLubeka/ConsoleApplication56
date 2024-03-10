using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAuthorized { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            IsAuthorized = false;
        }
    }

    public delegate void AuthorizationHandler(User user);

    public class AuthorizationSystem
    {
        public event AuthorizationHandler UserAuthorized;
        public event AuthorizationHandler UserBlocked;

        private List<User> users = new List<User>();

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void RemoveUser(string username)
        {
            users.RemoveAll(u => u.Username == username);
        }

        public void AuthenticateUser(string username, string password)
        {
            User user = users.Find(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                user.IsAuthorized = true;
                OnUserAuthorized(user);
            }
            else
            {
                Console.WriteLine("Автентифікація не вдалася для користувача ", username);
                UserBlocked?.Invoke(user);
            }
        }

        protected virtual void OnUserAuthorized(User user)
        {
            UserAuthorized?.Invoke(user);
        }

        public void BlockUser(string username)
        {
            User user = users.Find(u => u.Username == username);
            if (user != null)
            {
                user.IsAuthorized = false;
                Console.WriteLine("Користувач  був заблокований.", username);
                UserBlocked?.Invoke(user);
            }
            else
            {
                Console.WriteLine("Користувач  не знайдений.", username);
            }
        }

        public void PrintUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine("Ім'я користувача: , Авторизований: ", user.Username, user.IsAuthorized);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AuthorizationSystem authSystem = new AuthorizationSystem();

            AuthorizationHandler authHandler = new AuthorizationHandler(OnUserAuthorized);
            authSystem.UserAuthorized += authHandler;

            User user1 = new User("user1", "password1");
            User user2 = new User("user2", "password2");

            authSystem.AddUser(user1);
            authSystem.AddUser(user2);

            Console.WriteLine("Користувачі до автентифікації:");
            authSystem.PrintUsers();

            authSystem.AuthenticateUser("user1", "password1");
            authSystem.AuthenticateUser("user2", "password_wrong");

            authSystem.RemoveUser("user1");

            Console.WriteLine("Користувачі після автентифікації та видалення:");
            authSystem.PrintUsers();
        }

        static void OnUserAuthorized(User user)
        {
            Console.WriteLine("Користувач успішно авторизований.", user.Username);
        }
    }
}