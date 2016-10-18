#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface IOrderByAddress<T> : IProcess<T>
    {
        List<T> OrderByAddress(List<T> list);
    }
}