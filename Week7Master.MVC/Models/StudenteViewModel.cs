using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week7Master.MVC.Models
{
    public class StudenteViewModel : PersonaViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascita { get; set; }
        public string Titolo { get; set; }

        public string CodiceCorso { get; set; }
        public CorsoViewModel Corso { get; set; }
    }
}
