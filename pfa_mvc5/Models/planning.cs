using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pfa_mvc5.Models
{
    public class planning
    {
        [Key]
        public int id { get; set; }
        public string nom_planning { get; set; }
        public string nom_classe { get; set; }
        public string nomSemestre { get; set; }
        public virtual classes classe { get; set; }
        public virtual Semestre semestre { get; set; }
        public virtual ICollection<Sceance> sceance { get; set; }
        public string etat { get; set; }
    }
}