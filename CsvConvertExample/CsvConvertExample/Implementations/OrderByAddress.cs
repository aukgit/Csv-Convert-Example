#region using block

using System.Collections.Generic;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations
{
    public class AddressOrder : IOrderByAddress<object>
    {
        #region Implementation of IOrderByAddress<object>

        public List<object> OrderByAddress(List<object> list)
        {
            return null;
        }

        #endregion
    }
}