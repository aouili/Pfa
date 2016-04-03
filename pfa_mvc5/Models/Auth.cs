using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace pfa_mvc5.Models
{

    public class Auth
    {
       [Key]
        public string login { get; set; }
        public string pass { get; set; }
        public string type { get; set; }
        public bool rememberme { get; set; }
    }
}