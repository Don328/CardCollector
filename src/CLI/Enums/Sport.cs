using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Enums;

/*
 * Add new values to the middle of the enum list.
 * 'None' must remain the last value in the list.
 * Violating this will cause breaking changes as 'None'
 * is used to index the last value in the list for iteration
 * purposes.
 */

public enum Sport
{
    Baseball,
    Basketball,
    Football,
    Golf,
    Hockey,
    None
}
