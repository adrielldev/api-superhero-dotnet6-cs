using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_superhero_dotnet6_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SuperHeroController : ControllerBase
    {
         private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id = 1,
                    Name="Spider Man",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York City"
                    }
            };
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            return Ok(heroes);
        }

        [HttpPost]
       public async Task<IActionResult> AddHero([FromBody]SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }
    }
} 