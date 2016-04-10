using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        //[Range(0, Double.MaxValue, ErrorMessage = "Není možné zadat zápornou cenu zboží")]
        public double Price { get; set; }

        public List<CategoryDTO> Categories { get; set; }

        public ProductDTO()
        {
            Categories = new List<CategoryDTO>();
        }
    }
}
