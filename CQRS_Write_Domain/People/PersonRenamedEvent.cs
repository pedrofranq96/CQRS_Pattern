using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.People
{
    public class PersonRenamedEvent : Event
    {
        public string Name { get; }
        public PersonRenamedEvent(int aggregateId, string name): base()
        {
            AggregateId = aggregateId;
            Name = name;
        }
    }


}
