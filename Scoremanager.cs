using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ScoreManager
    {
        private string filePath = @"C:\\Users\\annao\\source\\repos\\Snake\\Nimed.txt"; // Путь к файлу

        public int Score { get; private set; } = 0;

        // Увеличить счёт
        public void AddPoint()
        {
            Score++;
        }

        // Сохраняем имя и очки в файл
        public void SaveScore(string playerName)
        {
            try
            {
                string record = $"{playerName};{Score}";
                File.AppendAllText(filePath, record + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении очков: " + ex.Message);
            }
        }

        // Показать ТОП N игроков
        public void ShowTopScoresStyled(int topN = 10, int mapWidth = 80)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Rekordid ei ole veel salvestatud.");
                return;
            }

            var records = File.ReadAllLines(filePath);
            var scoreList = new List<(string Name, int Points)>();

            foreach (var line in records)
            {
                var parts = line.Split(';');
                if (parts.Length == 2 && int.TryParse(parts[1], out int points))
                {
                    scoreList.Add((parts[0], points));
                }
            }

            var sorted = scoreList
                .OrderByDescending(p => p.Points)
                .Take(topN)
                .ToList();

            Console.Clear();
            string title = "TOP Mängijad:";
            Console.ForegroundColor = ConsoleColor.Cyan;
            int startY = 10;

            int titleX = (mapWidth - title.Length) / 2;
            Console.SetCursorPosition(titleX, startY - 2);
            Utility.AnimateText(title, 30);

            for (int i = 0; i < sorted.Count; i++)
            {
                Console.ResetColor();
                string line = $"{i + 1}. {sorted[i].Name} - {sorted[i].Points} punkt(i)";
                int lineX = (mapWidth - line.Length - 2) / 2;
                Console.SetCursorPosition(lineX, startY + i);
                Console.Write(" " + line + " ");
                Console.ResetColor();
            }

            Console.SetCursorPosition((mapWidth - 26) / 2, startY + sorted.Count + 2);
            Console.WriteLine("Vajuta klahvi, et tagasi minna...");
            Console.ReadKey();
        }

        // Обнуление счёта
        public void Reset()
        {
            Score = 0;
        }
    }
}