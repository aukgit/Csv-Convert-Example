#region using block

using System;
using System.Collections.Generic;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations
{
    public class NameFrequency<T> : IOrderByName<T>
    {
        #region IOrderByName<object> Members

        public List<T> OrderByName(List<T> list)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}