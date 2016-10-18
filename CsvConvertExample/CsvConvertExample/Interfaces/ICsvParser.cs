using System.Collections.Generic;

namespace CsvConvertExample.Interfaces {
    public interface IProcessCsv<T> : IProcess<T>
    {
       List<T> ProcessCsv();
    }
}
