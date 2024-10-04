using AutoMapper;
using MealPlanner.Data.Interfaces.Repositories.Product;
using MealPlanner.Web.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategoryResponse>> GetAllAsync()
        {
            var data = await _productCategoryRepository.GetAllAsync();

            var response = _mapper.Map<List<ProductCategoryResponse>>(data);

            return response;
        }
    }
}
