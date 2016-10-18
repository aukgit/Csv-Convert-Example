using System.Collections.Generic;

namespace CsvConvertExample.Interfaces
{
    public interface IOrderByName<T> : IProcess<T>
    {
        List<T> OrderByName(List<T> list);
    }
}
