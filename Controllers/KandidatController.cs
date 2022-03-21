using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Models;
using System.Collections.Generic;


namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KandidatController : ControllerBase
    {
        public AutoSkolaContext Context { get; set; } 
        public KandidatController(AutoSkolaContext context)
        {
            Context = context;
        }

        [Route("DodajKandidata/{Jmbg}/{Ime}/{Prezime}")]
        [EnableCors("CORS")]
        [HttpPost]
        public async Task<ActionResult> DodajKandidata(string Jmbg, string Ime, string Prezime)
        {
            if (string.IsNullOrWhiteSpace(Jmbg) || Jmbg.Length > 13)
                return BadRequest("Pogresno unet parametar 'Jmbg'!");

            if (string.IsNullOrWhiteSpace(Ime) || Ime.Length > 50)
                return BadRequest("Pogresno unet parametar 'Ime'!");

            if (string.IsNullOrWhiteSpace(Prezime) || Prezime.Length > 50)
                return BadRequest("Pogresno unet parametar 'Prezime'!");

          try{
          
            Kandidat k = new Kandidat();
            k.Jmbg = Jmbg;
            k.Ime = Ime;
            k.Prezime = Prezime;

            Context.Kandidati.Add(k);
            await Context.SaveChangesAsync();

            return Ok("Dodat je kandidat.");
          }
          catch(Exception e)
          {
              return BadRequest(e.Message);
          }
        }

       [Route("VratiKandidateNaOsnovuJmbg/{JmbgKandidata}")]
       [EnableCors("CORS")]
       [HttpGet]
       public async Task<ActionResult> VratiKandidateNaOsnovuJmbg(string JmbgKandidata)
       {
            if (string.IsNullOrWhiteSpace(JmbgKandidata) || JmbgKandidata.Length > 13)
                return BadRequest($"Parametar 'Jmbg kandidata' : {JmbgKandidata} nije moguc!");

            try{
                var kandidat = await Context.Kandidati.Where(p => p.Jmbg == JmbgKandidata).ToListAsync(); 
                if (kandidat == null)
                {
                    throw new Exception("Ne postoji ucenik sa trazenim jmbg-om.");
                }
                return Ok(kandidat);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
       }

        [Route("ObrisiKandidata/{KandidatID}")]
        [EnableCors("CORS")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiKandidata(int KandidatID)
        {
            try
            {
                var kandidat = await Context.Kandidati.Where(p => p.ID == KandidatID).FirstAsync();
                if (kandidat == null)
                    throw new Exception("Ne postoji kandidat sa takvim ID-jem!");
                var lista = await Context.PolazeKategoriju.Where(p => p.Kandidat.ID == KandidatID).ToListAsync();

                foreach (var l in lista)
                {
                    Context.Remove(l);
                }
                Context.Remove(kandidat);
                await Context.SaveChangesAsync();
                return Ok($"Obrisan kandidat sa ID-jem {KandidatID}!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

    }
}