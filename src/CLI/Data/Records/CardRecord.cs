using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Data.Records;
public record CardRecord(
    int Id,
    int SetId,
    string FirstName,
    string LastName,
    string? InsertName,
    string NumberInSet,
    float? Grade,
    bool IsGraded);
