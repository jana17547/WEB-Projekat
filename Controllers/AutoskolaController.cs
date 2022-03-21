using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoskolaController : ControllerBase
    {
        public AutoSkolaContext Context { get; set; } 
        public AutoskolaController(AutoSkolaContext context)
        {
            Context = context;
        }

        
        [Route("DodajAutoskolu")] 
        [HttpPost]
        public async Task<ActionResult> DodajAutoskolu([FromBody] AutoSkola autoskola)
        {
            if (string.IsNullOrWhiteSpace(autoskola.Ime) || autoskola.Ime.Length > 50)
            {
                return BadRequest("Pogresno ime!");
            }

            if (string.IsNullOrWhiteSpace(autoskola.Tip) || autoskola.Tip.Length > 30)
            {
                return BadRequest("Pogresan tip!");
            }

            try
            {
                Context.AutoSkole.Add(autoskola);
                await Context.SaveChangesAsync();
                return Ok("Auto skola je dodata! ");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [Route("PreuzmiAutoskole")]
        [EnableCors("CORS")]
        [HttpGet]
        public async Task<ActionResult> Preuzmi()
        {
            try
            {
              var autoskole = Context.AutoSkole.Select(p => new{p.Ime, p.Tip, p.ID});
              return Ok(await autoskole.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

