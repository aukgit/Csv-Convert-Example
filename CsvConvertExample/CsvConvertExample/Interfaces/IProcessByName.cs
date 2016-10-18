using System.Collections.Generic;

namespace CsvConvertExample.Interfaces
{
    public interface IProcessByName<T> : IProcess<T>
    {
        List<T> ProcessByname();
    }
}
