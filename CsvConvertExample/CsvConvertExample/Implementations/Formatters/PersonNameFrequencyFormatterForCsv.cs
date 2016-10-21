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
    /// <summary>
    /// Format person's name frequency list.
    /// </summary>
    public class PersonNameFrequencyFormatterForCsv : IPersonNameFrequencyFormatterForCsv<PeopleOrderByNameFrequency>
    {
        #region Implementation of IStringFormatter<PeopleOrderByNameFrequency>

        public string GetFormattedStringFor(List<PeopleOrderByNameFrequency> peopleOrderByNameFrequencies)
        {
            string spliter = ",";
            var sb = new StringBuilder((peopleOrderByNameFrequencies.Count * 5) + 5);

            // TODO : use string.format
            sb.AppendLine("FirstName" + spliter + "LastName" + spliter + "Frequency");
            foreach (var peopleGroup in peopleOrderByNameFrequencies)
            {
                foreach (var people in peopleGroup.People)
                {
                    var person = people.NameProperty;

                    // TODO : use string.format
                    if (person != null)
                    {
                        sb.AppendLine(person.FirstName + spliter + person.LastName + spliter + people.Count);
                    }
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