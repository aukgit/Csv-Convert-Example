#region using block

using System.Collections.Generic;
using CsvConvertExample.Interfaces;
using Ninject;

#endregion

namespace CsvConvertExample.Implementations
{
    public class CsvProcessor<T, T2> :
        ICsvWriter, ICsvReader<T>, IOrderFilterByAddress<T, T2>, IOrderFilterByName<T, T2>
    {
        [Inject]
        public ICsvReader<T> CsvReader { get; set; }

        [Inject]
        public IOrderFilterByAddress<T, T2> NameFrequencyFilter { get; set; }

        [Inject]
        public IOrderFilterByName<T, T2> AddressOrderFilter { get; set; }

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

        #region Implementation of ICsvWriter

        public bool WriteAsCsvFile<T1>(IFileWriter<T1> writer, List<T1> list, string[] propertise, string filepath)
        {
            return false;
        }

        #endregion
    }
}