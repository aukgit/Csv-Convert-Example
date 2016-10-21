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
        private static readonly object SyncRoot = new object();

        #region Implementation of IFileWriter

        /// <summary>
        ///     Handle file writing using mutex and always overwrite.
        /// </summary>
        /// <param name="filepath">Give absolute file path. Throws exception if path is not valid.</param>
        /// <param name="content">Pass string content which should be written in file.</param>
        /// <returns>Returns true if writing is successful.</returns>
        public bool Write(string filepath, string content)
        {
            lock (SyncRoot)
            {
                try
                {
                    using (var mutex = new Mutex(true, "CSV-Processor"))
                    {
                        mutex.WaitOne();
                        File.WriteAllText(filepath, content);
                        mutex.ReleaseMutex();
                    }
                } 
                catch (Exception ex)
                {
                    // TODO : handle the error.
                    // TODO : A logger should log it;
                    Console.WriteLine("- Error occurred during file writing : " + filepath);
                    throw; // re-throwing the error
                }
            }

            return true;
        }

        #endregion
    }
}