using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AppUserStore : UserStore<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public AppUserStore(IAppUnitOfWorkProvider unitOfWorkProvider)
           : base((unitOfWorkProvider.GetCurrent() as AppUnitOfWork)?.AppDbContext)
        {
        }
    }
}
