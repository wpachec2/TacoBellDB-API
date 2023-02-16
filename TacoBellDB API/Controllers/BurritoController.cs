using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TacoBellDB_API.Controllers
{
    [Route("api/[controller]")]
    public class BurritoController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        //api/burrito
        [HttpGet]
        public List<Burrito> GetAll()
        {
            return dbContext.Burritos.ToList();
        }

        //api/burrito/(id)
        [HttpGet("{id}")]
        public Burrito GetByName(int id)
        {
            return dbContext.Burritos.FirstOrDefault(b => b.Id == id);
        }

        [HttpPost]
        public Burrito AddBurrito(string name, float cost, bool bean)
        {
            Burrito newBurrito = new Burrito()
            {
                Name = name,
                Cost = cost,
                Bean = bean
            };

            dbContext.Burritos.Add(newBurrito);
            dbContext.SaveChanges();
            //ANY CHANGES TO DB (ADDING OR UPDATING) DON'T FORGET TO dbContext.SaveChanges()

            return newBurrito;
        }
    }
}
