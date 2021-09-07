using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Master.Core.Entities
{
    public class Lezione
    {
        public int IdLezione { get; set; }
        public DateTime DataOraInizio { get; set; }
        public int Durata { get; set; }
        public string Aula { get; set; }
        
        //FK verso docente
        public int IdDocente { get; set; }
        public Docente Docente { get; set; }


        //FK verso Corso
        public string CodiceCorso { get; set; }
        public Corso Corso { get; set; }


        public override string ToString()
        {
            return $"Lezione: {IdLezione}\t{DataOraInizio}\tDurata:{Durata} giorni\tAula: {Aula}\nDocente: {Docente.ToString()}\nCorso: {Corso.ToString()} ";
        }
    }
}
