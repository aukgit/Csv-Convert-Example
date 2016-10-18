#region using block

using System;
using System.Collections.Generic;
using CsvConvertExample.Interfaces;
using Ninject;

#endregion

namespace CsvConvertExample.Implementations
{
    public class CsvProcessor<T> : 
        IFileWriter<T>, ICsvReader<T>, IOrderByAddress<T>, IOrderByName<T>
    {
        [Inject]
        public IFileWriter<T> FileWriter { get; set; }
        [Inject]
        public ICsvReader<T> CsvReader { get; set; }
        [Inject]
        public IOrderByName<T> NameFrequencyProcessor { get; set; }
        [Inject]
        public IOrderByAddress<T> AddressOrderFilter { get; set; }

        #region IFileWriter Members

        public void WriteToFile(List<T> list)
        {
            FileWriter.WriteToFile(list);
        }

        #endregion

        #region ICsvReader Members

        public List<T> ReadCsv(string filePath)
        {
            return CsvReader.ReadCsv(filePath);
        }

        #endregion


        #region Implementation of IOrderByAddress<T>

        public List<T> OrderByAddress(List<T> list)
        {
            return AddressOrderFilter.OrderByAddress(list);
        }

        #endregion

        #region Implementation of IOrderByName<T>

        public List<T> OrderByName(List<T> list)
        {
            return NameFrequencyProcessor.OrderByName(list);
        }

        #endregion
    }
}