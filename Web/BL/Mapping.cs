using AutoMapper;
using BL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Mapping
    {

        public static void Create()
        {

            Mapper.CreateMap<Category, CategoryDTO>();
            Mapper.CreateMap<CategoryDTO, Category>();

            Mapper.CreateMap<Product, ProductDTO>();
            Mapper.CreateMap<ProductDTO, Product>();
        }
    }
}
