using FizzBuzzApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public IActionResult ProcessValues([FromBody] string[] values)
        {
            var results = _fizzBuzzService.ProcessValues(values);
            return Ok(results);
        }
    }

}
