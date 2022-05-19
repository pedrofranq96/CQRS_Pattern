using CQRS_Write_Domain;
using CQRS_Write_Domain.Commands;
using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Infrastructure.Commands
{
    public class CommandEventRepository : ICommandEventRepository
    {
        private IEventPublisher _eventPublisher;
        private Dictionary<object, List<IEvent>> aggregateEventsDictonary = new Dictionary<object, List<IEvent>>();

        public CommandEventRepository(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public T GetByCommand<T>(object aggregationId) where T : IAggregationRoute
        {
            T aggragate = (T)Activator.CreateInstance(typeof(T));
            List<IEvent> aggregateEvents;
            if (aggregateEventsDictonary.TryGetValue(aggregationId, out aggregateEvents))
            {
                aggragate.LoadsFromHistory(aggregateEvents);
                return aggragate;
            }
            return default(T);
        }

        public IEnumerable<IEvent> GetEvent(object aggregationId)
        {
            List<IEvent> aggregateEvents;
            if (aggregateEventsDictonary.TryGetValue(aggregationId, out aggregateEvents))
            {
                return aggregateEvents;
            }
            return new List<IEvent>();
        }

        public void Save(IAggregationRoute aggregation)
        {
            List<IEvent> aggregateEvents;
            if (!aggregateEventsDictonary.TryGetValue(aggregation.GetId(), out aggregateEvents))
            {
                aggregateEvents = new List<IEvent>();
                aggregateEventsDictonary.Add(aggregation.GetId(), aggregateEvents);
            }
            foreach (var @event in aggregation.GetUncommittedChanges())
            {
                aggregateEvents.Add(@event);
                _eventPublisher.Publish(@event);
            }
            aggregation.MarkChangesAsCommitted();
        }
    }
}
