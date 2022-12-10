using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities.Common;

namespace ECommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
