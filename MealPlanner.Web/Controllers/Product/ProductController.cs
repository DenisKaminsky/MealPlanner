using AutoMapper;
using MealPlanner.Data.Interfaces.Repositories.Product;
using MealPlanner.Web.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseAPIController
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository, IMapper mapper) : base(mapper)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetByCategory/{categoryId}")]
        public async Task<IActionResult> GetByCategory(string categoryId)
        {
            var data = await _productRepository.GetByCategoryAsync(categoryId);

            var response = Mapper.Map<List<ProductResponse>>(data);

            return Ok(response);
        }

        [HttpGet("Search/{name}")]
        public async Task<IActionResult> Search(string name)
        {
            var data = await _productRepository.SearchByNameAsync(name);

            var response = Mapper.Map<List<ProductResponse>>(data);

            return Ok(response);
        }
    }
}
