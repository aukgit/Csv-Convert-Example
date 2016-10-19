namespace CsvConvertExample.Interfaces.OrderFilters
{
    public interface IOrderFilter<T, T2> : IProcess<T>
        where T : class, new()
        where T2 : class, new()
    {
    }
}