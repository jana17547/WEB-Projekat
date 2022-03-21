using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Models
{
    [Table("Kandidat")]

    public class Kandidat
    {        
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [MaxLength(13)]
        [Column("JMBG")]
        public string Jmbg { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Ime")]
        public string Ime {get; set;}


        [Required]
        [MaxLength(50)]
        [Column("Prezime")]
        public string Prezime {get; set;}

        public virtual List<Polaze> ListaKategorija { get; set; }


    }
}