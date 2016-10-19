#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces.Formatter
{
    public interface IStringFormatter<T> : IProcess<T>
        where T : class, new()
    {
        string GetFormattedStringFor(List<T> list);
    }
}