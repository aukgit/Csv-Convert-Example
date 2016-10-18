using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvConvertExample
{
    public class OrderByAddress : CsvConvertExample.Interfaces.IOrderByAddress<System.Object>
    {
        #region IOrderByAddress<object> Members

        public List<object> OrderByName()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
