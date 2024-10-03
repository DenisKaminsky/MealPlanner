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
            var a = await _demoCrudRepository.GetAllAsync();
            var b = await _demoCrudRepository.GetByIdAsync("66feb09aa72eef03cc03485c");
            var c = await _demoTransactionRepository.GetFirstByTitleAsync("Denis");
            var d = await _demoTransactionRepository.GetFirstByTitleAsync("Denis2");

            return Array.Empty<WeatherForecast>();
        }
    }
}
