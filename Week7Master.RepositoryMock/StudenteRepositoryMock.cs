using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.RepositoryMock
{
    public class StudenteRepositoryMock : IStudenteRepository
    {
        public static List<Studente> Studenti = new List<Studente>();
        public Studente Add(Studente item)
        {
            if (Studenti.Count == 0)
            {
                item.Id = 1;
            }
            else
            {
                item.Id = Studenti.Max(s => s.Id) + 1;
            }

            var corso = CorsoRepositoryMock.Corsi.FirstOrDefault(c => c.CodiceCorso == item.CodiceCorso);
            item.Corso = corso;
            corso.Studenti.Add(item);

            Studenti.Add(item);
            return item;
        }

        public bool Delete(Studente item)
        {
            throw new NotImplementedException();
        }

        public List<Studente> Fetch()
        {
            return Studenti;
        }

        public Studente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Studente Update(Studente item)
        {
            throw new NotImplementedException();
        }
    }
}
