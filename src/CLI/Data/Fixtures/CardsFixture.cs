using CardCollector.CLI.Data.Records;
using CardCollector.CLI.Entities;
using CardCollector.CLI.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Data.Fixtures;
public static class CardsFixture
{
    private const string path = "./Data/Store/";

    public static IEnumerable<Card> GetBySet(Set set)
    {
        var cards = new List<Card>();
        var fileName = GetFileName(
            set.Year, set.Name, set.SubsetName, set.Sport);
        try
        {
            using StreamReader reader = new StreamReader(path + fileName);
            var json = reader.ReadToEnd();
            var records = JsonConvert
                .DeserializeObject<IEnumerable<CardRecord>>(json)
                ?? new List<CardRecord>();
            foreach (var record in records)
            {
                cards.Add(new Card(record));
            }

        }
        catch
        {
            File.Create(path + fileName).Close();
        }
        
        return cards; 
    }

    public static int Save(Card card)
    {
        var fileName = GetFileName(
            card.Year, 
            card.SetName, 
            card.SubSetName, 
            card.Sport);
        
        card.Id = IdTableFixture.GetNextCardId();
        
        var set = GetBySet(new Set(
            card.Year, 
            card.SetName, 
            card.SubSetName, 
            card.Sport)).ToList();
        
        set.Add(card);

        var json = JsonConvert.SerializeObject(set);
        using StreamWriter writer = new StreamWriter(path + fileName);
        writer.Write(json);
        return card.Id;
    }

    private static string GetFileName(
        int year, 
        string set, 
        string? subset, 
        Sport sport)
    {
        var fileNameBuilder = new StringBuilder($"{year}_{set}_");
        if (!string.IsNullOrWhiteSpace(subset))
        {
            fileNameBuilder.Append($"{subset}_");
        }

        fileNameBuilder.Append($"{sport}");

        return fileNameBuilder.ToString();
    }

}
