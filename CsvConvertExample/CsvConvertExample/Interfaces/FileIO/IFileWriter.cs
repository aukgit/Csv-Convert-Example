#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface IFileWriter
    {
        bool Write(string filepath, string content);
    }
}