using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Prompt;
internal static class CardView
{
    internal static void Prompt()
    {
        Console.Clear();
        Console.WriteLine("*****************************************************************");
        Console.WriteLine("***********************   View  Cards   *************************");
        Console.WriteLine("*****************************************************************");
        Console.WriteLine();
        Console.WriteLine("[Press any key to continue]");
        Console.ReadLine();
        MainMenu.Prompt();
    }
}
