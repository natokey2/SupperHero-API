using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupperHeroController : ControllerBase
    {

        private static List<SupperHero> heroes = new List<SupperHero>
        {
             new SupperHero
                {
                    Id=1,
                    Name="spider man",
                    FirstName="natiq",
                    LastName="hawrami",
                    Place="stokholm"
                },
                 new SupperHero
                {
                    Id=2,
                    Name="spider man",
                    FirstName="natiq",
                    LastName="hawrami",
                    Place="stokholm"
                }
        };

        [HttpGet]
        public async Task<ActionResult<List<SupperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<SupperHero>>> Get (int id)
        {
            var hero = heroes.Find(h=> h. Id==id);
            if(hero == null)
            return  BadRequest("hero not found.");
            return Ok(hero);
        }

        [HttpPost]

        public async Task<ActionResult<List<SupperHero>>> AddHero(SupperHero hero){
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SupperHero>>> UpdateHero(SupperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if(hero== null)
            return BadRequest("hero not found .");

            hero.Name="request.Name";
            hero.FirstName="request.Firstname";
            hero.LastName="request.Lastname";
            hero.Place = "request.place";
            
            return Ok(heroes);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SupperHero>>> delete (int id)
        {
            var hero = heroes.Find(h=> h. Id==id);
            if(hero == null)
            return  BadRequest("hero not found.");

            heroes.Remove(hero);
            return Ok(heroes);
        }

    }   
}