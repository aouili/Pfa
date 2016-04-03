using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pfa_mvc5.Models
{
    public class classes
    {
        [Key]
        public string nom_classe { get; set; }
        
        public String groupe { get; set; }
       
        public virtual ICollection<planning> planning { get; set; }
    }
}