using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TacoBellDB_API.Controllers
{
    [Route("api/[controller]")]
    public class TacoController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        //api/taco
        [HttpGet]
        public List<Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }
       
        //api/taco/(softshell)
        [HttpGet("{SoftShell}")]
        public List<Taco> GetBySoftShell(bool softShell)
        {
            return dbContext.Tacos.Where(t => t.SoftShell == softShell).ToList();
        }

        [HttpPost]
        public Taco AddTaco(string name, float cost, bool softShell, bool dorito)
        {
            Taco newTaco = new Taco()
            {
                Name = name,
                Cost = cost,
                SoftShell = softShell,
                Dorito = dorito
            };

            dbContext.Tacos.Add(newTaco);
            dbContext.SaveChanges();
            //ANY CHANGES TO DB (ADDING OR UPDATING) DON'T FORGET TO dbContext.SaveChanges()

            return newTaco;
        }

        //api/taco/id?name=(newName)
        [HttpPut("{id}")]
        public Taco ChangeTacoName(int id, string name)
        {
            Taco t = dbContext.Tacos.FirstOrDefault(t => t.Id == id);
            t.Name = name;

            dbContext.Tacos.Update(t);
            dbContext.SaveChanges();

            return t;
        }
    }
}
