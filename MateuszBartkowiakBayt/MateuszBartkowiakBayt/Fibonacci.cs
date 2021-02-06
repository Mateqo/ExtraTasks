using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MateuszBartkowiakBayt
{
    public class Fibonacci
    {
        public string AllNumberFibonacci { get; set; }

        public string DisplayFib()
        {
            AllNumberFibonacci = "Otrzymane wyniki: ";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(UiText.titleMain);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("Ciąg Fibonacciego");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.Write("Ile chcesz wypisać liczb ciągu Fibonacciego: ");
            Console.ForegroundColor = ConsoleColor.White;
            string n = Console.ReadLine();

            //Walidacja n czy jest liczbą
            if (!InputValidation(n))
                return $"'{n}' nie jest prawidłowym formatem";


            //Wyświetlenie wszystkich liczb ciągu
            for (int i = 0; i < Convert.ToInt32(n); i++)
            {
                int tmp = Fib(i).Result;
                Console.SetCursorPosition(5, Console.CursorTop);

                //Jeśli ostatnia pętla
                if (i == (Convert.ToInt32(n) - 1))
                    AllNumberFibonacci += $"F({i})= " + tmp;
                else
                    AllNumberFibonacci += $"F({i})= " + tmp + " ; ";

                Console.WriteLine($"F({i})= {tmp}");
            }

            //Zwracamy string ze wszystkimi liczbami w celu dalszego przesłania do MENU jako title
            return AllNumberFibonacci;
        }

        public async Task<int> Fib(int n)
        {
            int FirstNumber = 0;
            int SecondNumber = 1;

            for (int i = 0; i < n; i++)
            {
                int tmp = FirstNumber;
                FirstNumber = SecondNumber;
                SecondNumber = tmp + SecondNumber;
            }

            //Sztuczne wymuszenie oczekiwania
            await Task.Delay(3000);

            return FirstNumber;
        }

        public bool InputValidation(string text)
        {
            //Wyrażenie regularne definiujące: tylko liczby większe od 0
            string pattern = @"^[1-9][0-9]*$";
            Regex rgx = new Regex(pattern);

            return rgx.IsMatch(text);
        }
    }
}
