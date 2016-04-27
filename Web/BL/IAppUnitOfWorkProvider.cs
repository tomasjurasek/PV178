using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IAppUnitOfWorkProvider : IUnitOfWorkProvider
    {
        IAppUnitOfWork Create(DbContextOptions options);
        new IAppUnitOfWork Create();
        new IUnitOfWork GetCurrent();

    }
}
