using System;
using System.Collections.Generic;
using System.Text;

namespace MateuszBartkowiakBayt
{
    public class Menu
    {
        private int SelectedId { get; set; }
        private string[] Options { get; set; }
        public string Title { get; set; }

        public Menu(string title, string[] options)
        {
            SelectedId = 0;
            Options = options;
            Title = title;
        }

        public void ShowOptions()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(UiText.titleMain);

            //Jeśli wymiary konsoli niezgodne z założeniem
            if (Console.WindowWidth>=82 && Console.WindowHeight>=35)
            Console.WriteLine($"Obecne wymiary okna są prawidłowe: {Console.WindowWidth} x {Console.WindowHeight}");
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Obecne wymiary okna nie są prawidłowe: {Console.WindowWidth} x {Console.WindowHeight}");
            }

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine(Title);

            //Wyświetlenie wszystkich opcji
            for (int i = 0; i < Options.Length; i++)
            {
                string option = Options[i];
                Console.SetCursorPosition(5, Console.CursorTop);
                if (i == SelectedId)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"<< {option} >>    <-----Enter abu potwierdzić");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"<< {option} >>");
                }
               
            }
            Console.ResetColor();
        }

        //Logika poruszania się po MENU
        public int Control()
        {
            ConsoleKey key;
            bool isWrongKey = false;

            do
            {
                Console.Clear();
                ShowOptions();

                
                if (isWrongKey)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zły przycisk");
                }

                isWrongKey = false;
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (SelectedId == 0)
                        SelectedId = Options.Length - 1;
                    else
                        SelectedId--;
                }

                else if (key == ConsoleKey.DownArrow)
                {
                    if (SelectedId == Options.Length - 1)
                        SelectedId = 0;
                    else
                    SelectedId++;
                }
                else
                    isWrongKey = true;

            }
            while (key != ConsoleKey.Enter);

            return SelectedId;
        }

    }
}
