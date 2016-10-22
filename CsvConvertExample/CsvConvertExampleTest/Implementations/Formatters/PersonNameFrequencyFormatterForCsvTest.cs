#region using block

using System;
using System.Collections.Generic;
using System.Text;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Implementations.Formatters;
using NUnit.Framework;
using Shouldly;

#endregion

namespace CsvConvertExampleUnitTest.Implementations.Formatters
{
    [TestFixture]
    public class PersonNameFrequencyFormatterForCsvTest
    {
        private PersonNameFrequencyFormatterForCsv _personNameFrequencyFormatterForCsv;
        private string _appStartupPath;

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert

            // Arrange
            // app start path differs from project to project.
            _appStartupPath = AppDomain.CurrentDomain.BaseDirectory + @"\";
            _personNameFrequencyFormatterForCsv = new PersonNameFrequencyFormatterForCsv();
        }

        [Test]
        public void Verify_If_PersonNameFrequencyFormatterForCsv_Provides_Correct_Output()
        {
            var list = new List<PeopleOrderByNameFrequency>
            {
                new PeopleOrderByNameFrequency
                {
                    People = new List<PeopleGroupCollector>
                    {
                        new PeopleGroupCollector
                        {
                            Count = 3,
                            NameProperty = new NameProperty
                            {
                                FirstName = "Alice",
                                LastName = "Jackson"
                            }
                        },
                        new PeopleGroupCollector
                        {
                            Count = 2,
                            NameProperty = new NameProperty
                            {
                                FirstName = "Wattson",
                                LastName = "Jackson"
                            }
                        },
                        new PeopleGroupCollector
                        {
                            Count = 50,
                            NameProperty = new NameProperty
                            {
                                FirstName = "Zermon",
                                LastName = "Roman"
                            }
                        }
                    }
                }
            };
            string spliter = ",";
            var sb = new StringBuilder((list.Count * 5) + 5);

            // TODO : use string.format
            sb.AppendLine("FirstName" + spliter + "LastName" + spliter + "Frequency");
            foreach (var peopleGroup in list)
            {
                foreach (var people in peopleGroup.People)
                {
                    var person = people.NameProperty;

                    // TODO : use string.format
                    if (person != null)
                    {
                        sb.AppendLine(person.FirstName + spliter + person.LastName + spliter + people.Count);
                    }
                }
            }

            var expected = sb.ToString();
            sb = null;
            GC.Collect();

            var actual = _personNameFrequencyFormatterForCsv.GetFormattedStringFor(list);

            // (Using Shouldly) Assert : Assert and Act together
            expected.ShouldBe(actual);

            // (Using NUnit) Assert : Assert and Act together
            Assert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _personNameFrequencyFormatterForCsv = null;
            GC.Collect();
        }
    }
}