using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.RepositoryEF.RepositoriesEF
{
   public class StudenteRepositoryEF : IStudenteRepository
    {
        public Studente Add(Studente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Studente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Studente> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Studenti.Include(x => x.Corso).ToList();
            }
        }

        public Studente GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Studenti.Include(x => x.Corso).FirstOrDefault(s => s.Id == id);
            }
        }

        public Studente Update(Studente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
