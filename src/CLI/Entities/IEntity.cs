using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollector.CLI.Entities;
public interface IEntity<T> where T : class
{
    T ToRecord();
}
