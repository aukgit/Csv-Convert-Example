using System;
using System.Collections.Generic;
using CsvConvertExample.Interfaces;

namespace CsvConvertExample.Implementations {
    public class CsvProcessor<T> : IFileWriter<T>, ICsvReader<T>, ICsvParser<T>
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

        #region ICsvParser Members

        public List<T> ParseCsv()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
