using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week7Master.MVC.Models
{
    public class CorsoViewModel
    {
        [Required]
        [DisplayName("CodiceCorso")]
        public string CodiceCorso { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        public string Descrizione { get; set; }
    }
}
