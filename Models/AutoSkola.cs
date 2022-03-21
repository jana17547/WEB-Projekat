using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Models
{
     [Table("AutoSkola")]

    public class AutoSkola
    {        
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Ime")]
        public string Ime {get; set;}

        [MaxLength(30)]
        [Column("Tip")]
        public string Tip { get; set; }
        
        public virtual List<Kategorija> Kategorije {get; set;}
    }
}