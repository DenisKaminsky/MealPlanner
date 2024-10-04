using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        protected readonly IMapper Mapper;

        public BaseAPIController(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
