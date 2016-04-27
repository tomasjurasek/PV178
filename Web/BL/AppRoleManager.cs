using DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AppRoleManager : RoleManager<AppRole,int>
    {
        public AppRoleManager(IRoleStore<AppRole, int> store) : base(store)
        {

        }
    }
}
