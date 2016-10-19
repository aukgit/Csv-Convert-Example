#region using block

using System;

#endregion

namespace CsvConvertExample.DataLayer
{
    public class Person : INameProperty, IAddressProperty
    {
        #region Constructors

        public Person()
        {
        }

        public Person(INameProperty nameProperty)
            : this(nameProperty, null)
        {
        }

        public Person(INameProperty nameProperty, IAddressProperty addressProperty)
        {
            if (nameProperty != null)
            {
                FirstName = nameProperty.FirstName;
                LastName = nameProperty.LastName;
            }

            if (addressProperty != null)
            {
                Address = addressProperty.Address;
                StreetAddress = addressProperty.StreetAddress;
            }
        } 
        #endregion

        public long PhoneNumber { get; set; }

        #region INameProperty Members

        public string FirstName { get; set; }

        public string LastName { get; set; }
        #endregion

        #region IAddressProperty Members

        public string Address { get; set; }

        public string StreetAddress { get; set; }

        #endregion
    }
}