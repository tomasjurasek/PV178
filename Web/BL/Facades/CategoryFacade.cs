using AutoMapper;
using BL.DTO;
using BL.Queries;
using BL.Repositories;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class CategoryFacade : AppFacadeBase
    {
        public CategoryRepository Repository { get; set; }

        public CategoryListQuery CategoryListQuery { get; set; }


        protected IQuery<CategoryDTO> CreateQuery()
        {
            var query = CategoryListQuery;
            return query;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery().Execute().ToList();
            }
        }

        public List<CategoryDTO> GetCategoriesByIds(int[] ids)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appCategories = Repository.GetByIds(ids);
                return Mapper.Map<List<CategoryDTO>>(appCategories);
            }
        }
       
    }
}
