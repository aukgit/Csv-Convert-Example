#region using block

using CsvConvertExample.DataLayer.Interfaces;

#endregion

namespace CsvConvertExample.DataLayer
{
    public class AddressProperty : IAddressProperty
    {
        public string Address { get; set; }
        public string StreetAddress { get; set; }
    }
}