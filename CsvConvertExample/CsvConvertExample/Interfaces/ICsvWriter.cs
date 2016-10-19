#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface ICsvWriter : IProcess<object>
    {
        bool WriteAsCsvFile<T>(IFileWriter<T> writer, List<T> list, string[] propertise, string filepath);
    }
}