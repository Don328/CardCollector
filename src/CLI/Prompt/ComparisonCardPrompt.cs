using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Prompt;
internal static class ComparisonCardPrompt
{
    internal static void Prompt()
    {
        Console.Clear();
        Console.WriteLine("*****************************************************************");
        Console.WriteLine("****************   Create  Comparison  Card   *******************");
        Console.WriteLine("*****************************************************************");
        Console.WriteLine();
        Console.WriteLine("[Press any key to continue]");
        Console.ReadLine();
        MainMenu.Prompt();
    }
}
