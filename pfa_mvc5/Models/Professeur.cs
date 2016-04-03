using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pfa_mvc5.Models
{
    public class Professeur
    {



        [Key]
        public string nom_prof { get; set; }
        public string prenom { get; set; }
        public int numTel { get; set; }
        public string grade { get; set; }
        public string login { get; set; }
        public string password { get; set; }
   
        public string mail { get; set; }
        public virtual ICollection<Disponibilité> Disponibilités { get; set; } // Un professeur a plusieurs disponibilités 
        public virtual ICollection<type_prof> type_prof { get; set; } // type de prof
        public virtual ICollection<competence> competence { get; set; }
        public virtual ICollection<Sceance> sceance { get; set; }
    }
}