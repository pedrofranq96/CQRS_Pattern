using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.People
{
    public class Person : AggregationRoute<int>
    {
        public PersonType Class { get; set; }
        public Person()
        {

        }

        public Person(int id, PersonClass personClass, string name, int age)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("name");
            
             this.ApplyChanges(new PersonCreatedEvent(id, personClass, name, age));
        }
        public Person(PersonClass personClass, string name, int age)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("name");

            this.ApplyChanges(new PersonCreatedEvent(0, personClass, name, age));
        }

        public void Rename(string name)
        {
            ApplyChanges(new PersonRenamedEvent(Id, name));
        }

        public void Delete()
        {
            ApplyChanges(new PersonDeletedEvent(Id));
        }
        private void Apply(PersonRenamedEvent @event)
        {
            Id = @event.AggregateId;
            Class = new PersonType(Class.PersonClass, @event.Name, Class.Age);
        }
        public override string ToString()
        {
            return $"{Class.Name}: [Class]{Class}, [Name]{Class.Name}, [Age]{Class.Age}";
        }
    }
}
