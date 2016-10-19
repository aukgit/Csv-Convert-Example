#region using block

using System;
using System.Collections.Generic;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces.FileIO;
using CsvConvertExample.Interfaces.Formatter;
using CsvConvertExample.Interfaces.OrderFilters;
using Ninject;

#endregion

namespace CsvConvertExample.Implementations
{
    public class CsvProcessor
    {
        [Inject]
        public ICsvReader<Person> CsvReader { get; set; }

        [Inject]
        public IOrderFilterByName<Person, PeopleOrderByNameFrequency> NameFrequencyFilter { get; set; }

        [Inject]
        public IOrderFilterByAddress<Person, Person> AddressOrderFilter { get; set; }

        [Inject]
        public IFileWriter FileWriter { get; set; }

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
                Console.WriteLine("\"" + filePath + "\" file has been written successfully.");
            }

            return result;
        }

        #endregion
    }
}