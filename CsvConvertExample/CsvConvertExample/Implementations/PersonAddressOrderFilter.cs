#region using block

using System.Collections.Generic;
using System.Linq;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations
{
    public class PersonAddressOrderFilter : IOrderFilterByAddress<Person, Person>
    {
        #region Implementation of IOrderByAddress<object>

        /// <summary>
        ///     Sort people list by street names alphabetically.
        /// </summary>
        /// <param name="people">A list of person</param>
        /// <returns>Returns a sorted person list alphabetically.</returns>
        public List<Person> OrderFilterByAddress(List<Person> people)
        {
            return people.OrderBy(person => person.StreetAddress).ToList();
        }

        #endregion
    }
}