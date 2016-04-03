using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pfa_mvc5.Models
{
    public class Disponibilité
    {
        

        public int ID { get; set; }
        public DayOfWeek day { get; set; }
        public string nom_prof { get; set; }
        public virtual Professeur professeurs { get; set; } //Une disponibilité concerne un professeur 
        public DateTime start { get; set; }
        public DateTime end { get; set; }

    }
}