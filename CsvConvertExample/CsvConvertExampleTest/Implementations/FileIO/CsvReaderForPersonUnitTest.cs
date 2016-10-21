#region using block

using System;
using System.IO;
using CsvConvertExample.Implementations.FileIO;
using CsvConvertExample.Implementations.Formatters;
using NUnit.Framework;
using Shouldly;

#endregion

namespace CsvConvertExampleUnitTest.Implementations.FileIO
{
    public class CsvReaderForPersonUnitTest
    {
        private CsvReaderForPerson _csvReaderForPerson;

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert
            // Arrange
            // app start path differs from project to project.
            // There is no need to mock. Because these test are not going to complete anyway. 
            // There is a condition check which throws exception if path is not valid.
            _csvReaderForPerson = new CsvReaderForPerson(new StreetNameExtractor());
        }

        [TestCase(@"...")]
        [TestCase(@"sample-directory-doesnt-exist\csv.csv")]
        [TestCase(@"sample-directory-doesnt-exist//")]
        [TestCase(@"-------123.csv")]
        public void FileNotFoundException_Should_Be_Thorwn_If_File_Not_Present(string filePath)
        {
            // Act

            // (Using Shouldly) Assert : Assert and Act together
            Should.Throw<FileNotFoundException>(() => _csvReaderForPerson.ReadCsv(filePath));

            // (Using NUnit) Assert : Assert and Act together
            Assert.Throws<FileNotFoundException>(() => _csvReaderForPerson.ReadCsv(filePath));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _csvReaderForPerson = null;
            GC.Collect();
        }
    }
}