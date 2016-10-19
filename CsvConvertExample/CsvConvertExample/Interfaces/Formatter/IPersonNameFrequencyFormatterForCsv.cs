namespace CsvConvertExample.Interfaces.Formatter
{
    public interface IPersonNameFrequencyFormatterForCsv<T> : IStringFormatter<T>
        where T : class, new()
    {
    }
}
