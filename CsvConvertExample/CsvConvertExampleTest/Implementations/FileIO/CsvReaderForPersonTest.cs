using System;
using System.IO;
using System.Linq;
using System.Text;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Implementations.FileIO;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace CsvConvertExampleUnitTest.Implementations.FileIO
{
    public class CsvReaderForPersonTest
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
            _csvReaderForPerson = new CsvReaderForPerson();
        }

        [TestCase(@"...")]
        [TestCase(@"sample-directory-doesnt-exist\csv.csv")]
        [TestCase(@"sample-directory-doesnt-exist//")]
        [TestCase(@"-------123.csv")]
        public void FileNotFoundException_Should_Be_Thorwn_If_File_Not_Present(string filePath)
        {
            // Act

            // (Using Shouldly) Assert : Assert and Act together
            Should.Throw<FileNotFoundException>(() => _mockCsvReader.Object.ReadCsv(filePath));

            // (Using NUnit) Assert : Assert and Act together
            Assert.Throws<FileNotFoundException>(() => _mockCsvReader.Object.ReadCsv(filePath));
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
                            isPropertyExist.ShouldBe(true);

                            // (Using NUnit) Assert : Assert
                            Assert.AreEqual(true, isPropertyExist);
                        }
                    }
                }
            }
        }

        [TestCase("sample-input-1.csv", typeof(Person))]
        [TestCase("sample-input-2.csv", typeof(Person))]
        [TestCase("sample-input-3.csv", typeof(Person))]
        public void Sample_Input_Formatted_Correctly_For_Given_Data_Type(string sampleInputFileName, Type type)
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

                            // (Using Shouldly) Assert : Assert and Act together
                            isPropertyExist.ShouldBe(true);

                            // (Using NUnit) Assert : Assert and Act together
                            Assert.AreEqual(true, isPropertyExist);
                        }
                    }
                }
            }
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _mockCsvReader = null;
            GC.Collect();
        }
    }
}