#region using block

using System;
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
            Console.WriteLine("- CSV processor instantiating.");
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

            Console.WriteLine("- [Start] Reading person data from csv : " + csvReadingPath);
            var people = csvProcessor.ReadCsv(csvReadingPath);
            Console.WriteLine("- [Done] \"" + csvReadingPath + "\" file read successfully. We have total " + people.Count + " people.");

            // TODO : Also should have used a logger.
            // TODO : Could have refactor this to Action based delegates.
            Console.WriteLine("- [Start] filtering : sorting first and last by frequency of descending and then alphabetically.");
            var nameFrequencyFilteredResults = csvProcessor.OrderFilterByName(people);
            Console.WriteLine("- [Done] filtering : sorting first and last by frequency of descending and then alphabetically.");
            var nameFrequencyFormatterForCsv = container.Get<PersonNameFrequencyFormatterForCsv>();
            Console.WriteLine("- [Start] writing csv : " + csvNameFrequencyFilePath + ".");
            csvProcessor.WriteAsCsvFile(nameFrequencyFilteredResults, nameFrequencyFormatterForCsv, csvNameFrequencyFilePath);
            Console.WriteLine("- [Done] writing csv : " + csvNameFrequencyFilePath + ".");

            Console.WriteLine("- [Start] filtering : sorting address street name alphabetically.");
            var streetAddressFilteredAlphabeticallyResults = csvProcessor.OrderFilterByAddress(people);
            Console.WriteLine("- [Done] filtering : sorting address street name alphabetically.");
            var streetAddressFormatterForCsv = container.Get<PersonStreetAddressFormatterForCsv>();
            Console.WriteLine("- [Start] writing csv : " + csvStreetFilterFilePath);
            csvProcessor.WriteAsCsvFile(streetAddressFilteredAlphabeticallyResults, streetAddressFormatterForCsv, csvStreetFilterFilePath);
            Console.WriteLine("- [Done] writing csv : " + csvStreetFilterFilePath + ".");
            Console.WriteLine("- All operations are completed. Now press any key to exit.");

            Console.ReadKey();
        }
    }
}