using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pfa_mvc5.Models
{
    public class competence
    {
        [Key]
        public int id { get; set; }
        public string nom_competence { get; set; }
       
        public virtual Professeur prof { get; set;  }
    }
}