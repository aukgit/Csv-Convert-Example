#region using block

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces.Formatter;

#endregion

namespace CsvConvertExample.Implementations.Formatters
{
    public class PersonNameFrequencyFormatterForCsv : IPersonNameFrequencyFormatterForCsv<PeopleOrderByNameFrequency>
    {
        #region Implementation of IStringFormatter<PeopleOrderByNameFrequency>

        public string GetFormattedStringFor(List<PeopleOrderByNameFrequency> names)
        {
            string spliter = ",";
            var sb = new StringBuilder((names.Count * 5) + 5);

            // ToDo : use string.format
            sb.AppendLine("FirstName" + spliter + "LastName" + spliter + "Frequency");
            foreach (var name in names)
            {
                foreach (var person in name.People)
                {
                    // ToDo : use string.format
                    sb.AppendLine(person.FirstName + spliter + person.LastName + spliter + name.Count);
                }
            }

            var result = sb.ToString();
            sb = null;
            GC.Collect();
            return result;
        }

        #endregion
    }
}