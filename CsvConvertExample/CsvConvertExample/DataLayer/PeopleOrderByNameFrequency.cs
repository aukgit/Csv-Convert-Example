#region using block

using System.Linq;

#endregion

namespace CsvConvertExample.DataLayer
{
    public class PeopleOrderByNameFrequency
    {
        public IGrouping<NameProperty, Person> People { get; set; }
        public int Count { get; set; }
    }
}