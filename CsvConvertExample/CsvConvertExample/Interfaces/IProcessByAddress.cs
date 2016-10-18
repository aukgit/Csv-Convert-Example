using System.Collections.Generic;

namespace CsvConvertExample.Interfaces
{
    public interface IOrderByAddress<T> : IProcess<T>
    {
        List<T> OrderByAddress(List<T> list);
    }
}
