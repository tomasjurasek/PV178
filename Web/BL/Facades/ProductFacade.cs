using AutoMapper;
using BL.DTO;
using BL.Queries;
using BL.Repositories;
using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class ProductFacade : AppFacadeBase
    {
        private readonly CategoryFacade categoryFacade;

        public ProductRepository Repository { get; set; }

        public ProductListQuery ProductListQuery { get; set; }

        public ProductFacade(CategoryFacade categoryFacade)
        {
            this.categoryFacade = categoryFacade;
        }
        protected IQuery<ProductDTO> CreateQuery(ProductFilter filter)
        {
            var query = ProductListQuery;
            query.Filter = filter;
            return query;
        }

        public ProductDTO GetProductById(int productId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appProduct = Repository.GetById(productId);
                return Mapper.Map<ProductDTO>(appProduct);
            }
        }

        public void UpdateProduct(ProductDTO product, int[] selectedCategories)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                IList<Category> category = new List<Category>();
                if (selectedCategories != null)
                {
                    category = categoryFacade.Repository.GetByIds(selectedCategories);
                }

                var appProduct = Repository.GetById(product.Id);
                Mapper.Map(product, appProduct);

                appProduct.Categories = category.ToList();
                
                Repository.Update(appProduct);
                uow.Commit();
            }
        }
        public List<ProductDTO> GetAllProducts()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new ProductFilter { }).Execute().ToList();
            }
        }

        public List<ProductDTO> GetProductsByCategory(int categoryId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new ProductFilter { CategoryId = categoryId }).Execute().ToList();
            }
        }

        public void CreateProduct(ProductDTO product, int[] selectedCategories)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                IList<Category> category = new List<Category>();
                if (selectedCategories != null)
                {
                    category = categoryFacade.Repository.GetByIds(selectedCategories);
                }

                var dalProduct = Mapper.Map<Product>(product);
                dalProduct.Categories = category.ToList();
                Repository.Insert(dalProduct);
                uow.Commit();
            }
        }
    }
}
