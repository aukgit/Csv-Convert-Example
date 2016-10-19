#region using block

using System.Collections.Generic;
using System.Linq;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations
{
    public class PersonAddressOrderFilter : IOrderByAddress<Person>
    {
        #region Implementation of IOrderByAddress<object>

        public List<Person> OrderByAddress(List<Person> people)
        {
            var result = people.GroupBy(person => new NameProperty()
            {
                FirstName = person.FirstName,
                LastName = person.LastName
            }).Select(group => new PeopleOrderByNameFrequency()
            {
                People = group,
                Count = group.Count()
            }).ToList();
            return null;
        }

        #endregion
    }
}