using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities.Common;

namespace ECommerce.Domain.Entities
{
    public class City : BaseEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        public ICollection<City> Addresses { get; set; }
    }
}
