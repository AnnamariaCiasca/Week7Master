using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.RepositoryMock
{
    public class DocenteRepositoryMock : IDocenteRepository
    {
        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente{Id=1, Nome="Michele", Cognome="Neri", Email="michele.neri@hotmail.it", Telefono="3456178231"},
            new Docente{Id=2, Nome="Laura", Cognome="Verdi", Email="lauraverdi@virgilio.it", Telefono="3286543987"}
        };
        public Docente Add(Docente item)
        {
            if (Docenti.Count == 0)
            {
                item.Id = 1;
            }
            else
            {
                item.Id = Docenti.Max(d => d.Id) + 1;
            }
            Docenti.Add(item);
            return item;
        }

        public bool Delete(Docente item)
        {
            Docenti.Remove(item);
            return true;
        }

        public List<Docente> Fetch()
        {
            return Docenti;
        }

        public Docente GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Docente GetById(int id)
        {
            return Docenti.Find(d => d.Id == id);
        }

        

        public Docente Update(Docente item)
        {
            var old = Docenti.FirstOrDefault(d => d.Id == item.Id);
            old.Email = item.Email;
            old.Telefono = item.Telefono;

            return item;
        }
    }
}
