#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface ICsvReader<T> : IProcess<T>
    {
        List<T> ReadCsv(string filePath);
    }
}