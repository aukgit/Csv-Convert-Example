#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface IFileWriter<T> : IProcess<T>
    {
        void WriteToFile(List<T> list);
    }
}