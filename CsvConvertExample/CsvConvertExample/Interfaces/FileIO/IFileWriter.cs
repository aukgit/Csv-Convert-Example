namespace CsvConvertExample.Interfaces.FileIO
{
    public interface IFileWriter
    {
        bool Write(string filepath, string content);
    }
}