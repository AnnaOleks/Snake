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

            Params param = new Params();
            string path = param.GetResourseFolder();
            Sounds sounds = new Sounds(path);
            sounds.Play();

            while (true)
            {
                int choice = title.Show();

                if (choice == 1) // Играть
                {
                    Console.Clear();
                    string playerName = PlayerNameScreen.Show();

                    int level = menu.ShowLevelMenu();
                    var difficulty = new DifficultyManager(level);
                    int speed = difficulty.GetInitialSpeed();

                    var player = new Player(playerName);
                    var engine = new GameEngine(player, difficulty, sounds);
                    engine.Start();

                }
                else if (choice == 2)
                {
                    new ScoreManager().ShowTopScoresStyled();
                    Console.WriteLine("\nVajuta nuppu...");
                    Console.ReadKey();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Välju...");
                    break;
                }
            }
        }
    }

}

     