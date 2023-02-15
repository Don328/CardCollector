using CardCollector.CLI.Data.Fixtures;
using CardCollector.CLI.Data.Records;
using CardCollector.CLI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Entities;
public class Card : IEntity<CardRecord>
{
    public Card(CardRecord record)
    {
        Id = record.Id;
        SetId = record.SetId;
        FirstName = record.FirstName;
        LastName = record.LastName;
        InsertName = record.InsertName;
        NumberInSet = record.NumberInSet;
        Grade = record.Grade;
        IsGraded = record.IsGraded;
        GetSetData();
    }

    public Card(
        string firstName,
        string lastName,
        string insertName,
        string numberInSet,
        Set set)
    {
        FirstName = firstName;
        LastName = lastName;
        NumberInSet = numberInSet;
        InsertName = insertName;
        SetId = set.Id;
        Year = set.Year;
        SetName = set.Name;
        SubSetName = set.SubsetName;
        Sport = set.Sport;
    }

    public int Id { get; set; }
    public int SetId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? InsertName { get; set; }
    public string NumberInSet { get; set; }
    public Sport Sport { get; set; }
    public string SetName { get; set; } = string.Empty;
    public string? SubSetName { get; set; }
    public int Year { get; set; }
    public float? Grade { get; set; }
    public bool IsGraded { get; set; }

    public CardRecord ToRecord()
    {
        return new CardRecord(
            Id: Id,
            SetId: SetId,
            FirstName: FirstName,
            LastName: LastName,
            InsertName: InsertName,
            NumberInSet: NumberInSet,
            Grade: Grade,
            IsGraded: IsGraded);
    }

    private void GetSetData()
    {
        var set = SetsFixture.GetById(SetId);
        Year = set.Year;
        SetName = set.Name;
        SubSetName = set.SubsetName;
        Sport = set.Sport;
    }
}
