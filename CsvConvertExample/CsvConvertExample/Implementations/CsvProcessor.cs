#region using block

using System;
using System.Collections.Generic;
using CsvConvertExample.Interfaces.FileIO;
using CsvConvertExample.Interfaces.Formatter;
using CsvConvertExample.Interfaces.OrderFilters;
using Ninject;

#endregion

namespace CsvConvertExample.Implementations
{
    public class CsvProcessor<T, T2> :
        ICsvReader<T>, IOrderFilterByAddress<T, T2>, IOrderFilterByName<T, T2>
        where T : class, new()
        where T2 : class, new()
    {
        [Inject]
        public ICsvReader<T> CsvReader { get; set; }

        [Inject]
        public IOrderFilterByAddress<T, T2> NameFrequencyFilter { get; set; }

        [Inject]
        public IOrderFilterByName<T, T2> AddressOrderFilter { get; set; }

        [Inject]
        public IFileWriter FileWriter { get; set; }

        #region ICsvReader Members

        public List<T> ReadCsv(string filePath)
        {
            return CsvReader.ReadCsv(filePath);
        }

        #endregion

        #region Implementation of IOrderFilterByAddress<T,T2>

        public List<T2> OrderFilterByAddress(List<T> people)
        {
            return AddressOrderFilter.OrderFilterByName(people);
        }

        #endregion

        #region Implementation of IOrderFilterByName<T,T2>

        public List<T2> OrderFilterByName(List<T> people)
        {
            return NameFrequencyFilter.OrderFilterByAddress(people);
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