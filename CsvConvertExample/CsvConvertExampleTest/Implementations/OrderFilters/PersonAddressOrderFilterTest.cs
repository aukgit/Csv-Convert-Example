#region using block

using System;
using System.Collections.Generic;
using System.Linq;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Implementations.OrderFilters;
using NUnit.Framework;
using Shouldly;

#endregion

namespace CsvConvertExampleUnitTest.Implementations.OrderFilters
{
    [TestFixture]
    public class PersonAddressOrderFilterTest
    {
        private PersonAddressOrderFilter _personAddressOrderFilter;

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert
            // Arrange
            _personAddressOrderFilter = new PersonAddressOrderFilter();
        }

        [Test]
        public void Verify_Person_Street_Filter_Alphabetically()
        {
            // Arrange
            var people = Generator.People;

            // Act
            var expected = people.OrderBy(person => person.StreetAddress).ToList();
            var actual = _personAddressOrderFilter.OrderFilterByAddress(people);

            // (Using Shouldly) Assert : Assert and Act together
            expected.ShouldBe(actual);

            // (Using NUnit) Assert : Assert and Act together
            CollectionAssert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _personAddressOrderFilter = null;
            GC.Collect();
        }
    }
}