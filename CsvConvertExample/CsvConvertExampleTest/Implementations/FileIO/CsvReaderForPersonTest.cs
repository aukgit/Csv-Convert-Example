using System;
using System.IO;
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

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert
            // Arrange
            _mockCsvReader = new Mock<CsvReaderForPerson>();
            _csvReaderForPerson = new CsvReaderForPerson();
        }

        [TestCase(@"...")]
        [TestCase(@"sample-directory-doesnt-exist\csv.csv")]
        [TestCase(@"sample-directory-doesnt-exist//")]
        public void FileNotFoundException_Should_Be_Thorwn_If_File_Not_Present(string filePath)
        {
            // Act

            // (Using Shouldly) Assert : Assert and Act together
            Should.Throw<FileNotFoundException>(() => _mockCsvReader.Object.ReadCsv(filePath));

            // (Using NUnit) Assert : Assert and Act together
            Assert.Throws<FileNotFoundException>(() => _mockCsvReader.Object.ReadCsv(filePath));
        }


        [TestCase(@"Data\data.csv")]
        public void Read_Person_CSV_Data(string filePath)
        {
            // Act
            // (Using Shouldly) Assert : Assert and Act together
            var results = _mockCsvReader.Object.ReadCsv(filePath);

            // (Using NUnit) Assert : Assert and Act together
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _mockCsvReader = null;
            GC.Collect();
        }
    }
}