#region using block

using System;
using System.Threading;
using CsvConvertExample.Implementations.FileIO;
using NUnit.Framework;
using Shouldly;

#endregion

namespace CsvConvertExampleIntegrationTest.Implementations.FileIO
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

        [TestCase("a.csv,a.csv,a.csv")]
        public void Should_Overwrite_Same_File_In_Multithreaded_Environment(string filePathsCsv)
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

        [TestCase("a.csv,a.csv,a.csv")]
        public void Verify_Mutex_And_Lock_During_Threading_File_Writing(string filePathsCsv)
        {
            Should_Overwrite_Same_File_In_Multithreaded_Environment(filePathsCsv);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _csvFileWriter = null;
            GC.Collect();
        }
    }
}