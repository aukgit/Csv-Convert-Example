#region using block

using System;
using System.IO;
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
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("- CSV processor instantiating.");

            // Binding using Ninject
            var container = new StandardKernel();
            container.Bind<ICsvReader<Person>>().To<CsvReaderForPerson>();
            container.Bind<IFileWriter>().To<CsvFileWriter>();

            container.Bind<IPersonNameFrequencyFormatterForCsv<PeopleOrderByNameFrequency>>().To<PersonNameFrequencyFormatterForCsv>();
            container.Bind<IPersonStreetAddressFormatterForCsv<Person>>().To<PersonStreetAddressFormatterForCsv>();
            container.Bind<IStreetAddressExtractor>().To<StreetNameExtractor>();

            container.Bind<IOrderFilterByName<Person, PeopleOrderByNameFrequency>>().To<PersonNameFrequencyFilter>();
            container.Bind<IOrderFilterByAddress<Person, Person>>().To<PersonAddressOrderFilter>();

            var csvProcessor = container.Get<CsvProcessor>();

            var processingFileNames = new[] { "sample-input-1", "sample-input-2", "sample-input-3" };
            var relativeFolder = @"data\";
            foreach (var csvFileName in processingFileNames)
            {
                // TODO :  Could have used a timer to calculate elapsed time.
                Console.WriteLine("- [Start] Processing file : " + csvFileName);
                var csvReadingPath = relativeFolder + csvFileName + @".csv";
                var csvNameFrequencyFilePath = relativeFolder + @"output\" + csvFileName + "-name-frequency.csv";
                var csvStreetFilterFilePath = relativeFolder + @"output\" + csvFileName + "-street-address-filtered-alphabetically.csv";

                // Reading Csv as collection of people (person).
                Console.WriteLine("- [Start] Reading person data from csv : " + csvReadingPath);
                var people = csvProcessor.ReadCsv(csvReadingPath);
                Console.WriteLine("- [Done] \"" + csvReadingPath + "\" file read successfully. We have total " + people.Count + " people.");

                // TODO : Also should have used a logger.
                // TODO : Could have refactor this to Action based delegates.

                // Start processing.

                // Task #1 : Show the frequency of the first and last names ordered by frequency and then alphabetically. 
                Console.WriteLine("- [Start] filtering : sorting first and last by frequency of descending and then alphabetically.");
                var nameFrequencyFilteredResults = csvProcessor.OrderFilterByName(people);
                Console.WriteLine("- [Done] filtering : sorting first and last by frequency of descending and then alphabetically.");
                var nameFrequencyFormatterForCsv = container.Get<PersonNameFrequencyFormatterForCsv>();
                Console.WriteLine("- [Start] writing csv : " + csvNameFrequencyFilePath + ".");
                csvProcessor.WriteAsCsvFile(nameFrequencyFilteredResults, nameFrequencyFormatterForCsv, csvNameFrequencyFilePath);
                Console.WriteLine("- [Done] writing csv : " + csvNameFrequencyFilePath + ".");

                // Task #2 : Show the addresses sorted alphabetically by street name.
                Console.WriteLine("- [Start] filtering : sorting address street name alphabetically.");
                var streetAddressFilteredAlphabeticallyResults = csvProcessor.OrderFilterByAddress(people);
                Console.WriteLine("- [Done] filtering : sorting address street name alphabetically.");
                var streetAddressFormatterForCsv = container.Get<PersonStreetAddressFormatterForCsv>();
                Console.WriteLine("- [Start] writing csv : " + csvStreetFilterFilePath);
                csvProcessor.WriteAsCsvFile(streetAddressFilteredAlphabeticallyResults, streetAddressFormatterForCsv, csvStreetFilterFilePath);
                Console.WriteLine("- [Done] writing csv : " + csvStreetFilterFilePath + ".");
                Console.WriteLine();
            }

            Console.WriteLine("- [Completed] : All operations are completed. Now press any key to exit.");
            Console.ReadKey();
        }
    }
}