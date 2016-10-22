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
    public class PersonStreetAddressFormatterForCsvTest
    {
        private PersonStreetAddressFormatterForCsv _personStreetAddressFormatterForCsv;
        private string _appStartupPath;

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert

            // Arrange
            // app start path differs from project to project.
            _appStartupPath = AppDomain.CurrentDomain.BaseDirectory + @"\";
            _personStreetAddressFormatterForCsv = new PersonStreetAddressFormatterForCsv();
        }

        [Test]
        public void Verify_If_PersonStreetAddressFormatterForCsv_Provides_Correct_Output()
        {
            var list = new List<Person>
            {
                new Person
                {
                    FirstName = "Alice",
                    LastName = "Roman",
                    Address = "12 Peter Jackson",
                    StreetAddress = "Peter Jackson",
                    PhoneNumber = 23213452
                },
                new Person
                {
                    FirstName = "Alice",
                    LastName = "Roman",
                    Address = "12 RPeter Jackson",
                    StreetAddress = "RPeter Jackson",
                    PhoneNumber = 23213452
                },
                new Person
                {
                    FirstName = "Alice",
                    LastName = "Roman",
                    Address = "12 Zyui Jackson",
                    StreetAddress = "Zyui Jackson",
                    PhoneNumber = 23213452
                },
                new Person
                {
                    FirstName = "Roman",
                    LastName = "Roman",
                    Address = "12 WWZ",
                    StreetAddress = "WWZ",
                    PhoneNumber = 44555555
                },
                new Person
                {
                    FirstName = "Jhon",
                    LastName = "Doe",
                    Address = "12 Peter Jackson",
                    StreetAddress = "Peter Jackson",
                    PhoneNumber = 3333333
                }
            };
            string spliter = ",";
            var sb = new StringBuilder((list.Count * 5) + 5);

            // TODO : use string.format
            sb.AppendLine("StreetAddress" + spliter + "Address" + spliter + "FirstName" + spliter + "LastName");
            foreach (var person in list)
            {
                // TODO : use string.format
                sb.AppendLine(person.StreetAddress + spliter + person.Address + spliter + person.FirstName + spliter + person.LastName);
            }

            var expected = sb.ToString();
            sb = null;
            GC.Collect();

            var actual = _personStreetAddressFormatterForCsv.GetFormattedStringFor(list);

            // (Using Shouldly) Assert : Assert and Act together
            expected.ShouldBe(actual);

            // (Using NUnit) Assert : Assert and Act together
            Assert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _personStreetAddressFormatterForCsv = null;
            GC.Collect();
        }
    }
}