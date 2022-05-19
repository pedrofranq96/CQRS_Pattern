using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.People
{
    public class PersonCreatedEvent : Event
    {
        public PersonClass PersonClass { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public PersonCreatedEvent(int aggregateId,PersonClass personClass, string name, int age)
        {
            AggregateId = aggregateId;
            PersonClass = personClass;
            Name = name;
            Age = age;
        }
    }
}
