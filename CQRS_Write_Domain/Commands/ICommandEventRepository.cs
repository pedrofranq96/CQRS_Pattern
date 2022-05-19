using CQRS_Write_Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.Commands
{
    public interface ICommandEventRepository
    {
        void Save(IAggregationRoute aggregation);
        T GetByCommand<T>(object aggregationId) where T : IAggregationRoute;
        IEnumerable<IEvent> GetEvent(object aggregationId);
    }
}
