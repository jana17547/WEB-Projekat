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
    public class PolazeController : ControllerBase
    {
        public AutoSkolaContext Context { get; set; } 
        public PolazeController(AutoSkolaContext context)
        {
            Context = context;
        }

          
        
        [Route("UpisiKandidata/{KandidatID}/{KategorijaID}")]
        [EnableCors("CORS")]
        [HttpPost]
        public async Task<ActionResult> UpisiKandidata(int KandidatID, int KategorijaID)
        {
            try
            {
                var kandidat = await Context.Kandidati.Where(p => p.ID == KandidatID).FirstAsync();
                if (kandidat == null)
                    throw new Exception("Ne postoji kandidat sa tim ID-jem!");

                var kategorija = await Context.Kategorije.Where(p => p.ID == KategorijaID).FirstAsync();
                if (kategorija == null)
                    throw new Exception("Ne postoji kategorija sa tim ID-jem!");

                Polaze p = new Polaze();
                p.Kandidat = kandidat;
                p.Kategorija = kategorija;
                Context.PolazeKategoriju.Add(p);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno upisan kandidat u kategoriju!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [EnableCors("CORS")]
        [HttpPut]
        [Route("UpisiPoene/{KandidatID}/{KategorijaID}/{Poeni}")]
        public async Task<ActionResult> UpisiOcenu(int KandidatID, int KategorijaID, int Poeni)
        {
            if (Poeni <= 0 || Poeni > 100)
                return BadRequest($"Parametar 'Poeni' : {Poeni} nije validan!");
            try
            {
                var kandidat = await Context.Kandidati.Where(p => p.ID == KandidatID).FirstAsync();
                if (kandidat == null)
                    throw new Exception("Ne postoji kandidat sa tim ID-jem!");

                var kategorija = await Context.Kategorije.Where(p => p.ID == KategorijaID).FirstAsync();
                if (kategorija == null)
                    throw new Exception("Ne postoji kategorija sa tim ID-jem!");
                var p = await Context.PolazeKategoriju.Where(p => p.Kategorija.ID == KategorijaID && p.Kandidat.ID == KandidatID).FirstOrDefaultAsync();
                if (p == null)
                    throw new Exception("Greska, nema takve kategorije ili kandidata!");
                p.Poeni = Poeni;
                Context.Update(p);
                await Context.SaveChangesAsync();
                return Ok("Postavljen broj poena!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("IspisiKandidataSaKategorije/{KandidatID}/{KategorijaID}")]
        [EnableCors("CORS")]
        [HttpDelete]
        public async Task<ActionResult> IspisiKandidataSaKategorije(int KandidatID, int KategorijaID)
        {
            try
            {
                var kandidat = await Context.Kandidati.Where(p => p.ID == KandidatID).FirstAsync();

                if (kandidat == null)
                    throw new Exception("Ne postoji kandidat sa tim ID-jem!");

                var kategorija = await Context.Kategorije.Where(p => p.ID == KategorijaID).FirstAsync();

                if (kategorija == null)
                    throw new Exception("Ne postoji kategorija sa tim ID-jem!");

                var p = await Context.PolazeKategoriju.Where(p => p.Kategorija.ID == KategorijaID && p.Kandidat.ID == KandidatID).FirstOrDefaultAsync();

                if (p== null)
                    throw new Exception("Greska, nema takve kategorije ili kandidata!");
                Context.Remove(p);
                await Context.SaveChangesAsync();
                return Ok("Kandidat je ispisan!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
        [Route("PreuzmiKandidateUpisaneNaKategoriji/{KategorijaID}")]
        [EnableCors("CORS")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiKandidateUpisaneNaKategoriji(int KategorijaID)
        {
            try
            {
                var kategorija = await Context.Kategorije.Where(p => p.ID == KategorijaID).FirstAsync();
                if (kategorija == null)

                    throw new Exception("Ne postoji kategorija sa tim ID-jem!");
                var kandidati = await Context.PolazeKategoriju.Include(p => p.Kategorija).Where(a => a.Kategorija.ID == KategorijaID).Include(p => p.Kandidat).Select(p => new
                {
                    jmbg = p.Kandidat.Jmbg,
                    ime = p.Kandidat.Ime,
                    prezime = p.Kandidat.Prezime,
                    kandidatID = p.Kandidat.ID,
                    poeni = p.Poeni
                    
                }).ToListAsync();

                return Ok(kandidati);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }

        [Route("VratiKandidateKojiNisuUpisani")]
        [EnableCors("CORS")]
        [HttpGet]
        public async Task<ActionResult> VratiKandidateKojiNisuUpisani()
        {
            try
            {
                var kandidati = await Context.Kandidati.Where(p => p.ListaKategorija.Count == 0).ToListAsync();
                return Ok(kandidati);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

