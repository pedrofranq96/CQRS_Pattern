using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain
{
    public interface IAggregationRoute <T> : IAggregationRoute
    {
        T Id { get; }
    }
    public interface IAggregationRoute
    {
        object GetId();
        int Version { get; }

        IEnumerable<IEvent> GetUncommittedChanges();

        void MarkChangesAsCommitted();

        void LoadsFromHistory(IEnumerable<IEvent> history);

        void ApplyChanges(IEvent @event, bool isNew = true);
    }
}
