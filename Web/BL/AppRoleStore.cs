using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AppRoleStore : RoleStore<AppRole, int, AppUserRole>
    {
        public AppRoleStore(IAppUnitOfWorkProvider unitOfWorkProvider)
           : base((unitOfWorkProvider.GetCurrent() as AppUnitOfWork)?.AppDbContext)
        {
        }
    }
}
