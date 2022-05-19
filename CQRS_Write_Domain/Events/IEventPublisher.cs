using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.Events
{
    public interface IEventPublisher
    {
        void RegisterEventHandlers(IEventHandler eventHandler);
        void Publish<T>(T @event) where T : IEvent;
    }
}
