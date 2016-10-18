#region using block

using System.Collections.Generic;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations
{
    public class PersonAddressOrderFilter : IOrderByAddress<Person>
    {
        #region Implementation of IOrderByAddress<object>

        public List<Person> OrderByAddress(List<Person> list)
        {
            return null;
        }

        #endregion
    }
}