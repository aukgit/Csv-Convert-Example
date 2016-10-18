using System.Collections.Generic;

namespace CsvConvertExample.Interfaces {
    public interface IFileWriter<T> : IProcess<T>
    {
        void WriteToFile(List<T> list);
    }
}
