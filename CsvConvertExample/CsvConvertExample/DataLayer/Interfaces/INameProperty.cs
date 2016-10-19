namespace CsvConvertExample.DataLayer.Interfaces
{
    public interface INameProperty : IEntity
    {
        string FirstName { get; set; }

        string LastName { get; set; }
    }
}