using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvConvertExample.Interfaces;

namespace CsvConvertExample.Implementations.FileIO
{
    public class CsvFileWriter : IFileWriter
    {
        #region Implementation of IFileWriter

        public bool Write(string filepath, string content)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
                return false;
            }
            return true;
        }

        #endregion
    }
}
