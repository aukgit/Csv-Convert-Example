#region using block

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces.OrderFilters;

#endregion

namespace CsvConvertExample.Implementations.OrderFilters
{
    /// <summary>
    ///     People list filter by frequency and then alphabetically.
    /// </summary>
    public class PersonNameFrequencyFilter : IOrderFilterByName<Person, PeopleOrderByNameFrequency>
    {
        #region Implementation of IOrderFilterByName<Person, PeopleOrderByNameFrequency>

        /// <summary>
        ///     Get people ordered by frequency and then alphabetically.
        ///     First it will get the high occurrence and then based on that alphabetical order by First name and then last name.
        /// </summary>
        /// <param name="people">Give list of person.</param>
        /// <returns>Returns list of person ordered by frequency and then alphabetically. </returns>
        public List<PeopleOrderByNameFrequency> OrderFilterByName(List<Person> people)
        {
            var result = people.Select(n => new NameProperty()
            {
                FirstName = n.FirstName,
                LastName = n.LastName
            })
                               .GroupBy(person => new
                               {
                                   person.FirstName,
                                   person.LastName
                               })
                               .Select(group => new PeopleGroupCollector()
                               {
                                   NameProperty = group.FirstOrDefault(),
                                   Count = group.Count()
                               })
                               .OrderByDescending(n => n.Count)
                               .ThenBy(n => n.NameProperty.FirstName)
                               .ThenBy(n => n.NameProperty.LastName)
                               .ToList();

            // just to keep consistency
            var finalizeResults = new List<PeopleOrderByNameFrequency>
            {
                new PeopleOrderByNameFrequency()
                {
                    People = result
                }
            };

            return finalizeResults;
        }

        #endregion
    }
}