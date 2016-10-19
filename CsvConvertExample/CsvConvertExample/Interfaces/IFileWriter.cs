#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface IFileWriter<T> : IProcess<T>
    {
        bool Write(List<T> list, string[] propertise, string filepath);
    }
}