using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities.Common;

namespace ECommerce.Domain.Entities
{
    public class Address : BaseEntity
    {
        public int Id { get; set; }
        public string District { get; set; }
        public string Description { get; set; }

        public City City { get; set; }  
    }
}
