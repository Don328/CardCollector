using CardCollector.CLI.Data.Fixtures;
using CardCollector.CLI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Prompt;
internal static class SetViewMenu
{
    internal static void Prompt()
    {
        Console.Clear();
        Console.WriteLine("*****************************************************************");
        Console.WriteLine("***********************   View  Sets   **************************");
        Console.WriteLine("*****************************************************************");
        Console.WriteLine();
        ShowSets();
    }

    private static void ShowSets()
    {
        var sets = SetsFixture.GetAll();

        foreach (var set in sets)
        {
            Console.WriteLine($"[Id: {set.Id}]    {set.Year} {set.Name} {set.SubsetName} {set.Sport}");
        }

        Console.WriteLine();
        Console.WriteLine("Enter the id number of the set to view the cards in the set.");
        Console.WriteLine("'m' for main menu");
        var response = Console.ReadLine() ?? "";
        if (string.IsNullOrEmpty(response)) ShowSets();
        if (response.ToLower() == "m") MainMenu.Prompt();
        try
        {
            var success = Int32.TryParse(response, out int setId);
            var set = SetsFixture.GetById(setId);
            ViewSet(set);
        }
        catch
        {
            ShowSets();
        }
    }

    private static void ViewSet(Set set)
    {
        var cards = CardsFixture.GetBySet(set).ToList();

        Console.Clear();
        Console.WriteLine("********************************************************");
        Console.WriteLine($"{set.Year} {set.Name} {set.SubsetName} {set.Sport}");
        Console.WriteLine("********************************************************");
        foreach (var card in cards)
        {
            Console.WriteLine($"[id:{card.Id}]    {card.NumberInSet} - {card.FirstName} {card.LastName}");
        }
        Console.WriteLine();
        EndPrompt();
    }

    private static void EndPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("'m' for main menu");
        Console.WriteLine("'v' to view sets");
        var response = Console.ReadLine()?? "";

        switch(response.ToLower())
        {
            case "m":
                MainMenu.Prompt();
                break;
            case "v":
                Prompt();
                break;
            default:
                EndPrompt();
                break;
        }
    }
}
