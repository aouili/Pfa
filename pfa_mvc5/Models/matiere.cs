using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace pfa_mvc5.Models
{
    public class matiere
    {
        
        public int chargehoraire { get; set; }
        [Key]
        public string nom { get; set; }

      
        public virtual ICollection<Semestre> Semestres { get; set; }
    }
}