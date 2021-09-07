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
            new Docente{Id=1, Nome="Mario", Cognome="Rossi", Email="mario@mail.it", Telefono="3331234567"},
            new Docente{Id=2, Nome="Giuseppe", Cognome="Bianchi", Email="giuseppe@mail.it", Telefono="3331434567"}
        };
        public Docente Add(Docente item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Docente item)
        {
            throw new NotImplementedException();
        }

        public List<Docente> Fetch()
        {
            throw new NotImplementedException();
        }

        public Docente GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Docente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Docente Update(Docente item)
        {
            throw new NotImplementedException();
        }
    }
}
