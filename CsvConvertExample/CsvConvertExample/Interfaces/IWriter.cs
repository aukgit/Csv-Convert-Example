#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface IWriter<T> : IProcess<T>
    {
        bool WriteToFile<T2>(List<T2> list);
    }
}