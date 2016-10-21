#region using block

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CsvConvertExample.Implementations.FileIO;
using Moq;
using NUnit.Framework;
using Shouldly;

#endregion

namespace CsvConvertExampleUnitTest.Implementations.FileIO
{
    [TestFixture]
    public class CsvFileWriterIntegrationTest
    {
        private readonly string fileContent = "text-content";
        private CsvFileWriter _csvFileWriter;

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert
            // Arrange
            _csvFileWriter = new CsvFileWriter();
        }

        [TestCase(@"csv.csv")]
        public void Should_Write_File_On_Same_Directory(string filePath)
        {
            // Arrange

            // Act
            var result = _csvFileWriter.Write(filePath, fileContent);

            // (Using Shouldly) Assert : Assert and Act together
            result.ShouldBe(true);

            // (Using NUnit) Assert : Assert and Act together
            // Assert.AreEqual(true, result);
        }

        [TestCase("a.csv,a.csv,a.csv")]
        public void Should_Write_Same_Name_File_With_Multithread(string filePathsCsv)
        {
            // Arrange
            var filePaths = filePathsCsv.Split(',');
            int i = 0;

            // Act
            foreach (var filePath in filePaths)
            {
                var path = filePath;
                int currentIndex = i; // copied varible.
                var thread = new Thread(() =>
                {
                    var result = _csvFileWriter.Write(path, path + currentIndex);

                    // (Using Shouldly) Assert : Assert and Act together
                    result.ShouldBe(true);

                    // (Using NUnit) Assert : Assert and Act together
                    Assert.AreEqual(true, result);
                });
                thread.Start();
            }
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            GC.Collect();
        }
    }
}