using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Models
{
    public class Kategorija
    {
        [Key]
        [Column("ID")]
        public int ID {get; set;}

        [Required]
        [MaxLength(30)]
        [Column("Naziv")]
        public string Naziv {get; set;}

        [Required]
        [Range(0, 100000)]
        [Column("Cena")]
        public double Cena {get; set;}

        [Required]
        public virtual AutoSkola  AutoSkola {get; set;}
        public virtual Instruktor Instruktor {get; set;}

        public virtual List<Polaze> ListaKandidata {get; set;}
    }
}