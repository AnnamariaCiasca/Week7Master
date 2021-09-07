using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Master.Core.Entities
{
   public class Studente : Persona
    {
        public DateTime DataNascita { get; set; }
        public string Titolo { get; set; }
       
        //FK
        public string CodiceCorso { get; set; }
        public Corso Corso { get; set; }


        public override string ToString()
        {
            return $"Studente: {Id}\t{Nome}\t{Cognome}\tnato il: {DataNascita.ToShortDateString()}\tEmail: {Email}\tTitolo: {Titolo} ";
        }
    }
}
