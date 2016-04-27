using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DAL;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DataInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                Component.For<Func<DbContext>>()
                    .Instance(() => new AppDbContext())
                    .LifestyleTransient(),

                Component.For<IAppUnitOfWorkProvider, IUnitOfWorkProvider>()
                    .ImplementedBy<AppUnitOfWorkProvider>()
                    .LifestyleSingleton(),

                Component.For<IUnitOfWorkRegistry>()
                    .Instance(new HttpContextUnitOfWorkRegistry(new ThreadLocalUnitOfWorkRegistry()))
                    .LifestyleSingleton(),

                Classes.FromAssemblyContaining<AppUnitOfWork>()
                    .BasedOn(typeof(AppQuery<>))
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<AppUnitOfWork>()
                    .BasedOn(typeof(IRepository<,>))
                    .LifestyleTransient(),

                Component.For(typeof(IRepository<,>))
                    .ImplementedBy(typeof(EntityFrameworkRepository<,>))
                    .LifestyleTransient(),

                Component.For<AppUserManager>()
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<AppFacadeBase>()
                    .BasedOn<AppFacadeBase>()
                    .LifestyleTransient(),

                

                Component.For<IUserStore<AppUser, int>>()
                    .ImplementedBy<AppUserStore>()
                    .LifestyleTransient()

                
            );

            container.Resolve<IAppUnitOfWorkProvider>();

            Mapping.Create();

        }
    }
}
