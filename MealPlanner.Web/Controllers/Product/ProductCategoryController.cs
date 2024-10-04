using AutoMapper;
using MealPlanner.Data.Interfaces.Repositories.Product;
using MealPlanner.Web.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : BaseAPIController
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository, IMapper mapper) : base(mapper)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _productCategoryRepository.GetAllAsync();

            var response = Mapper.Map<List<ProductCategoryResponse>>(data);

            return Ok(response);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryWithProducts(string categoryId)
        {
            var data = await _productCategoryRepository.GetCategoryWithProductsAsync(categoryId);
            if (data == null)
            {
                return NotFound();
            }

            var response = Mapper.Map<ProductCategoryWithProductsResponse>(data);

            return Ok(response);
        }
    }
}
