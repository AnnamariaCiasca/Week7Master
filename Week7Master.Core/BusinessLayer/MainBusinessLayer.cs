using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {

        //Dichiaro quali sono i repository che ho a disposizione (li dichiaro privati e di sola lettura)
        private readonly ICorsoRepository corsiRep;
        private readonly IDocenteRepository docentiRep;
        private readonly ILezioneRepository lezioniRep;
        private readonly IStudenteRepository studentiRep;

        //Costruttore
        public MainBusinessLayer(ICorsoRepository corsi, IDocenteRepository docenti, IStudenteRepository studenti, ILezioneRepository lezioni)
        {
            corsiRep = corsi;
            docentiRep = docenti;
            lezioniRep = lezioni;
            studentiRep = studenti;

        }


        #region Funzionalità Corsi
        public List<Corso> FetchCorsi()
        {
            return corsiRep.Fetch();
        }

        public string InserisciNuovoCorso(Corso newCorso)
        {
          
            Corso corsoEsistente = corsiRep.GetByCode(newCorso.CodiceCorso);
            if (corsoEsistente != null)
            {
                return "Errore: Codice corso già presente";
            }
            corsiRep.Add(newCorso);
            return "Corso aggiunto correttamente";
        }

        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione)
        {
            
            Corso corsoEsistente = corsiRep.GetByCode(codiceCorsoDaModificare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice errato.";
            }
            corsoEsistente.Nome = nuovoNome;
            corsoEsistente.Descrizione = nuovaDescrizione;
            corsiRep.Update(corsoEsistente);
            return "Il corso è stato modificato con successo";
        }

        public string EliminaCorso(string codiceCorsoDaEliminare)
        {
            Corso corsoEsistente = corsiRep.GetByCode(codiceCorsoDaEliminare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice errato.";
            }

         

            corsiRep.Delete(corsoEsistente);
            return "Corso eliminato correttamente";
        }
        #endregion
     
        
        
        #region funzionalità Studenti
        public List<Studente> FetchStudenti()
        {
            return studentiRep.Fetch();
        }

        public string InserisciNuovoStudente(Studente nuovoStudente)
        {

            Corso corsoEsistente = corsiRep.GetByCode(nuovoStudente.CodiceCorso);
            if (corsoEsistente == null)
            {
                return "Codice errato";
            }
            studentiRep.Add(nuovoStudente);
            return "studente inserito correttamente";
        }

        public string EliminaStudente(int idStudenteDaEliminare)
        {
            Studente studenteEsistente = studentiRep.GetById(idStudenteDaEliminare);
            if (studenteEsistente == null)
            {
                return "Errore: Codice errato.";
            }

            

            studentiRep.Delete(studenteEsistente);
            return "Studente eliminato correttamente";
        }

        public string ModificaStudente(int id, string nuovaEmail)
        {
            
            Studente studenteEsistente = studentiRep.GetById(id);
            if (studenteEsistente == null)
            {
                return "Errore: Codice errato.";
            }
            studenteEsistente.Email = nuovaEmail;
            studentiRep.Update(studenteEsistente);
            return "Lo studente è stato modificato con successo";

        }

        public List<Studente> GetStudentiByCodiceCorso(string codiceCorso)
        {
           
            var corso = corsiRep.GetByCode(codiceCorso);
            if (corso == null)
            {
                return null;
            }
            return studentiRep.Fetch().Where(s => s.CodiceCorso == corso.CodiceCorso).ToList();
        }

        #endregion



        #region funzionalità Docenti
        public List<Docente> FetchDocenti()
        {
            return docentiRep.Fetch();
        }

        public string InserisciNuovoDocente(Docente nuovoDocente)
        {

            Docente docenteEsistente = docentiRep.Fetch().FirstOrDefault(d => d.Nome == nuovoDocente.Nome && d.Cognome == nuovoDocente.Cognome && d.Email == nuovoDocente.Email);
            if (docenteEsistente != null)
            {
                return "Errore";
            }
            docentiRep.Add(nuovoDocente);
            return "Docente inserito correttamente";
        }

        public string EliminaDocente(int idDocenteDaEliminare)
        {
            Docente docenteEsistente = docentiRep.GetById(idDocenteDaEliminare);
            if (docenteEsistente == null)
            {
                return "Errore: Codice errato.";
            }

            docentiRep.Delete(docenteEsistente);
            return "Docente eliminato correttamente";
        }

        public string ModificaDocente(int id, string nuovaEmail, string nuovoTelefono)
        {

            Docente docenteEsistente = docentiRep.GetById(id);
            if (docenteEsistente == null)
            {
                return "Errore: Codice errato.";
            }
            docenteEsistente.Email = nuovaEmail;
            docenteEsistente.Telefono = nuovoTelefono;
            docentiRep.Update(docenteEsistente);
            return "Il docente è stato modificato con successo";

        }



        #endregion




        #region funzionalità Lezioni
        public List<Lezione> FetchLezioni()
        {
            return lezioniRep.Fetch();
        }

        public string InserisciNuovaLezione(Lezione nuovaLezione)
        {

            Corso corsoEsistente = corsiRep.GetByCode(nuovaLezione.CodiceCorso);
            if (corsoEsistente == null)
            {
                return "Codice errato";
            }
            lezioniRep.Add(nuovaLezione);
            return "Lezione inserita correttamente";
        }

        public string EliminaLezione(int idLezioneDaEliminare)
        {
            Lezione lezioneEsistente = lezioniRep.GetById(idLezioneDaEliminare);
            if (lezioneEsistente == null)
            {
                return "Errore: Codice errato.";
            }

            lezioniRep.Delete(lezioneEsistente);
            return "Lezione eliminata correttamente";
        }

        public string ModificaLezione(int id, string nuovaAula)
        {

            Lezione lezioneEsistente = lezioniRep.GetById(id);
            if (lezioneEsistente == null)
            {
                return "Errore: Codice errato.";
            }
            lezioneEsistente.Aula = nuovaAula;

            lezioniRep.Update(lezioneEsistente);
            return "La lezione è stata modificata con successo";

        }

        public Lezione RicercaLezionePerCodiceCorso(string codiceCorso)
        {

            Lezione lezioneEsistente = lezioniRep.Fetch().FirstOrDefault(l => l.CodiceCorso == codiceCorso);
            if (lezioneEsistente == null)
            {
                return null;
            }
         
            return lezioneEsistente;
        }

        public Lezione RicercaLezionePerNomeCorso(string nomeCorso)
        {

            Lezione lezioneEsistente = lezioniRep.Fetch().FirstOrDefault(l => l.Corso.Nome == nomeCorso);
            if (lezioneEsistente == null)
            {
                return null;
            }

            return lezioneEsistente;
        }

        #endregion
    }
}
