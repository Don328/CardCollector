using CardCollector.CLI.Data.Records;
using CardCollector.CLI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Entities;
public class Set : IEntity<SetRecord>
{
    public Set(SetRecord record)
    {
        Id = record.Id;
        Year = record.Year;
        Name = record.Name;
        SubsetName = record.SubsetName;
        Sport = (Sport)record.SportIndex;
    }

    public Set(
        int year,
        string name,
        string? subsetName,
        Sport sport)
    {
        Year = year;
        Name = name;
        SubsetName = subsetName;
        Sport = sport;
    }

    public int Id { get; set; }
    public int Year { get; set; }
    public string Name { get; set; }
    public string? SubsetName { get; set; }
    public Sport Sport { get; set; }

    public SetRecord ToRecord()
    {
        return new SetRecord(
            Id: Id,
            Year: Year,
            Name: Name,
            SubsetName: SubsetName,
            SportIndex: (int)Sport);
    }
}
