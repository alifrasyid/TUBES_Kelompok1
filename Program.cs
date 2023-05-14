using System;

namespace LoginRegisterMenuStateMachine
{
    class Program
    {
        enum State
        {
            MainMenu,
            Login,
            Register,
            Exit
        }

        static State currentState;

        static void Main(string[] args)
        {
            bool isRunning = true;
            currentState = State.MainMenu;

            while (isRunning)
            {
                switch (currentState)
                {
                    case State.MainMenu:
                        DisplayMainMenu();
                        break;
                    case State.Login:
                        Login();
                        break;
                    case State.Register:
                        Register();
                        break;
                    case State.Exit:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid state.");
                        break;
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Pilihan Anda: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    currentState = State.Login;
                    break;
                case "2":
                    currentState = State.Register;
                    break;
                case "3":
                    currentState = State.Exit;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    break;
            }
        }

        static void Login()
        {
            Console.WriteLine("=== Login ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            // Logika login di sini

            // Setelah login berhasil, kembali ke menu utama
            currentState = State.MainMenu;
        }

        static void Register()
        {
            Console.WriteLine("=== Register ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();

            // Logika registrasi di sini

            // Setelah registrasi berhasil, kembali ke menu utama
            currentState = State.MainMenu;
        }
    }
}
