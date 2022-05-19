using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Write_Domain.People
{
    [Flags]
    public enum PersonClass
    {
        Comum,
        Admin
    }
}
