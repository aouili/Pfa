using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pfa_mvc5.Models
{
    public class Sceance
    {
        [Key]
        public int id_sceance { get; set; }
        public string titre { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string background_color { get; set; }
        public string border_color { get; set; }
        public string url { get; set; }
        public string nom_prof { get; set; }
        public virtual Professeur professeur { get; set; }
        public int id { get; set; }
        public virtual planning planning { get; set; }
        
       

    }
}