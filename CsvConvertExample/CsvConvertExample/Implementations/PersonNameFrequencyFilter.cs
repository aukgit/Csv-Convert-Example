#region using block

using System.Collections.Generic;
using System.Linq;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations
{
    /// <summary>
    /// People list filter by frequency and then alphabetically.
    /// </summary>
    public class PersonNameFrequencyFilter : IOrderFilterByName<Person, PeopleOrderByNameFrequency>
    {
        #region Implementation of IOrderFilterByName<Person,PeopleOrderByNameFrequency>

        /// <summary>
        /// Get people ordered by frequency and then alphabetically. 
        /// First it will get the high occurrence and then based on that alphabetical order by First name and then last name.
        /// </summary>
        /// <param name="people">Give list of person.</param>
        /// <returns>Returns list of person ordered by frequency and then alphabetically. </returns>
        public List<PeopleOrderByNameFrequency> OrderFilterByName(List<Person> people)
        {
            var result = people.GroupBy(person => new NameProperty()
            {
                FirstName = person.FirstName,
                LastName = person.LastName
            })
            .Select(group => new PeopleOrderByNameFrequency()
            {
                People = group,
                Count = group.Count()
            })
            .OrderByDescending(group => group.Count)
            .ThenBy(group => group.People.Key.FirstName)
            .ThenBy(group => group.People.Key.LastName)
            .ToList();

            return result;
        }

        #endregion
    }
}