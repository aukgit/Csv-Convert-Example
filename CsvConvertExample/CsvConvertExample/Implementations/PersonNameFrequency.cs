#region using block

using System;
using System.Linq;
using System.Collections.Generic;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations
{
    public class PersonNameFrequency : IOrderByName<Person>
    {
        #region IOrderByName<object> Members

        public List<Person> OrderByName(List<Person> people)
        {
            return people.GroupBy(person => new { person.FirstName, person.LastName })
                         .OrderBy(n => n.Key.FirstName)
                         .Select(p=> p.)
                         .ToList();
        }

        #endregion
    }
}