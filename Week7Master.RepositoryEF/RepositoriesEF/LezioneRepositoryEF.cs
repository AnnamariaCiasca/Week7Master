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
    public class LezioneRepositoryEF : ILezioneRepository
    {
        public Lezione Add(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Lezione> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(x => x.Corso).Include(x => x.Docente).ToList();
            }
        }

        public Lezione GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(x => x.Corso).Include(x => x.Docente).FirstOrDefault(l => l.IdLezione == id);
            }
        }

        public Lezione Update(Lezione item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}