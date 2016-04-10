using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AppFacadeBase
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
    }
}
