using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfa_mvc5.Models
{
    public class Recrutement
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string cv_path { get; set; }
        public string etat { get; set; }
    }
}