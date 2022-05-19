using CQRS_read_Application.People;
using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.People
{
    public class PersonEventHandlers : IEventHandler<PersonCreatedEvent>, IEventHandler<PersonDeletedEvent>, IEventHandler<PersonRenamedEvent>
    {
        private readonly IPersonService _service;

        public PersonEventHandlers(IPersonService service)
        {
            _service = service;
        }
        public void Handle(PersonCreatedEvent @event)
        {
            CQRS_read_Infrastructure.Persistence.People.Person person=
                new CQRS_read_Infrastructure.Persistence.People.Person
                (@event.AggregateId,
                (CQRS_read_Infrastructure.Persistence.People.PersonClass)
                @event.PersonClass, @event.Name, @event.Age);
            _service.Insert(person);
        }

        public void Handle(PersonDeletedEvent @event)
        {
            _service.Delete(@event.AggregateId);
        }

        public void Handle(PersonRenamedEvent @event)
        {

            var person = _service.Find(@event.AggregateId);
            person.Name = @event.Name;
            _service.Update(person);
            
        }
    }
}
