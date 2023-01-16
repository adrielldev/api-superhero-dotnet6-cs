using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_superhero_dotnet6_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SuperHeroController : ControllerBase
    {
         private static List<SuperHero> heroes = new List<SuperHero> {};
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id )
        {
           var hero = heroes.Find(h=>h.Id ==id);
            if(hero == null) return BadRequest("Hero not found");
            return Ok(hero);
        }

        [HttpPost]
       public async Task<IActionResult> AddHero([FromBody]SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h=>h.Id == request.Id);
            if (hero == null) 
                return BadRequest("Hero not found");
            
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            return Ok(heroes);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hero = heroes.Find(h=>h.Id == id);
            if (hero == null) 
                return BadRequest("Hero not found");
            
            heroes.Remove(hero);
            return Ok(hero);
        }
    }
} 