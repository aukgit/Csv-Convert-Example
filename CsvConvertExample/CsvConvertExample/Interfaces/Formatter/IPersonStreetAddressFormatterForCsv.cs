namespace CsvConvertExample.Interfaces.Formatter
{
    public interface IPersonStreetAddressFormatterForCsv<T> : IStringFormatter<T>
        where T : class, new()
    {
    }
}
