using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvConvertExample.DataLayer;

namespace CsvConvertExampleUnitTest
{
    public static class Generator
    {
        private static List<Person> _people;

        /// <summary>
        /// Get generated people as mock up or fake object.
        /// </summary>
        public static List<Person> People
        {
            get
            {
                if (_people == null)
                {
                    _people = GenerateListOfPeople();
                }

                return _people;
            }

            private set
            {
                _people = value;
            }
        }

        private static List<Person> GenerateListOfPeople()
        {
            var people = new List<Person>
            {
                new Person
                {
                    FirstName = "Alice",
                    LastName = "Roman",
                    PhoneNumber = 9198298,
                    Address = "94 Roland St",
                    StreetAddress = "Roland St"
                },
                new Person
                {
                    FirstName = "Alim",
                    LastName = "Karim",
                    PhoneNumber = 83300202,
                    Address = "94 Dhaka Bangladesh",
                    StreetAddress = "Dhaka Bangladesh"
                },
                new Person
                {
                    FirstName = "Jackson",
                    LastName = "Don",
                    PhoneNumber = 12324421,
                    Address = "8 Crimson Rd",
                    StreetAddress = "Crimson Rd"
                },
                new Person
                {
                    FirstName = "Jhon",
                    LastName = "Doe",
                    PhoneNumber = 1234112,
                    Address = "78 Short Lane",
                    StreetAddress = "Short Lane"
                },
                new Person
                {
                    FirstName = "Karim",
                    LastName = "Alim",
                    PhoneNumber = 1234112,
                    Address = "78 Short Lane",
                    StreetAddress = "Short Lane"
                }
            };

            people.Add(people[1]);
            people.Add(people[3]);
            people.Add(people[2]);
            people.Add(people[2]);
            people.Add(people[2]);
            people.Add(people[2]);
            people.Add(people[0]);
            people.Add(people[0]);
            people.Add(people[0]);
            people.Add(people[0]);
            people.Add(people[0]);
            people.Add(people[4]);
            people.Add(people[4]);
            people.Add(people[4]);
            people.Add(people[4]);
            people.Add(people[3]);
            people.Add(people[3]);
            people[people.Count - 1].FirstName = people[0].LastName;
            people[people.Count - 5].FirstName = people[0].LastName;
            people[people.Count - 3].FirstName = people[2].LastName;
            people[people.Count - 3].Address = people[2].Address;
            people[people.Count - 3].StreetAddress = people[2].StreetAddress;

            return people.Concat(people).ToList();
        }
    }
}
