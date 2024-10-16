﻿using AutoMapper;
using MealPlanner.Data.Interfaces.Repositories.Product;
using MealPlanner.Web.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers.Product
{
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _productRepository.GetAllAsync();

            var response = Mapper.Map<List<ProductWithCategoryResponse>>(data);

            var sorted = response
                .OrderBy(x => x.CategoryId)
                .ThenBy(x => x.Name)
                .ToList();

            return Ok(sorted);
        }
    }
}
