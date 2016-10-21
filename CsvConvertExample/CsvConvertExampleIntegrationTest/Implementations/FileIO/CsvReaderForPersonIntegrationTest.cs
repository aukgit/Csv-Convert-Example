using System;
using System.IO;
using System.Linq;
using System.Text;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Implementations.FileIO;
using CsvConvertExample.Implementations.Formatters;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace CsvConvertExampleUnitTest.Implementations.FileIO
{
    public class CsvReaderForPersonIntegrationTest
    {
        private Mock<CsvReaderForPerson> _mockCsvReader;
        private CsvReaderForPerson _csvReaderForPerson;
        private string _appStartupPath;

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert
            // Arrange
            // app start path differs from project to project.
            _appStartupPath = AppDomain.CurrentDomain.BaseDirectory + @"\";
            _mockCsvReader = new Mock<CsvReaderForPerson>();
            var streetAddressExtractor = new StreetNameExtractor();
            _csvReaderForPerson = new CsvReaderForPerson(streetAddressExtractor);
        }

        [Test]
        public void If_Data_Folder_Exists()
        {
            // (Using Shouldly) Assert : Assert and Act together
            var results = Directory.Exists(_appStartupPath + "data");
            results.ShouldBe(true);

            // (Using NUnit) Assert : Assert and Act together
            Assert.AreEqual(true, results);
        }

        [TestCase("sample-input-1.csv")]
        [TestCase("sample-input-2.csv")]
        [TestCase("sample-input-3.csv")]
        public void Sample_Input_Present_In_Data_Directory(string sampleInputFileName)
        {
            // (Using Shouldly) Assert : Assert and Act together
            var results = File.Exists(_appStartupPath + @"data\" + sampleInputFileName);
            results.ShouldBe(true);

            // (Using NUnit) Assert : Assert and Act together
            Assert.AreEqual(true, results);
        }

        [TestCase("sample-input-1.csv", typeof(Person))]
        [TestCase("sample-input-2.csv", typeof(Person))]
        [TestCase("sample-input-3.csv", typeof(Person))]
        public void Sample_Input_Headers_Formatted_Correctly_For_Given_Data_Type(string sampleInputFileName, Type type)
        {
            // Arrange 
            var path = _appStartupPath + @"data\" + sampleInputFileName;

            const int bufferSize = 1024;
            string line = string.Empty;

            using (var fileStream = File.OpenRead(path))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
                {
                    if ((line = streamReader.ReadLine()) != null)
                    {
                        var fields = line.Split(',');
                        foreach (var columnName in fields)
                        {
                            var isPropertyExist = type.GetProperties().Any(n => n.Name.Equals(columnName, StringComparison.Ordinal));

                            // (Using Shouldly) Assert : Assert
                            string message = "\"" + sampleInputFileName + "\" file doesn't have the correct header : [" + columnName + "]";

                            isPropertyExist.ShouldBe(true, message);

                            // (Using NUnit) Assert : Assert
                            Assert.AreEqual(true, isPropertyExist, message);
                        }
                    }
                }
            }
        }

        [TestCase("sample-input-1.csv")]
        [TestCase("sample-input-2.csv")]
        [TestCase("sample-input-3.csv")]
        public void Sample_Input_Formatted_Is_Okay_For_Person_DataType(string sampleInputFileName)
        {
            // Arrange 
            var path = _appStartupPath + @"data\" + sampleInputFileName;

            // no exception thrown means okay.
            Should.NotThrow(() =>
            {
                var people = _csvReaderForPerson.ReadCsv(path);
                people.ShouldNotBeNull();
                people.Count.ShouldNotBe(0);
            });
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _mockCsvReader = null;
            GC.Collect();
        }
    }
}