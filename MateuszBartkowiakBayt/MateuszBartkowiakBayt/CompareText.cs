using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MateuszBartkowiakBayt
{
    public class CompareText
    {
        public string FirstText { get; set; }
        public string SecondText { get; set; }

        public string Compare()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;            
            Console.WriteLine(UiText.titleMain);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("Porównywanie ciągów znaków");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.Write("Wpisz pierwszy tekst: ");
            Console.ForegroundColor = ConsoleColor.White;
            FirstText = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.Write("Wpisz drugi tekst tekst: ");
            Console.ForegroundColor = ConsoleColor.White;
            SecondText = Console.ReadLine();


            string resultCompare = $@"Wynik porównywania '{FirstText}' z '{SecondText}' :

     Różnica w znakach: {CompareLength()}
     Czy teksty są identyczne: {IsTheSameText()}
     Czy pierwszy tekst jest palindronem: {IsPalindron(FirstText)}
     Czy drugi tekst jest palindronem: {IsPalindron(SecondText)}
     Czy teksty są anagramami: {IsAnagram()}
     Liczba samogłosek w pierwszy tekscie: {NumberOfVowels(FirstText)}
     Liczba samogłosek w drugim tekscie: {NumberOfVowels(SecondText)}
     Liczba wielkich liter w pierwszym tekscie: {NumberOfUppercaseLetter(FirstText)}
     Liczba wielkich liter w drugim tekscie: {NumberOfUppercaseLetter(SecondText)}
     Liczba małych liter w pierwszym tekscie: {NumberOfLowercaseLetter(FirstText)}
     Liczba małych liter w drugim tekscie: {NumberOfLowercaseLetter(SecondText)}
";
            return resultCompare;
        }

        public int CompareLength()
        {
            return Math.Abs(FirstText.Length - SecondText.Length);
        }

        public string IsTheSameText()
        {           
            return (FirstText.ToLower() == SecondText.ToLower()) ?"TAK":"NIE";
        }

        public string IsPalindron(string text)
        {           
            return text.ToLower().SequenceEqual(text.ToLower().Reverse())?"TAK":"NIE";
        }

        public string IsAnagram()
        {
            return String.Concat(FirstText.ToLower().OrderBy(x => x)).Equals(String.Concat(SecondText.ToLower().OrderBy(x => x))) ? "TAK" : "NIE";
        }

        public int NumberOfVowels(string text)
        {
            int total=0;

            foreach (char item in text.ToLower())
            {
                if (item == 'a' || item == 'ą' || item == 'e' || item == 'ę' || item == 'i' || item == 'o' || item == 'u' || item == 'y'|| item == 'ó')
                    total++;
            }

            return total;
        }

        public int NumberOfUppercaseLetter(string text)
        {
            return text.Count(x => char.IsUpper(x));
        }

        public int NumberOfLowercaseLetter(string text)
        {
            return text.Count(x => char.IsLower(x));
        }
    }
}
