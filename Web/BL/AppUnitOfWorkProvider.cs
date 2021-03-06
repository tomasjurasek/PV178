﻿using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AppUnitOfWorkProvider : EntityFrameworkUnitOfWorkProvider, IAppUnitOfWorkProvider
    {
        public AppUnitOfWorkProvider(IUnitOfWorkRegistry registry, Func<DbContext> dbContextFactory) : base(registry, dbContextFactory)
        {
        }

        protected override EntityFrameworkUnitOfWork CreateUnitOfWork(Func<DbContext> dbContextFactory, DbContextOptions options)
        {
            return new AppUnitOfWork(this, dbContextFactory, options);
        }

        IAppUnitOfWork IAppUnitOfWorkProvider.Create(DbContextOptions options)
        {
            return (IAppUnitOfWork)base.Create(options);
        }

        IAppUnitOfWork IAppUnitOfWorkProvider.Create()
        {
            return (IAppUnitOfWork)base.Create();
        }
    }
}
