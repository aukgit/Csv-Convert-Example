using System;
using CsvConvertExample.Interfaces;

namespace CsvConvertExample.Implementations {
    public class CsvProcessor : IFileWriter, ICsvReader, ICsvParser {
        #region IFileWriter Members

        public void WriteToFile() {
            throw new NotImplementedException();
        }

        #endregion

        #region ICsvReader Members

        public void ReadCsv() {
            throw new NotImplementedException();
        }

        #endregion

        #region ICsvParser Members

        public void ParseCsv() {
            throw new NotImplementedException();
        }

        #endregion
    }
}
