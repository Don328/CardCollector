using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Data.Records;
public record SetRecord(
    int Id,
    int Year,
    string Name,
    string? SubsetName,
    int SportIndex);
