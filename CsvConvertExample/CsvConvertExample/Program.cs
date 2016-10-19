#region using block

using CsvConvertExample.DataLayer;
using CsvConvertExample.Implementations;
using CsvConvertExample.Implementations.FileIO;
using CsvConvertExample.Implementations.Formatters;
using CsvConvertExample.Implementations.OrderFilters;
using CsvConvertExample.Interfaces.FileIO;
using CsvConvertExample.Interfaces.Formatter;
using CsvConvertExample.Interfaces.OrderFilters;
using Ninject;

#endregion

namespace CsvConvertExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new StandardKernel();
            container.Bind<ICsvReader<Person>>().To<CsvReaderForPeople>();
            container.Bind<IFileWriter>().To<CsvFileWriter>();

            container.Bind<IPersonNameFrequencyFormatterForCsv<PeopleOrderByNameFrequency>>().To<PersonNameFrequencyFormatterForCsv>();
            container.Bind<IPersonStreetAddressFormatterForCsv<Person>>().To<PersonStreetAddressFormatterForCsv>();
            container.Bind<IStreetAddressExtractor>().To<StreetNameExtractor>();

            container.Bind<IOrderFilterByName<Person, PeopleOrderByNameFrequency>>().To<PersonNameFrequencyFilter>();
            container.Bind<IOrderFilterByAddress<Person, Person>>().To<PersonAddressOrderFilter>();

            var csvProcessor = container.Get<CsvProcessor>();

            var relativeFolder = @"data\";
            var csvReadingPath = relativeFolder + @"data.csv";
            var csvNameFrequencyFilePath = relativeFolder + @"output\name-frequency.csv";
            var csvStreetFilterFilePath = relativeFolder + @"output\street-address-filtered-alphabetically.csv";
            var people = csvProcessor.ReadCsv(csvReadingPath);

            var nameFrequencyFilteredResults = csvProcessor.OrderFilterByName(people);
            var nameFrequencyFormatterForCsv = container.Get<PersonNameFrequencyFormatterForCsv>();
            csvProcessor.WriteAsCsvFile(nameFrequencyFilteredResults, nameFrequencyFormatterForCsv, csvNameFrequencyFilePath);

            var streetAddressFilteredAlphabeticallyResults = csvProcessor.OrderFilterByAddress(people);
            var streetAddressFormatterForCsv = container.Get<PersonStreetAddressFormatterForCsv>();
            csvProcessor.WriteAsCsvFile(streetAddressFilteredAlphabeticallyResults, streetAddressFormatterForCsv, csvStreetFilterFilePath);
        }
    }
}