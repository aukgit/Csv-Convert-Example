#region using block

using System;
using System.Collections.Generic;
using System.Text;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces.Formatter;

#endregion

namespace CsvConvertExample.Implementations.Formatters
{
    public class PersonStreetAddressFormatterForCsv : IPersonStreetAddressFormatterForCsv<Person>
    {
        #region Implementation of IStringFormatter<PeopleOrderByNameFrequency>

        public string GetFormattedStringFor(List<Person> people)
        {
            string spliter = ",";
            var sb = new StringBuilder((people.Count * 5) + 5);

            // ToDo : use string.format
            sb.AppendLine("StreetAddress" + spliter + "Address" + spliter + "FirstName" + spliter + "LastName");
            foreach (var person in people)
            {
                // ToDo : use string.format
                sb.AppendLine(person.StreetAddress + spliter + person.Address + spliter + person.FirstName + spliter + person.LastName);
            }

            var result = sb.ToString();
            sb = null;
            GC.Collect();
            return result;
        }

        #endregion
    }
}