using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class CategoryRepository : EntityFrameworkRepository<Category, int>
    {
        public CategoryRepository(IUnitOfWorkProvider provider) : base(provider)
        {
        }
    }
}
