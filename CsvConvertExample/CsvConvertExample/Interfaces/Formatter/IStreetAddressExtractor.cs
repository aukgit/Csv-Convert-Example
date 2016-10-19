namespace CsvConvertExample.Interfaces.Formatter
{
    public interface IStreetAddressExtractor
    {
        /// <summary>
        ///     Get only street names from address.
        /// </summary>
        /// <param name="address">Given address format can be "\d{4} \w+[10]"</param>
        /// <returns>Returns street address after number.</returns>
        string ExtractStreetAddress(string address);
    }
}