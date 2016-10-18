using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvConvertExample
{
    public class AddressOrder : Interfaces.IOrderByAddress<Object>
    {
        #region Implementation of IOrderByAddress<object>

        public List<object> OrderByAddress(List<object> list) {
            return null;
        }

        #endregion
    }
}
