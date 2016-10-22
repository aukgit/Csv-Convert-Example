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
            var people = Generator.People;

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

        /// <summary>
        /// frequency of the first and last names ordered by frequency and then alphabetically
        /// </summary>
        [Test]
        public void ThrowExceptionIf_Given_List_Of_People_Is_Null_When_Testing_Frequency_Filter_Where_First_Last_Names_Ordered_By_Frequency_And_Then_Alphabetically()
        {
            // Act
            Should.Throw(_personNameFrequencyFilter.OrderFilterByName(null), "Null object passed.");
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _personNameFrequencyFilter = null;
            GC.Collect();
        }
    }
}