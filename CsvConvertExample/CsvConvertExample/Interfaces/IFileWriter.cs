#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface IFileWriter<T> : IProcess<T>
        where T : class, new()
    {
        bool Write(string filepath, string content);
    }
}