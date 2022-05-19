using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.People
{
    public struct PersonType 
    {
        public PersonClass PersonClass { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public PersonType(PersonClass personClass, string name, int age)
        {
            PersonClass = personClass;
            Name = name;
            Age = age;
        }
    }
}
