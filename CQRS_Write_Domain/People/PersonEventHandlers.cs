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
            throw new NotImplementedException();
        }

        public void Handle(PersonDeletedEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Handle(PersonRenamedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
