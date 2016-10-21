#region using block

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CsvConvertExample.DataLayer
{

    public class PeopleGroupCollector
    {
        public NameProperty NameProperty { get; set; }
        public int Count { get; set; }
    }

    public class PeopleOrderByNameFrequency
    {
        public List<PeopleGroupCollector> People { get; set; }
    }
}