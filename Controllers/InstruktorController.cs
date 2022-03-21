using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstruktorController : ControllerBase
    {
        public AutoSkolaContext Context { get; set; } 
        public InstruktorController(AutoSkolaContext context)
        {
            Context = context;
        }


        [Route("DodajInstruktora/{Ime}/{Prezime}")]
        [EnableCors("CORS")]
        [HttpPost]
        public async Task<ActionResult> DodajInstruktora(string Ime, string Prezime)
        {
            if (string.IsNullOrWhiteSpace(Ime) || Ime.Length > 50)
                return BadRequest("Pogresno unet parametar 'Ime'!");

            if (string.IsNullOrWhiteSpace(Prezime) || Prezime.Length > 50)
                return BadRequest("Pogresno unet parametar 'Prezime'!");

          
            try
            {
                Instruktor i = new Instruktor();
                i.Ime = Ime;
                i.Prezime = Prezime;
                Context.Instruktori.Add(i);
                await Context.SaveChangesAsync();

                return Ok($"Instruktor je dodat: {i.ID} {Ime} {Prezime} ");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [EnableCors("CORS")]
        [HttpGet]
        [Route("VratiInstruktora/{InstruktorID}")]
        public async Task<ActionResult> VratiInstruktora(int InstruktorID)
        {
            try
            {
                var instruktor = await Context.Instruktori.Where(p => p.ID == InstruktorID).Select(inst => new {inst.ID, inst.Ime, inst.Prezime }).FirstAsync();

                //provera da li postoji instruktor sa trazenim id
                if (instruktor == null)
                    throw new Exception("Ne postoji trazeni instruktor");
                return Ok(instruktor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

          
        
        [Route("VratiInstruktoreZaTrazenuAutoSkolu/{AutoskolaID}")]
        [EnableCors("CORS")]
        [HttpGet]
        public async Task<ActionResult> VratiInstruktoreZaTrazenuAutoSkolu(int AutoskolaID)
        {
            try
            {
                var autoskola = await Context.AutoSkole.Where(p => p.ID == AutoskolaID).FirstAsync();

                if (autoskola == null)
                    throw new Exception("Trazena Autoskola ne postoji!");

                var instruktori = await Context.Instruktori.Include(p => p.Kategorije).Where(p => p.Kategorije.Any(kat => kat.AutoSkola.ID == 
                AutoskolaID) || p.Kategorije.Count() == 0).Select( p => new { p.ID, p.Ime, p.Prezime, brojKategorija = p.Kategorije.Count() } ).ToListAsync();

                return Ok(instruktori);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("IzbrisiInstruktora/{InstruktorID}")]
        [EnableCors("CORS")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiInstruktora(int InstruktorID)
        {
            try
            {
                var instruktor = await Context.Instruktori.Where(p => p.ID == InstruktorID).Include(p => p.Kategorije).FirstAsync();

                if (instruktor == null)
                    throw new Exception("Ne postoji takav instruktor");

                //proveravamo da li instruktor mozda predaje na jos nekoj kategoriji, i ukoliko postoji kategorija, ne mozemo da ga obrisemo
                if (instruktor.Kategorije.Count() > 0)
                    return BadRequest("Nije moguce obrisati instruktora, jer jos uvek postoji kategorija na kojoj on predaje!");

                Context.Remove(instruktor);

                await Context.SaveChangesAsync();

                return Ok("Instruktor je obrisan!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
      


        


            
        
       

    }
}