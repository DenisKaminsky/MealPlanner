﻿using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Product;
using MealPlanner.Data.Interfaces.Repositories.Product;
using MealPlanner.Web.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers.Product
{
    public class MyProductController : BaseAPIController
    {
        private readonly IMyProductRepository _myProductRepository;

        public MyProductController(IMyProductRepository myProductRepository, IMapper mapper) : base(mapper)
        {
            _myProductRepository = myProductRepository;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _myProductRepository.GetAllAsync();

            var response = Mapper.Map<List<GetMyProductResponse>>(data);

            var sorted = response
                .OrderBy(x => x.CategoryId)
                .ThenBy(x => x.ProductName)
                .ToList();

            return Ok(sorted);
        }

        [HttpPost("Save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SaveAsync(List<SaveMyProductRequest> myProductRequests)
        {
            var data = SanitizeMyProductRequest(myProductRequests);
            var request = Mapper.Map<List<SaveMyProductDTO>>(data);

            await _myProductRepository.SaveAsync(request);

            return Created();
        }


        private List<SaveMyProductRequest> SanitizeMyProductRequest(List<SaveMyProductRequest> request)
        {
            var sanitizedData = request
                .GroupBy(x => x.ProductId)
                .Select(x => x.First())
                .ToList();
            foreach (var item in sanitizedData.Where(item => item.Quantity < 0))
            {
                item.Quantity = 0;
            }

            return sanitizedData;
        }
    }
}
