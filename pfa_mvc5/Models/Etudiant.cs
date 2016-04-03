using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfa_mvc5.Models
{
    public class Etudiant
    {
        public int id { get; set; }
        public string nom { get; set; }
        public int matricule { get; set; }
        public string pass { get; set; }

    }
}