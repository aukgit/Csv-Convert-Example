#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces.OrderFilters
{
    public interface IOrderFilterByAddress<T, T2> : IOrderFilter<T, T2>
        where T : class, new()
        where T2 : class, new()
    {
        List<T2> OrderFilterByAddress(List<T> list);
    }
}