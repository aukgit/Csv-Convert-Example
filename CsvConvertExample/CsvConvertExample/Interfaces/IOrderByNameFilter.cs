using System.Collections.Generic;

namespace CsvConvertExample.Interfaces
{
    public interface IOrderFilterByName<T, T2> : IOrderFilter<T, T2>
    {
        List<T2> OrderFilterByName(List<T> list);
    }
}