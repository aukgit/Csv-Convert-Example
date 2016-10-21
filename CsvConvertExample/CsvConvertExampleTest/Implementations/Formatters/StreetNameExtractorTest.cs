#region using block

using System;
using CsvConvertExample.Implementations.Formatters;
using NUnit.Framework;
using Shouldly;

#endregion

namespace CsvConvertExampleUnitTest.Implementations.Formatters
{
    public class StreetNameExtractorTest
    {
        private StreetNameExtractor _streetNameExtractor;

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert

            // Arrange
            // app start path differs from project to project.
            _streetNameExtractor = new StreetNameExtractor();
        }

        [TestCase("102 Long Lane")]
        [TestCase("65 Ambling Way")]
        [TestCase("82 Stewart St")]
        [TestCase("78 Short Lane")]
        public void Verify_If_StreetNameExtractor_Extracts_StreetName_From_Address(string address)
        {
            // Arrange
            var spaceIndex = address.IndexOf(" ", StringComparison.Ordinal);
            var expected = address.Substring(spaceIndex + 1);

            // Act
            var actual = _streetNameExtractor.ExtractStreetAddress(address);

            // (Using Shouldly) Assert : Assert and Act together
            expected.ShouldBe(actual);

            // (Using NUnit) Assert : Assert and Act together
            Assert.AreEqual(expected, actual);
        }

        [TestCase("102 Long Lane", "Long Lane")]
        [TestCase("65 Ambling Way", "Ambling Way")]
        [TestCase("82 Stewart St", "Stewart St")]
        [TestCase("78 Short Lane", "Short Lane")]
        [TestCase("", "")]
        [TestCase(null, "")]
        public void Verify_If_StreetNameExtractor_Extracts_StreetName_From_Address(string address, string expectedStreetAddress)
        {
            // Act
            var actual = _streetNameExtractor.ExtractStreetAddress(address);

            // (Using Shouldly) Assert : Assert and Act together
            expectedStreetAddress.ShouldBe(actual);

            // (Using NUnit) Assert : Assert and Act together
            Assert.AreEqual(expectedStreetAddress, actual);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _streetNameExtractor = null;
            GC.Collect();
        }
    }
}