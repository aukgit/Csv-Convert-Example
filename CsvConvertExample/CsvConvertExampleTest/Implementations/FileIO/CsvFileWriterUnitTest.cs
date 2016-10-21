#region using block

using System;
using System.IO;
using CsvConvertExample.Implementations.FileIO;
using Moq;
using NUnit.Framework;
using Shouldly;

#endregion

namespace CsvConvertExampleUnitTest.Implementations.FileIO
{
    [TestFixture]
    public class CsvFileWriterUnitTest
    {
        private readonly string fileContent = "text-content";
        private Mock<CsvFileWriter> _mockCsvFileWriter;

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert
            // Arrange
            _mockCsvFileWriter = new Mock<CsvFileWriter>();
        }

        [TestCase(@"sample-directory-doesnt-exist\csv.csv")]
        public void DirectoryNotFoundException_Should_Be_Thorwn_If_Directory_Doesnt_Present(string filePath)
        {
            // Act

            // (Using Shouldly) Assert : Assert and Act together
            Should.Throw<DirectoryNotFoundException>(() => _mockCsvFileWriter.Object.Write(filePath, fileContent));

            // (Using NUnit) Assert : Assert and Act together
            // Assert.Throws<DirectoryNotFoundException>(() => _mockCsvFileWriter.Object.Write(filePath, fileContent));
        }

        [TestCase(@"...")]
        public void UnauthorizedAccessException_Should_Be_Thorwn_If_Directory_Doesnt_Present(string filePath)
        {
            // Act

            // (Using Shouldly) Assert : Assert and Act together
            Should.Throw<UnauthorizedAccessException>(() => _mockCsvFileWriter.Object.Write(filePath, fileContent));

            // (Using NUnit) Assert : Assert and Act together
            Assert.Throws<UnauthorizedAccessException>(() => _mockCsvFileWriter.Object.Write(filePath, fileContent));
        }

        [TestCase(@"sample-directory-doesnt-exist//")]
        public void IOException_Should_Be_Thorwn_If_Directory_Doesnt_Present(string filePath)
        {
            // Act

            // (Using Shouldly) Assert : Assert and Act together
            Should.Throw<IOException>(() => _mockCsvFileWriter.Object.Write(filePath, fileContent));

            // (Using NUnit) Assert : Assert and Act together
            Assert.Throws<IOException>(() => _mockCsvFileWriter.Object.Write(filePath, fileContent));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _mockCsvFileWriter = null;
            GC.Collect();
        }
    }
}