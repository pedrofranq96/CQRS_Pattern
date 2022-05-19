using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.Events
{
    public class Event : IEvent
    {
        public long Timestamp { get; set; }
        public int AggregateId { get; set; }

        public string Type { get; }

        public int Version { get; set; }
    }
}
