using CardCollector.CLI.Data.Records;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Data.Fixtures;
internal static class IdTableFixture
{
    private const string path = "./Data/Store/idTable.json";

    public static int GetNextCardId()
    {
        var existingRecord = GetRecord();

        var newRecord = new IdTableRecord(
            LastCardId: existingRecord.LastCardId + 1,
            LastSetId: existingRecord.LastSetId);

        Save(newRecord);
        return newRecord.LastCardId;
    }

    public static int GetNextSetId()
    {
        var existingRecord = GetRecord();

        var newRecord = new IdTableRecord(
            LastCardId: existingRecord.LastCardId,
            LastSetId: existingRecord.LastSetId + 1);

        Save(newRecord);
        return newRecord.LastSetId;
    }

    private static IdTableRecord GetRecord()
    {
        using StreamReader reader = new StreamReader(path);
        var json = reader.ReadToEnd();
        var table = JsonConvert.DeserializeObject<IdTableRecord>(json)?? new(-1, -1);
        return table;
    }

    private static void Save(IdTableRecord record)
    {
        var json = JsonConvert.SerializeObject(record);
        using StreamWriter writer = new StreamWriter(path);
        writer.Write(json);
    }
}
