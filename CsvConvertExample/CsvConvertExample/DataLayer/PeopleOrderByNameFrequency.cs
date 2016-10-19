using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConvertExample.DataLayer
{
    public class PeopleOrderByNameFrequency
    {
        public IGrouping<NameProperty, Person> People { get; set; }
        public int Count { get; set; }
    }
}
