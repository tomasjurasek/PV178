using DAL;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        AppDbContext AppDbContext { get; }
    }
}
