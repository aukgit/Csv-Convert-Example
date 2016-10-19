using CsvConvertExample.DataLayer;
using CsvConvertExample.Implementations.FileIO;
using CsvConvertExample.Implementations.Formatters;
using CsvConvertExample.Interfaces.FileIO;
using CsvConvertExample.Interfaces.Formatter;
using CsvConvertExample.Interfaces.OrderFilters;
using Ninject;
namespace CsvConvertExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernal = new StandardKernel();
            kernal.Bind<ICsvReader<Person>>().To<CsvReaderForPeople>();
            kernal.Bind<IFileWriter>().To<CsvFileWriter>();
            kernal.Bind<IPersonNameFrequencyFormatterForCsv<PeopleOrderByNameFrequency>>().To<PersonNameFrequencyFormatterForCsv>();
            kernal.Bind<IPersonStreetAddressFormatterForCsv<Person>>().To<PersonStreetAddressFormatterForCsv>();
            kernal.Bind<IOrderFilterByName<Person>>().To<PersonStreetAddressFormatterForCsv>(); 
        }
    }
}