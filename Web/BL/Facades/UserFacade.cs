using AutoMapper;
using BL.DTO;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class UserFacade : AppFacadeBase
    {
        public Func<AppUserManager> UserManagerFactory { get; set; }



        public void Register(AppUserDTO user, string password)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                using (var userManager = UserManagerFactory())
                {
                    AppUser appUser = Mapper.Map<AppUser>(user);


                    appUser.UserName = appUser.Email;

                    Task.Run(async () =>
                    {

                        var result = await userManager.CreateAsync(appUser,         user.Password);

                    }).Wait();

                    //userManager.Create(appUser, user.Password);

                }

                uow.Commit();
            }

        }


        public ClaimsIdentity Login(string email, string password)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                using (var userManager = UserManagerFactory())
                {
                    AppUser user;
                    try
                    {
                        user = userManager.Find(email, password);

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                    return userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                }
            }
        }
    }
}
