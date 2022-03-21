using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KategorijaController : ControllerBase
    {
        public AutoSkolaContext Context { get; set; } 
        public KategorijaController(AutoSkolaContext context)
        {
            Context = context;
        }

        [Route("DodajKategoriju/{Naziv}/{Cena}/{IdAutoskole}/{IDInstruktora}")]
        [EnableCors("CORS")]
        [HttpPost]
        public async Task<ActionResult> DodajKategoriju(string Naziv, int Cena, int IdAutoskole, int IDInstruktora)
        {
            if (string.IsNullOrWhiteSpace(Naziv) || Naziv.Length > 50)
                return BadRequest($"Parametar 'Naziv kategorije' : {Naziv} nije moguc!");
            if (Cena < 0 || Cena > 100000)
                return BadRequest($"Parametar 'Cena kategorije' : {Cena} nije moguc!");

            try{
                var instruktor = await Context.Instruktori.Where(p => p.ID == IDInstruktora).FirstOrDefaultAsync();
                var autoskola = await Context.AutoSkole.Where(p => p.ID == IdAutoskole).FirstOrDefaultAsync();

                //provera
                if (instruktor == null)
                    throw new Exception("Ne postoji instruktor sa tim Id-jem.");
                if(autoskola == null)
                    throw new Exception("Ne postoji autoskola sa tim Id-jem.");
                
                Kategorija kat = new Kategorija();
                kat.Naziv = Naziv;
                kat.Cena = Cena;
                kat.Instruktor = instruktor;
                kat.AutoSkola = autoskola;

                Context.Kategorije.Add(kat);
                autoskola.Kategorije.Add(kat);

                await Context.SaveChangesAsync();

                return Ok("Kategorija je dodata.");         

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("PreuzmiKategorije/{AutoskolaID}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiKategorije(int AutoskolaID)
        {
            try
            {
                var autoskola = await Context.AutoSkole.Where(p => p.ID == AutoskolaID).FirstAsync();
                if(autoskola == null)
                {
                    throw new Exception("Ne postoji trazena Auto skola.");
                }

                var kategorije = await Context.Kategorije.Where(p => p.AutoSkola.ID == AutoskolaID).Select(p => new{
                    kategorijaID = p.ID,
                    kategorijaNaziv = p.Naziv,
                    kategorijaCena = p.Cena,
                    instruktorID = p.Instruktor.ID

                }).ToArrayAsync();
                return Ok(kategorije);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [EnableCors("CORS")]
        [Route("ObrisiKategoriju/{KategorijaID}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiKategoriju(int KategorijaID)
        {
           try{ 
            var kategorija = await Context.Kategorije.Where(p => p.ID == KategorijaID).FirstAsync();

            if(kategorija == null)
            {
                throw new Exception("Ne postoji kategorija sa tim Id-jem.");
            }

            var listaPolaganja = await Context.PolazeKategoriju.Where(p => p.Kategorija.ID == KategorijaID).ToListAsync();

            foreach(var lp in listaPolaganja)
            {
                Context.Remove(lp);
            }

            Context.Kategorije.Remove(kategorija);

            await Context.SaveChangesAsync();

            return Ok("Kategorija je obrisana.");
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }

        }

        [Route("PromeniInstruktora/{KategorijaID}/{InstruktorID}")]
        [EnableCors("CORS")]
        [HttpPut]
        public async Task<ActionResult> PromeniInstruktora(int KategorijaID, int InstruktorID)
        {
            try{
                var kat = await Context.Kategorije.Where(p => p.ID == KategorijaID).Include(p => p.Instruktor).ThenInclude(p => p.Kategorije).FirstOrDefaultAsync();

                if (kat == null)
                {
                    return BadRequest("Ne postoji trazena kategorija.");
                }

                var instruktor = await Context.Instruktori.Where(p => p.ID == InstruktorID).Include(p => p.Kategorije).FirstOrDefaultAsync();

                if (instruktor == null)
                {
                    return BadRequest("Ne postoji trazeni instruktor.");
                }

                kat.Instruktor.Kategorije.Remove(kat);
                instruktor.Kategorije.Add(kat);
                kat.Instruktor=instruktor;
                Context.Update(kat);
                Context.Update(instruktor);

                await Context.SaveChangesAsync();

                return Ok("Promenjen instruktor.");
            
               
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ZameniCenu/{KategorijaID}/{Cena}")]
        [EnableCors("CORS")]
        [HttpPut]
        public async Task<ActionResult> ZameniCenu(int KategorijaID, float Cena)
        {
            if (Cena < 0 || Cena >= 100000)
                return BadRequest("Nemoguca vrednost");
            try
            {
                var kategorija = await Context.Kategorije.Where(p => p.ID == KategorijaID).FirstAsync();
                if (kategorija == null)
                    throw new Exception("Ne postoji kategorija sa tim ID-jem!");
                kategorija.Cena = Cena;
                Context.Update(kategorija);

                await Context.SaveChangesAsync();

                return Ok("Uspesno promenjena cena kategorije!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}


