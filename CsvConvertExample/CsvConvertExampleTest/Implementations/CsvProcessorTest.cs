using CsvConvertExample.DataLayer;
using CsvConvertExample.Implementations;
using CsvConvertExample.Implementations.FileIO;
using CsvConvertExample.Implementations.OrderFilters;
using CsvConvertExample.Interfaces.FileIO;
using CsvConvertExample.Interfaces.Formatter;
using CsvConvertExample.Interfaces.OrderFilters;
using Moq;
using NUnit.Framework;

namespace CsvConvertExampleUnitTest.Implementations
{
    public class CsvProcessorTest
    {
        protected CsvProcessor csvProcessor;
        protected CsvFileWriter csvFileWriter;
        protected Mock<ICsvReader<Person>> mockCsvReader;
        protected Mock<IOrderFilterByName<Person, PeopleOrderByNameFrequency>> mockOrderFilterByName;
        protected Mock<IOrderFilterByAddress<Person, Person>> mockOrderFilterByAddress;

        protected Mock<IPersonNameFrequencyFormatterForCsv<PeopleOrderByNameFrequency>> mockPersonNameFrequencyFormatterForCsv;
        protected Mock<IPersonStreetAddressFormatterForCsv<Person>> mockPersonStreetAddressFormatterForCsv;
        protected Mock<IStreetAddressExtractor> mockStreetAddressExtractor;

        [OneTimeSetUp]
        public void Setup()
        {
            // AAA Syntax : Arrange, Act, Assert
            // Arrange
            _personNameFrequencyFilter = new PersonNameFrequencyFilter();
        }
    }
}