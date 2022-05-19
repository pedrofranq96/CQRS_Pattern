using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CQRS_read_Infrastructure.Persistence.People
{
    [Flags]
    public enum PersonClass
    {
        Comum,
        Admin
    }

    public class Person
    {
        public int Id { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public PersonClass PersonClass { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(int id, PersonClass personClass, string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            
            Id = id;
            PersonClass = personClass;
            Name = name;
            Age = age;
        }

        public Person(PersonClass personClass, string name, int age)
        {
            Id = -1;
            PersonClass = personClass;
            Name = name;
            Age = age;
        }


        public override string ToString()
        {
            return $"{PersonClass}:[Class]{PersonClass}, [Name]{Name}, [Age]{Age}";
        }
    }
}
