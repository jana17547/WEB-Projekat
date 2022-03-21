using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Models
{
    [Table("Instruktor")]
    public class Instruktor
    {
        [Key]
        [Column("ID")]
        public int ID {get; set;}

        [Required]
        [MaxLength(50)]
        [Column("Ime")]
        public string Ime {get; set;}

        [Required]
        [MaxLength(50)]
        [Column("Prezime")]
        public string Prezime {get; set;}

        public virtual List<Kategorija> Kategorije {get; set;}


    }
}