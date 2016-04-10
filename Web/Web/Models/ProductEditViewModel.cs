using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ProductEditViewModel
    {
        public ProductDTO Product { get; set; }

        public List<CategoryDTO> Categories { get; set; }
        public int[] SelectedCategories { get; set; }

        public ProductEditViewModel()
        {
            Categories = new List<CategoryDTO>();
        }
    }
} 