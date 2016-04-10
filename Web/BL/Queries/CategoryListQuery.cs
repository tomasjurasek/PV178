using BL.DTO;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using DAL.Entities;

namespace BL.Queries
{
    public class CategoryListQuery : AppQuery<CategoryDTO>
    {
        public CategoryListQuery(IUnitOfWorkProvider provider) : base(provider)
        {

        }
        protected override IQueryable<CategoryDTO> GetQueryable()
        {
            IQueryable<Category> query = Context.Categories;
            
            return query.Project().To<CategoryDTO>();
        }
    }
}
