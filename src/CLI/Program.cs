using CardCollector.CLI.Data.Records;
using Newtonsoft.Json;

namespace CardCollector.CLI;

// TODO: Sport not being assigned to set file name
// TODO: Replace spaces with underscores in file names
// TODO: Sports other than baseball not showing up in sets list

public static class Program
{
    public static void Main(string[] args)
    {
        // EnsureFileLocations();
        MainMenu.Prompt();
    }

    private static void EnsureFileLocations()
    {
        const string root = "./Data/Store";
        
        const string idTable = "/idTable.json";
        if(!File.Exists(root + idTable)) 
        {
            var idRec = new IdTableRecord(0, 0);
            var idRecJson = JsonConvert.SerializeObject(idRec);
            using StreamWriter writer = new StreamWriter(root + idTable);
            writer.Write(idRecJson);
        }

        const string setsTable = "/sets.json";
        if (!File.Exists(root + setsTable))
        {
            File.Create(root + setsTable);
        }
    }
}