namespace CsvConvertExample.Interfaces.OrderFilters
{
    public interface IOrderFilter<T, T2> : IProcess
        where T : class
        where T2 : class
    {
    }
}