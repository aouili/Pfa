using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pfa_mvc5.Models
{
    public class Semestre
    {
        [Key]
        public string nomSemestre { get; set; }
        
        public string matiere_nom { get; set; }
        public virtual matiere matiere { get; set; }
     
        
        public virtual ICollection<Sceance> sceance { get; set; }
        
    }
}