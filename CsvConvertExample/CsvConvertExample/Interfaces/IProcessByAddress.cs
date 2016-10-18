using System.Collections.Generic;

namespace CsvConvertExample.Interfaces
{
    public interface IProcessByAddress<T> : IProcess<T>
    {
        List<T> ProcessByAddress();
    }
}
