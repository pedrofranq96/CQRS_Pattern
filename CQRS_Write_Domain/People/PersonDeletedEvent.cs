using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.People
{
    public class PersonDeletedEvent : Event
    {
        public PersonDeletedEvent(int aggregateId) : base()
        {
            AggregateId = aggregateId;
        }
    }
}
