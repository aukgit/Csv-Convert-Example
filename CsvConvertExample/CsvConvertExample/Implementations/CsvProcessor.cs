using System;
using System.Collections.Generic;
using CsvConvertExample.Interfaces;

namespace CsvConvertExample.Implementations {
    public class CsvProcessor<T> : 
        IFileWriter<T>, 
        ICsvReader<T>, 
        IProcessCsv<T>, 
        IOrderByAddress<T>, 
        IOrderByName<T>
    {
        #region IFileWriter Members

        public void WriteToFile(List<T> list) {
            throw new NotImplementedException();
        }

        #endregion

        #region ICsvReader Members

        public List<T> ReadCsv(string filePath) {
            throw new NotImplementedException();
        }

        #endregion

        #region IProcessCsv Members

        public void ProcessCsv(List<T> list)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IOrderByAddress<T> Members

        public List<T> OrderByName()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IOrderByName<T> Members

        public List<T> OrderByName()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
