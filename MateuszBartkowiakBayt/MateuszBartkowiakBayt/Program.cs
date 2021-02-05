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
                        bool isReturn = true;
                        CompareText compareText = new CompareText();
                        Menu compareTextMenu = new Menu(compareText.Compare(), UiText.compareTextOptions);

                        while (isReturn)
                        {
                            switch (compareTextMenu.Control())
                            {
                                case 0:
                                    compareTextMenu.Title = compareText.Compare();
                                    break;
                                case 1:
                                    isReturn = false;
                                    break;
                            }
                        }
                        break;
                    case 1:
                        Console.WriteLine("coś2");
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }

        }
    }
}
