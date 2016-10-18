#region using block

using System.Collections.Generic;

#endregion

namespace CsvConvertExample.Interfaces
{
    public interface IProcessCsv<T> : IProcess<T>
    {
        void ProcessCsv(List<T> list);
    }
}