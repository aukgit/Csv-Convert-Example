#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces.Formatter
{
    public interface IStringFormatter<T> : IProcess
        where T : class
    {
        string GetFormattedStringFor(List<T> list);
    }
}