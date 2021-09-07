using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Master.Core.Entities
{
   public class Docente : Persona
    {
        public string Telefono { get; set; }

        //FK
        public List<Lezione> Lezioni { get; set; } = new List<Lezione>();

        public override string ToString()
        {
            return $"Id: {Id}\t{Nome}\t{Cognome}\tTelefono: {Telefono}\tEmail: {Email} ";
        }
    }
}
