using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvConvertExample.Interfaces;

namespace CsvConvertExample
{
    public class NameFrequency<T> : Interfaces.IOrderByName<T>
    {
        #region IOrderByName<object> Members

        public List<T> OrderByName(List<T> list)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
