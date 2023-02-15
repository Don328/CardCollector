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
public class SetsFixture
{
    private const string path =
        "./Data/Store/sets.json";

    public static IEnumerable<Set> GetAll()
    {
        using StreamReader reader = new StreamReader(path);
        var json = reader.ReadToEnd();
        
        var records = JsonConvert
            .DeserializeObject<IEnumerable<SetRecord>>(json)
            ?? new List<SetRecord>();
        
        var sets = new List<Set>();
        foreach(var record in records.ToList())
        {
            sets.Add(new Set(record));
        }

        return sets;
    }

    public static int Save(Set set)
    {
        if (SetExists(set, out int setId)) return setId;
        set.Id = IdTableFixture.GetNextSetId();
        var sets = GetAll().ToList();
        sets.Add(set);

        var json = JsonConvert.SerializeObject(sets);
        using StreamWriter writer = new StreamWriter(path);
        writer.Write(json);

        return set.Id;
    }

    public static Set GetById(int setId)
    {
        var sets = GetAll();
        return (from s in sets
                where s.Id == setId
                select s).First();
    }

    private static bool SetExists(Set set, out int id)
    {
        var sets = GetAll();
        foreach (var existingSet in sets)
        {
            if (set.Year == existingSet.Year
                && set.Name == existingSet.Name
                && set.SubsetName == existingSet.Name
                && set.Sport == existingSet.Sport)
            {
                id = existingSet.Id;
                return true;
            }
        }

        id = -1;
        return false;
    }
}
