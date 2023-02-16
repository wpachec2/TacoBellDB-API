using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TacoBellDB_API.Controllers
{
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        //api/drink
        [HttpGet]
        public List<Drink> GetAll()
        {
            return dbContext.Drinks.ToList();
        }

        //api/drink/(id)
        [HttpGet("{id}")]
        public Drink GetByName(int id)
        {
            return dbContext.Drinks.FirstOrDefault(d => d.Id == id);
        }

        [HttpDelete("{id}")]
        public Drink DeleteById(int id)
        {
            Drink d = dbContext.Drinks.FirstOrDefault(d => d.Id == id);

            dbContext.Drinks.Remove(d);
            dbContext.SaveChanges();

            return d;
        }
    }
}

