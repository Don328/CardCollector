using CardCollector.CLI.Data.Fixtures;
using CardCollector.CLI.Entities;
using CardCollector.CLI.Enums;

namespace CardCollector.CLI.Prompt;
internal static class CardCreate
{
    internal static void Prompt()
    {
        Console.Clear();
        Console.WriteLine("*****************************************************************");
        Console.WriteLine("********************   Create  New  Card   **********************");
        Console.WriteLine("*****************************************************************");
        Console.WriteLine();

        var set = SetPrompt.Prompt();
        var firstName = PromptForFirstName();
        var lastName = PromptForLastName();
        var insert = PromptForInsertName();
        var numInSet = PromptForNumberInSet();

        var card = new Card(
            firstName,
            lastName,
            insert,
            numInSet,
            set);

        CardsFixture.Save(card);
        MainMenu.Prompt();
    }

    private static string PromptForInsertName()
    {
        Console.WriteLine();
        Console.WriteLine("If the card is part of an insert, enter the insert name.");
        Console.WriteLine("Leave blank if the card is part of the base set");
        var response = Console.ReadLine()?? "";
        return response;
    }

    private static string PromptForFirstName()
    {
        Console.WriteLine("Enter the player's first name");
        var response = Console.ReadLine() ?? string.Empty;
        if (response == String.Empty)
        {
            Console.WriteLine();
            Console.WriteLine("You must enter a first name for the player on the card");
            Console.WriteLine();
            return PromptForFirstName();
        }

        return response;
    }

    private static string PromptForLastName() 
    {
        Console.WriteLine();
        Console.WriteLine("Enter the player's last name. Include any suffexes such as Jr, III, etc.");
        var response = Console.ReadLine() ?? string.Empty;
        if (response == String.Empty)
        {
            Console.WriteLine();
            Console.WriteLine("You must enter a last name for the player on the card");
            Console.WriteLine();
            return PromptForFirstName();
        }

        return response;
    }

    private static string PromptForNumberInSet()
    {
        Console.WriteLine();
        Console.WriteLine("Enter the cards number from the set");
        var response = Console.ReadLine() ?? string.Empty;
        return response;
    }
}
