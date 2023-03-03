using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entity.Entities
{
    public class Category:EntityBase
    {
        public string CategoryName { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
