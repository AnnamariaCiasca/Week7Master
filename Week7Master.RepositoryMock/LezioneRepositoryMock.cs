using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.RepositoryMock
{
    public class LezioneRepositoryMock : ILezioneRepository
    {
        public static List<Lezione> Lezioni = new List<Lezione>()
        {
            new Lezione{IdLezione=1, Aula = "A1", DataOraInizio = new DateTime(2021,09,20,09,30,00), Durata = 50, Docente = new Docente(), IdDocente = 1, Corso = new Corso( ), CodiceCorso = "C-01" },


        };
        public Lezione Add(Lezione item)
        {
            if (Lezioni.Count == 0)
            {
                item.IdLezione = 1;
            }
            else
            {
                item.IdLezione = Lezioni.Max(l => l.IdLezione) + 1;
            }

            var corso = CorsoRepositoryMock.Corsi.FirstOrDefault(c => c.CodiceCorso == item.CodiceCorso);
            item.Corso = corso;
            corso.Lezioni.Add(item);

            var docente = DocenteRepositoryMock.Docenti.FirstOrDefault(d => d.Id == item.IdDocente);
            item.Docente = docente;
            docente.Lezioni.Add(item);

            Lezioni.Add(item);
            return item;
        }

        public bool Delete(Lezione item)
        {
            Lezioni.Remove(item);
            return true;
        }

        public List<Lezione> Fetch()
        {
            return Lezioni;
        }

        public Lezione GetById(int id)
        {
            return Lezioni.Find(l => l.IdLezione == id);
        }

        public Lezione Update(Lezione item)
        {
            var old = Lezioni.FirstOrDefault(l => l.IdLezione == item.IdLezione);
            old.Aula = item.Aula;
           

            return item;
        }
    }
}
