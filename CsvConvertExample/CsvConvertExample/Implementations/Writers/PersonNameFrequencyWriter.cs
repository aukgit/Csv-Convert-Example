#region using block

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvConvertExample.DataLayer;
using CsvConvertExample.Interfaces;

#endregion

namespace CsvConvertExample.Implementations.Writers
{
    public class PersonNameFrequencyWriter : IFileWriter<PeopleOrderByNameFrequency>
    {
        #region IFileWriter<object> Members

        public bool Write(List<PeopleOrderByNameFrequency> names, string spliter, string filepath)
        {
            var sb = new StringBuilder((names.Count * 5) + 5);
            sb.AppendLine("FirstName" + spliter + "LastName" + spliter + "Frequency");
            foreach (var name in names)
            {
                var topName = name.People.FirstOrDefault();
                if (topName != null)
                {
                    sb.AppendLine(topName.FirstName + spliter + topName.LastName + spliter + name.Count);
                }
            }

            StreamWriter file = new StreamWriter(filepath);
            file.WriteLine(sb.ToString()); // "sb" is the StringBuilder
            return false;
        }

        #endregion

    }
}