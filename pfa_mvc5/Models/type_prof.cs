using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pfa_mvc5.Models
{
    public class type_prof
    {
        [Key]
        public int id { get; set; }
        public string type { get; set; }
       
        public virtual Professeur prof { get; set; }
     }
}