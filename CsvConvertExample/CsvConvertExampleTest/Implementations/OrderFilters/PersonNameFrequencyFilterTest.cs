using System;
using System.Collections.Generic;
using System.Linq;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Implementations.OrderFilters;
using NUnit.Framework;
using Shouldly;

namespace CsvConvertExampleUnitTest.Implementations.OrderFilters
{
    /// <summary>
    ///     frequency of the first and last names ordered by frequency and then alphabetically
    /// </summary>
    public class PersonNameFrequencyFilterTest
    {
        private PersonNameFrequencyFilter _personNameFrequencyFilter;

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert
            // Arrange
            _personNameFrequencyFilter = new PersonNameFrequencyFilter();
        }

        /// <summary>
        /// frequency of the first and last names ordered by frequency and then alphabetically
        /// </summary>
        [Test]
        public void Verify_Person_Name_Frequency_Filter_Where_First_Last_Names_Ordered_By_Frequency_And_Then_Alphabetically()
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
            var actual = _personNameFrequencyFilter.OrderFilterByName(people);

            var process = people.Select(n => new NameProperty()
            {
                FirstName = n.FirstName,
                LastName = n.LastName
            })
                               .GroupBy(person => new
                               {
                                   person.FirstName,
                                   person.LastName
                               })
                               .Select(group => new PeopleGroupCollector()
                               {
                                   NameProperty = group.FirstOrDefault(),
                                   Count = group.Count()
                               })
                               .OrderByDescending(n => n.Count)
                               .ThenBy(n => n.NameProperty.FirstName)
                               .ThenBy(n => n.NameProperty.LastName)
                               .ToList();

            var expectedFinalizedResults = new List<PeopleOrderByNameFrequency>
            {
               new PeopleOrderByNameFrequency()
                {
                    People = process
                }
            };


            var actualList = actual[0].People;
            var expectedList = expectedFinalizedResults[0].People;

            for (int i = 0; i < expectedList.Count; i++)
            {
                var expectedItem = expectedList[i];
                var actualItem = actualList[i];
                
                // Asserting using Shouldly.
                expectedItem.NameProperty.FirstName.ShouldBe(actualItem.NameProperty.FirstName);
                expectedItem.NameProperty.LastName.ShouldBe(actualItem.NameProperty.LastName);
                expectedItem.Count.ShouldBe(actualItem.Count);
            }
            
            expectedList = null;
            actualList = null;
            process = null;
            actual = null;
            GC.Collect();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _personNameFrequencyFilter = null;
            GC.Collect();
        }
    }
}