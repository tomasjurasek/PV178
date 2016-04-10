using AutoMapper.QueryableExtensions;
using BL.DTO;
using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Queries
{
    public class ProductListQuery : AppQuery<ProductDTO>
    {
        public ProductFilter Filter { get; set; }
        public ProductListQuery(IUnitOfWorkProvider provider) : base(provider)
        {
        }
        protected override IQueryable<ProductDTO> GetQueryable()
        {
            IQueryable<Product> query = Context.Products;

            if (!string.IsNullOrEmpty(Filter.ProductName))
            {
                query = Context.Products.Where(s => s.Name == Filter.ProductName);
            }

            if(Filter.CategoryId > 0)
            {
                query = Context.Products.Where(s => s.Categories.Any(c=>c.Id==Filter.CategoryId));
            }

            return query.Project().To<ProductDTO>();
        }
    }
}
