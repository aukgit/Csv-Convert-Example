using System.Collections.Generic;

namespace CsvConvertExample.Interfaces {
    public interface ICsvReader<T> : IProcess<T>
    {
        List<T> ReadCsv(string filePath);
    }
}
