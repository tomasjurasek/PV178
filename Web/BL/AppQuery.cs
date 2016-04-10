using DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class AppQuery<T> : EntityFrameworkQuery<T>
    {
        public new AppDbContext Context
        {
            get { return (AppDbContext)base.Context; }
        }

        public AppQuery(IUnitOfWorkProvider provider): base(provider)
        {

        }
    }
}
