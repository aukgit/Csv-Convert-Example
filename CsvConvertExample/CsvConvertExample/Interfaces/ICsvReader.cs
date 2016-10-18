using System.Collections.Generic;

namespace CsvConvertExample.Interfaces {
    public interface ICsvReader<T> {
        List<T> ReadCsv();
    }
}
