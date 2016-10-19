#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface ICsvWriter<T> : IProcess<T>
        where T : class, new()
    {
        bool WriteAsCsvFile<T2>(IFileWriter<T2> writer, List<T2> list, string[] propertise, string filepath)
            where T2 : class, new();
    }
}