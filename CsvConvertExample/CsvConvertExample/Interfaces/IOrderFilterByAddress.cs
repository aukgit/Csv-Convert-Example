using System.Collections.Generic;

namespace CsvConvertExample.Interfaces
{
    public interface IOrderFilterByAddress<T, T2> : IOrderFilter<T, T2>
    {
        List<T2> OrderFilterByAddress(List<T> list);
    }
}