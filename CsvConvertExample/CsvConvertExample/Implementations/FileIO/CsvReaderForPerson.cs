#region using block

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces.FileIO;
using CsvConvertExample.Interfaces.Formatter;
using Ninject;

#endregion

namespace CsvConvertExample.Implementations.FileIO
{
    public class CsvReaderForPerson : ICsvReader<Person>
    {
        private static readonly object SyncRoot = new object();

        [Inject]
        public IStreetAddressExtractor StreetAddressExtractor { get; set; }

        #region Implementation of ICsvReader<Person>

        public List<Person> ReadCsv(string filePath)
        {
            List<Person> people;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            lock (SyncRoot)
            {
                try
                {
                    using (var mutex = new Mutex(true, "CSV-Processor"))
                    {
                        const int bufferSize = 1024;
                        mutex.WaitOne();
                        using (var fileStream = File.OpenRead(filePath))
                        {
                            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
                            {
                                int index = 0;
                                string line;
                                people = new List<Person>(80000);

                                // TODO : We could have read the properties from reflection
                                // however would be an overkill for now.
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                    // Process line
                                    if (index >= 1)
                                    {
                                        var fields = line.Split(',');
                                        var person = new Person
                                        {
                                            FirstName = fields[0],
                                            LastName = fields[1],
                                            Address = fields[2],
                                            PhoneNumber = long.Parse(fields[3]) // we can keep it as string as well , because there is no processing.
                                        };
                                        person.StreetAddress = StreetAddressExtractor.ExtractStreetAddress(person.Address);
                                        people.Add(person);
                                    }

                                    index++;
                                }
                            }
                        }

                        mutex.ReleaseMutex();
                    }
                } catch (Exception ex)
                {
                    // TODO : handle the error.
                    // TODO : A logger should log the exception.
                    throw ex; // re-throwing the error
                }
            }

            return people;
        }

        #endregion
    }
}