#region using block

using System;
using System.Collections.Generic;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations
{
    public class PersonNameFrequencyCsvWriter : IFileWriter<PeopleOrderByNameFrequency>
    {
        #region IFileWriter<object> Members

        public bool Write(List<PeopleOrderByNameFrequency> list, string filepath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}