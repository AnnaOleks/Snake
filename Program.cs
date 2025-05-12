using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        public static void Main(string[] args)
        
        {
            Console.SetWindowSize(85, 30);
            Console.CursorVisible = false;

            TitleScreen title = new TitleScreen(80, 25);
            MenuManager menu = new MenuManager();

            while (true)
            {
                int choice = title.Show();

                if (choice == 1) // Играть
                {
                    Console.Clear();
                    string playerName = PlayerNameScreen.Show();

                    int level = menu.ShowLevelMenu();
                    int speed = level switch
                    {
                        1 => 150,
                        2 => 100,
                        3 => 60
                    };

                    var player = new Player(playerName);
                    var engine = new GameEngine(speed, player);
                    engine.Start();
                }
                else if (choice == 2)
                {
                    new ScoreManager().ShowTopScores();
                    Console.WriteLine("\nНажмите любую клавишу...");
                    Console.ReadKey();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Выход...");
                    break;
                }
            }
        }

        private static string AskName()
        {
            string name;
            do
            {
                Console.Write("Sisesta oma nimi: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }
    }

}

     