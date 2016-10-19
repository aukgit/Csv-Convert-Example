namespace CsvConvertExample.DataLayer.Interfaces
{
    public interface IAddressProperty : IEntity
    {
        string Address { get; set; }

        string StreetAddress { get; set; }
    }
}