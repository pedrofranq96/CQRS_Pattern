using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain
{
    public class AggregationRoute<T> : IAggregationRoute<T>
    {
        private List<IEvent> eventChanges = new List<IEvent>();
        public T Id { get; protected set; }

        public int Version { get; protected set; }

        public void ApplyChanges(IEvent @event, bool isNew = true)
        {
            var method = GetType().GetMethod("Apply", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { @event.GetType() }, null);

            if (method != null)
            {
                method.Invoke(this, new object[] { @event });
            }
            if (isNew)
            {
                @event.Version = eventChanges.Count() + 1;
                @event.Timestamp = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
                eventChanges.Add(@event);
            }
        }

        public object GetId()
        {
            return Id;
        }

        public IEnumerable<IEvent> GetUncommittedChanges()
        {
            return eventChanges;
        }

        public void LoadsFromHistory(IEnumerable<IEvent> history)
        {
            foreach (var @event in history)
            {
                ApplyChanges(@event, false);
            }
        }

        public void MarkChangesAsCommitted()
        {
            eventChanges.Clear();
        }
    }
}
