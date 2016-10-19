#region using block

using System;
using System.Collections.Generic;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations
{
    public class PersonNameFrequencyWriteAsCsv : IFileWriter<object>
    {
        #region IFileWriter<object> Members

        public bool Write(List<object> list, string[] propertise, string filepath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}