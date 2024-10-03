using MealPlanner.Data.Interfaces.DTO.Demo;
using MealPlanner.Data.Interfaces.Repositories.Demo;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers.Demo
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;

        private readonly IDemoCrudRepository _demoCrudRepository;
        private readonly IDemoTransactionRepository _demoTransactionRepository;

        public DemoController(ILogger<DemoController> logger, IDemoCrudRepository demoCrudRepository, IDemoTransactionRepository demoTransactionRepository)
        {
            _logger = logger;
            _demoCrudRepository = demoCrudRepository;
            _demoTransactionRepository = demoTransactionRepository;
        }

        [HttpGet(Name = "GetDemo")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var getAllResult = await _demoCrudRepository.GetAllAsync();
            var getByTitleResult = await _demoCrudRepository.GetAsync(x => x.Title == "Denis");
            var getFirstByTitleResult = await _demoCrudRepository.GetFirstAsync(x => x.Title == "Denis");

            var newId = await _demoCrudRepository.CreateAsync(new DemoTestDTO { Title = "Test1", Price = 11.1 } );
            var getByIdResult = await _demoCrudRepository.GetByIdAsync(newId);

            var toCreate = new List<DemoTestDTO>
            {
                new DemoTestDTO { Title = "Test2", Price = 21.2 },
                new DemoTestDTO { Title = "Test3", Price = 31.3 }
            };

            await _demoCrudRepository.CreateManyAsync(toCreate);

            return Array.Empty<WeatherForecast>();
        }
    }
}
