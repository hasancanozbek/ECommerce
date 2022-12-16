using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository productWriteRepository;
        private readonly IProductReadRepository productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            this.productWriteRepository = productWriteRepository;
            this.productReadRepository = productReadRepository;
        }

        [HttpGet]
        public void Get()
        {
            productWriteRepository.AddAsync(new List<Product>()
            {
                new(){Id = Guid.NewGuid(), Name = "Kalem", Price = 100, Stock = 5, CreatedDate = DateTime.UtcNow},
                new(){Id = Guid.NewGuid(), Name = "Kalem2", Price = 100, Stock = 5, CreatedDate = DateTime.UtcNow},
                new(){Id = Guid.NewGuid(), Name = "Kalem3", Price = 100, Stock = 5, CreatedDate = DateTime.UtcNow}
            });
            productWriteRepository.SaveAsync();
        }
    }
}
