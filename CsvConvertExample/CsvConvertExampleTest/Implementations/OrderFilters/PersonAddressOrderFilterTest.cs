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
            var people = new List<Person>
            {
                new Person
                {
                    FirstName = "Alice",
                    LastName = "Roman",
                    PhoneNumber = 9198298,
                    Address = "94 Roland St",
                    StreetAddress = "Roland St"
                },
                new Person
                {
                    FirstName = "Alim",
                    LastName = "Karim",
                    PhoneNumber = 83300202,
                    Address = "94 Dhaka Bangladesh",
                    StreetAddress = "Dhaka Bangladesh"
                },
                new Person
                {
                    FirstName = "Jackson",
                    LastName = "Don",
                    PhoneNumber = 12324421,
                    Address = "8 Crimson Rd",
                    StreetAddress = "Crimson Rd"
                },
                new Person
                {
                    FirstName = "Jhon",
                    LastName = "Doe",
                    PhoneNumber = 1234112,
                    Address = "78 Short Lane",
                    StreetAddress = "Short Lane"
                },
                new Person
                {
                    FirstName = "Karim",
                    LastName = "Alim",
                    PhoneNumber = 1234112,
                    Address = "78 Short Lane",
                    StreetAddress = "Short Lane"
                }
            };

            people.Add(people[1]);
            people.Add(people[3]);
            people.Add(people[2]);
            people.Add(people[2]);
            people.Add(people[2]);
            people.Add(people[2]);
            people.Add(people[0]);
            people.Add(people[0]);
            people.Add(people[0]);
            people.Add(people[0]);
            people.Add(people[0]);
            people.Add(people[4]);
            people.Add(people[4]);
            people.Add(people[4]);
            people.Add(people[4]);
            people.Add(people[3]);
            people.Add(people[3]);
            people[people.Count - 1].FirstName = people[0].LastName;
            people[people.Count - 5].FirstName = people[0].LastName;
            people[people.Count - 3].FirstName = people[2].LastName;
            people[people.Count - 3].Address = people[2].Address;
            people[people.Count - 3].StreetAddress = people[2].StreetAddress;

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