#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface IOrderByName<T> : IProcess<T>
    {
        List<T> OrderByName(List<T> list);
    }
}