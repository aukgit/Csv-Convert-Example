#region using block

using System;
using System.Collections.Generic;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations
{
    public class CsvProcessor<T> : IFileWriter<T>, ICsvReader<T>, IProcessCsv<T>, IOrderByAddress<T>, IOrderByName<T>
    {
        #region IFileWriter Members

        public void WriteToFile(List<T> list)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICsvReader Members

        public List<T> ReadCsv(string filePath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IProcessCsv Members

        public void ProcessCsv(List<T> list)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IOrderByAddress<T>

        public List<T> OrderByAddress(List<T> list)
        {
            return null;
        }

        #endregion

        #region Implementation of IOrderByName<T>

        public List<T> OrderByName(List<T> list)
        {
            return null;
        }

        #endregion
    }
}