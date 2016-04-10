using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public double Price { get; set; }
        public virtual List<Category> Categories { get; set; }

        public Product()
        {
            Categories = new List<Category>();
        }
    }
}
