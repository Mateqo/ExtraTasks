using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MateuszBartkowiakBayt
{
    public class Fibonacci
    {
        async public Task DisplayFib()
        {
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
            if (InputValidation(n))
            {
                //Wyświetlenie wszystkich liczb ciągu
                for (int i = 0; i < Convert.ToInt32(n); i++)
                {                                      
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"F({i})= {await Fib(i)}");
                }
            }
        }

        public async Task<ulong> Fib(int n)
        {
            ulong firstNumber = 0;
            ulong secondNumber = 1;

            for (int i = 0; i < n; i++)
            {
                ulong tmp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = tmp + secondNumber;
            }

            //Sztuczne wymuszenie oczekiwania
            await Task.Delay(500);

            return firstNumber;
        }

        async public Task PrintTimer(CancellationToken token)
        {
            do
            {
                //Sztuczne wymuszenie oczekiwania
                await Task.Delay(3000);              
                Console.ForegroundColor = ConsoleColor.Yellow;

                //Gdy anulujemy Taska
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"Odliczanie zakończone : {DateTime.Now.ToLongTimeString()}");
                    token.ThrowIfCancellationRequested();
                }

                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Console.ResetColor();
            } while (true);
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
