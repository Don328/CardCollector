using CardCollector.CLI.Prompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI;
internal static class MainMenu
{
    internal static void Prompt()
    {
        Console.Clear();
        Console.WriteLine("*****************************************************************");
        Console.WriteLine("*************   Welcome   to   Card   Collector   ***************");
        Console.WriteLine("*****************************************************************");
        Console.WriteLine();
        Console.WriteLine("  c     comparisons    Add comparison card examples");
        Console.WriteLine("  n     new-card       Add a new card to the inventory");
        Console.WriteLine("  v     view-sets      Display a list of sets with cards in the inventory");
        Console.WriteLine("  x     exit           Exit the program");
        Console.WriteLine();
        var response = Console.ReadLine()?? "";

        switch(response)
        {
            case "c" or "comparisons":
                ComparisonCardPrompt.Prompt();
                break;
            case "n" or "new-card":
                CardCreate.Prompt();
                break;
            case "v" or "view-sets":
                SetViewMenu.Prompt();
                break;
            case "x" or "exit":
                break;
            default:
                Prompt();
                break;
        }
    }
}
