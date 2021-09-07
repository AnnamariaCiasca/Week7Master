using System;
using System.Collections.Generic;
using System.Linq;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.RepositoryMock
{
    public class CorsoRepositoryMock : ICorsoRepository
    {

        public static List<Corso> Corsi = new List<Corso>()
        {
            new Corso{CodiceCorso="C-01", Nome = "Pre-Academy I", Descrizione="Corso Base C# Livello1"},
            new Corso{CodiceCorso="C-02", Nome = "Academy I", Descrizione="Corso Base C# Livello2"},

        };

        public Corso Add(Corso item)
        {
            Corsi.Add(item);
            return item;
        }

        public bool Delete(Corso item)
        {
            Corsi.Remove(item);
            return true;
        }

        public List<Corso> Fetch()
        {
            return Corsi;
        }

        public Corso GetByCode(string codice)
        {
            return Corsi.Find(c => c.CodiceCorso == codice);
            // in alternativa si può fare anche return Corsi.FirstOrDefault(c=> c.CodiceCorso == codice); sono uguali
        }

        public Corso Update(Corso item)
        {
            var old = Corsi.FirstOrDefault(c => c.CodiceCorso == item.CodiceCorso);
            old.Nome = item.Nome;
            old.Descrizione = item.Descrizione;
            return item;
        }
    }
}
