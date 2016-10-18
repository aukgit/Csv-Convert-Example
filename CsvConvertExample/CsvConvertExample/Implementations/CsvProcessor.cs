using System;
using System.Collections.Generic;
using CsvConvertExample.Interfaces;

namespace CsvConvertExample.Implementations {
    public class CsvProcessor<T> : IFileWriter<T>, ICsvReader<T>, IProcessCsv<T>, IProcessByAddress<T>, IProcessByName<T>
    {
        #region IFileWriter Members

        public void WriteToFile(List<T> list) {
            throw new NotImplementedException();
        }

        #endregion

        #region ICsvReader Members

        public List<T> ReadCsv() {
            throw new NotImplementedException();
        }

        #endregion

        #region IProcessCsv Members

        public List<T> ProcessCsv()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IProcessByAddress<T> Members

        public List<T> ProcessByAddress()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IProcessByName<T> Members

        public List<T> ProcessByname()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
