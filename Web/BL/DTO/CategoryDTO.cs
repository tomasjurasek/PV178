using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class CategoryDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryDTO()
        {
            
        }
    }
}
