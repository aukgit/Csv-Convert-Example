using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces.FileIO;

namespace CsvConvertExample.Implementations.FileIO
{
    public class CsvReaderForPeople : ICsvReader<Person>
    {
        #region Implementation of ICsvReader<Person>

        public List<Person> ReadCsv(string filePath)
        {
            List<Person> people;
            try
            {
                using (var mutex = new Mutex(false, "CSV-Processor-" + filePath))
                {
                    const int bufferSize = 1024;
                    mutex.WaitOne();
                    using (var fileStream = File.OpenRead(filePath))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
                    {
                        int index = 0;
                        string line;
                        people = new List<Person>(80000);
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            // Process line
                            if (index >= 1)
                            {
                                var fields = line.Split(',');
                                var person = new Person()
                                {
                                    FirstName = fields[0],
                                    LastName = fields[1],
                                    Address = fields[2],
                                    PhoneNumber = long.Parse(fields[3]), // we can keep it as string as well , because there is no processing.
                                };
                                person.StreetAddress = ExtractStreetAddressFromAddress(person.Address);
                                people.Add(person);
                            }

                            index++;
                        }
                    }

                    mutex.ReleaseMutex();
                }
            }
            catch (Exception ex)
            {
                // TODO : handle the error.
                // TODO : A logger should log the exception.
                throw; // re-throwing the error
                return null;
            }

            return people;
        }
      
        #endregion

        private string ExtractStreetAddressFromAddress(string address)
        {
            if (address != null)
            {
                var spaceIndex = address.IndexOf(" ", StringComparison.Ordinal);
                return address.Substring(spaceIndex + 1);
            }

            return string.Empty;
        }
    }
}
