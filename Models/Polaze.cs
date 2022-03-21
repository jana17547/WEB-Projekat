using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace Models
{
    [Table("Polaze")]
    public class Polaze
    {
        [Key]
        public int ID {get; set;}

        public virtual Kandidat Kandidat {get; set;}

        public virtual Kategorija Kategorija {get; set;}
        

        [Range (0,100)]
        public int Poeni {get; set;}


    }
}