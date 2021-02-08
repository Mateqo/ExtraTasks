using System;
using System.Threading;
using System.Threading.Tasks;

namespace MateuszBartkowiakBayt
{
    class Program
    {

        async static Task Main(string[] args)
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
                        Fibonacci fibonacci = new Fibonacci();
                        //Token potrzebny do anulowania Taska
                        var ts = new CancellationTokenSource();
                        var ct = ts.Token;
                        
                        try
                        {
                            //Tworzymy Taski, gdy jeden się wykona anuluj odliczanie
                            var fibonacciTask = fibonacci.DisplayFib();                           
                            var timerTask = Task.Run(() => fibonacci.PrintTimer(ct));

                            await Task.WhenAny(timerTask, fibonacciTask);
                            ts.Cancel();
                        }
                        catch (OperationCanceledException ex)
                        {
                            Console.WriteLine($"Błąd : {ex}");
                        }
                        finally
                        {
                            ts.Dispose();                           
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
