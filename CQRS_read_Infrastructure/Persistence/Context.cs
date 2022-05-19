using CQRS_read_Infrastructure.Persistence.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_read_Infrastructure.Persistence
{
    public class Context : IContext
    {
        public IPersonRepository People { get; set; }
        public Context(IPersonRepository personRepository)
        {
            People = personRepository;
        }

        
    }
}
