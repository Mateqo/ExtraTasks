using System;
using System.Collections.Generic;
using System.Linq;
namespace MateuszBartkowiakBayt
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu mainMenu = new Menu("Menu:", UiText.mainOptions);

            while (true)
            {
                int selectedId = mainMenu.Control();

                switch (selectedId)
                {
                    case 0:
                        bool isReturnFromCompare = true;
                        CompareText compareText = new CompareText();
                        Menu compareTextMenu = new Menu(compareText.Compare(), UiText.compareTextOptions);

                        while (isReturnFromCompare)
                        {
                            switch (compareTextMenu.Control())
                            {
                                case 0:
                                    compareTextMenu.Title = compareText.Compare();
                                    break;
                                case 1:
                                    isReturnFromCompare = false;
                                    break;
                            }
                        }
                        break;
                    case 1:
                        bool isReturnFromFib = true;
                        Fibonacci fibonacci = new Fibonacci();
                        Menu fibonacciMenu = new Menu(fibonacci.DisplayFib(), UiText.compareTextOptions);

                        while (isReturnFromFib)
                        {
                            switch (fibonacciMenu.Control())
                            {
                                case 0:
                                    fibonacciMenu.Title = fibonacci.DisplayFib();
                                    break;
                                case 1:
                                    isReturnFromFib = false;
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }

        }
    }
}
