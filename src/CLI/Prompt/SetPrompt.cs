using CardCollector.CLI.Data.Fixtures;
using CardCollector.CLI.Entities;
using CardCollector.CLI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Prompt;
internal static class SetPrompt
{
    internal static Set Prompt()
    {
        var year = PromptForYear();
        var setName = PromptForSetName();
        var subset = PromptForSubset();
        var sport = PromptForSport();

        var set = new Set(
            year: year,
            name: setName,
            subsetName: subset,
            sport: sport);

        var setId = SetsFixture.Save(set);
        set.Id = setId;
        return set;
    }

    private static int PromptForYear()
    {
        Console.WriteLine();
        Console.WriteLine("Enter the year of the set the card is from:");
        var response = Console.ReadLine() ?? "";
        var success = Int32.TryParse(response, out int result);

        if (success)
        {
            if (result > DateTime.Today.Year + 2)
            {
                Console.WriteLine("###########################################################################");
                Console.WriteLine("The year cannot be greater than two years beyond the current calendar year.");
                Console.WriteLine("###########################################################################");
                Console.WriteLine();
                success = false;
            }
            if (result < 1900)
            {
                Console.WriteLine("#################################");
                Console.WriteLine("The year cannot be less than 1900");
                Console.WriteLine("#################################");
                Console.WriteLine();
                success = false;
            }

        }

        if (!success) { PromptForYear(); }
        return result;
    }

    private static string PromptForSetName()
    {
        Console.WriteLine();
        Console.WriteLine("Enter the name of the set the card is from");
        var result = Console.ReadLine();

        if (result == null)
        {
            return PromptForSetName();
        }

        return result;
    }

    private static string? PromptForSubset()
    {
        Console.WriteLine();
        Console.WriteLine("Enter the subset name. Leave blank if the card is not part of a subset");
        var response = Console.ReadLine() ?? null;
        return response;
    }

    private static Sport PromptForSport()
    {
        Console.WriteLine();
        Console.WriteLine("***********************");
        Console.WriteLine("        Sports");
        Console.WriteLine("***********************");
        var lastValue = (int)Sport.None;
        for (int i = 0; i <= lastValue; i++)
        {
            Console.WriteLine($"{i}    {(Sport)i}");
        }
        Console.WriteLine();
        Console.WriteLine($"Enter the value for the sport (1-{lastValue}):");
        var response = Console.ReadLine();
        var success = Int32.TryParse(response, out var result);
        if (success)
        {
            if (result < 0) success = false;
            if (result > lastValue) success = false;
        }

        if (!success)
        {
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine($"Sport must be a value between 1 and {lastValue}");
            Console.WriteLine("########################################");
            return PromptForSport();
        }

        return (Sport)result;
    }
}
