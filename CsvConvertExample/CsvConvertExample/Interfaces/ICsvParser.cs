using System.Collections.Generic;

namespace CsvConvertExample.Interfaces {
    public interface ICsvParser<T> {
       List<T> ParseCsv();
    }
}
