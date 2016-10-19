#region using block

using System;
using System.IO;
using System.Threading;
using CsvConvertExample.Interfaces.FileIO;

#endregion

namespace CsvConvertExample.Implementations.FileIO
{
    public class CsvFileWriter : IFileWriter
    {
        #region Implementation of IFileWriter

        /// <summary>
        ///     Handle file writing using mutex and always overwrite.
        /// </summary>
        /// <param name="filepath">Give absolute file path. Throws exception if path is not valid.</param>
        /// <param name="content">Pass string content which should be written in file.</param>
        /// <returns>Returns true if writing is successful.</returns>
        public bool Write(string filepath, string content)
        {
            try
            {
                using (var mutex = new Mutex(false, "CSV-Processor" + filepath))
                {
                    mutex.WaitOne();
                    File.WriteAllText(filepath, content);
                    mutex.ReleaseMutex();
                }
            } catch (Exception ex)
            {
                throw ex;
                return false;
            }

            return true;
        }

        #endregion
    }
}