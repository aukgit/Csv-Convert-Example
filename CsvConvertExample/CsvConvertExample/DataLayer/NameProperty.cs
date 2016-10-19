#region using block

using CsvConvertExample.DataLayer.Interfaces;

#endregion

namespace CsvConvertExample.DataLayer
{
    public class NameProperty : INameProperty
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}