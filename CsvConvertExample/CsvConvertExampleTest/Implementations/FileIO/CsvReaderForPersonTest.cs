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

        [OneTimeTearDown]
        public void CleanUp()
        {
            _mockCsvReader = null;
            GC.Collect();
        }
    }
}