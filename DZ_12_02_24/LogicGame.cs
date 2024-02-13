using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DZ_12_02_24
{
    public class LogicGame
    {
        private static int targetNumber;
        private static int attempts;

        public LogicGame()
        {
            StartNewGame();
        }

        private static void StartNewGame()
        {
            Random rand = new Random();
            targetNumber = rand.Next(1, 100);
            attempts = 0;
        }

        private static void CheckGuess(int guess)
        {
            attempts++;
            if (guess < targetNumber)
            {
                ShowMessageBox("Загадане число більше!", "Спробуйте ще");
            }
            else if (guess > targetNumber)
            {
                ShowMessageBox("Загадане число менше!", "Спробуйте ще");
            }
            else
            {
                ShowMessageBox($"\tВітаю!\nВи вгадали число {targetNumber}\n\tз {attempts} спроб.", "Перемога!");
                Console.WriteLine("Бажаєте зіграти ще? (Так/Ні)");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() == "так")
                {
                    StartNewGame();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
        private static void ShowMessageBox(string message, string title)
        {
            MessageBox(IntPtr.Zero, message, title, 0);
        }

        public void Play()
        {
            while (true)
            {
                Console.WriteLine("Введіть число (от 1 до 100):");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int guess))
                {
                    if (guess >= 1 && guess <= 100)
                    {
                        CheckGuess(guess);
                    }
                    else
                    {
                        ShowMessageBox("Введіть число від 1 до 100.", "Помилка");
                    }
                }
                else
                {
                    ShowMessageBox("Введіть коректне число.", "Помилка");
                }
            }
        }
    }
}
