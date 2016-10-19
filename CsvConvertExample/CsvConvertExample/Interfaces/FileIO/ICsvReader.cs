#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces.FileIO
{
    public interface ICsvReader<T> : IProcess<T>
        where T : class, new()
    {
        List<T> ReadCsv(string filePath);
    }
}