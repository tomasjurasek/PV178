using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ProductViewModel
    {
        public List<ProductDTO> Products { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public ProductViewModel()
        {
            Products = new List<ProductDTO>();
            Categories = new List<CategoryDTO>();
        }
    }
}