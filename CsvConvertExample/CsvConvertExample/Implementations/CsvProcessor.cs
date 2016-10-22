#region using block

using System;
using System.Collections.Generic;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces.FileIO;
using CsvConvertExample.Interfaces.Formatter;
using CsvConvertExample.Interfaces.OrderFilters;

#endregion

namespace CsvConvertExample.Implementations
{
    public class CsvProcessor
    {
        public CsvProcessor(ICsvReader<Person> csvReader, IOrderFilterByName<Person, PeopleOrderByNameFrequency> nameFrequencyFilter, IOrderFilterByAddress<Person, Person> addressOrderFilter, IFileWriter fileWriter)
        {
            CsvReader = csvReader;
            NameFrequencyFilter = nameFrequencyFilter;
            AddressOrderFilter = addressOrderFilter;
            FileWriter = fileWriter;
        }

        public ICsvReader<Person> CsvReader { get; private set; }
        public IOrderFilterByName<Person, PeopleOrderByNameFrequency> NameFrequencyFilter { get; private set; }
        public IOrderFilterByAddress<Person, Person> AddressOrderFilter { get; private set; }
        public IFileWriter FileWriter { get; private set; }

        #region ICsvReader Members

        public List<Person> ReadCsv(string filePath)
        {
            return CsvReader.ReadCsv(filePath);
        }

        #endregion

        #region Implementation of IOrderFilterByAddress<T,T2>

        public List<Person> OrderFilterByAddress(List<Person> people)
        {
            return AddressOrderFilter.OrderFilterByAddress(people);
        }

        #endregion

        #region Implementation of IOrderFilterByName<T,T2>

        public List<PeopleOrderByNameFrequency> OrderFilterByName(List<Person> people)
        {
            return NameFrequencyFilter.OrderFilterByName(people);
        }

        #endregion

        #region Implementation of ICsvWriter<T>

        public bool WriteAsCsvFile<TType>(List<TType> list, IStringFormatter<TType> formatter, string filePath) where TType : class, new()
        {
            var result = FileWriter.Write(filePath, formatter.GetFormattedStringFor(list));
            if (result)
            {
                Console.WriteLine("- [Written Successfully] : \"" + filePath + "\".");
            }

            return result;
        }

        #endregion
    }
}