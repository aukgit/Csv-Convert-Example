using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvConvertExample.Interfaces.Formatter;

namespace CsvConvertExample.Implementations.Formatters
{
    public class StreetNameExtractor : IStreetAddressExtractor
    {
        #region Implementation of IStreetAddressExtractor

        /// <summary>
        ///     Get only street names from address.
        /// </summary>
        /// <param name="address">Given address format can be "\d{4} \w+[10]"</param>
        /// <returns>Returns street address after number.</returns>
        public string ExtractStreetAddress(string address)
        {
            if (address != null)
            {
                var spaceIndex = address.IndexOf(" ", StringComparison.Ordinal);
                return address.Substring(spaceIndex + 1);
            }

            return string.Empty;
        }

        #endregion
    }
}
