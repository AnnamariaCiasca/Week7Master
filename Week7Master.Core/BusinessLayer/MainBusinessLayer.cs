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
        public List<Corso> GetAllCorsi()
        {
            return corsiRep.Fetch();
        }

        public string InserisciNuovoCorso(Corso newCorso)
        {
            //controllo input
            //non deve esistere un altro corso con lo stesso codice
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
            //controllo i dati
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

            //TODO:non deve essere possibile cancellare un corso che ha almeno una lezione associata
            //nè un corso che ha almeno uno studente iscritto.

            corsiRep.Delete(corsoEsistente);
            return "Corso eliminato correttamente";
        }
        #endregion
     
        
        
        #region funzionalità Studenti
        public List<Studente> GetAllStudenti()
        {
            return studentiRep.Fetch();
        }

        public string InserisciNuovoStudente(Studente nuovoStudente)
        {
            //controllo input
            Corso corsoEsistente = corsiRep.GetByCode(nuovoStudente.CodiceCorso);
            if (corsoEsistente == null)
            {
                return "Codice corso errato";
            }
            studentiRep.Add(nuovoStudente);
            return "studente inserito correttamente";
        }
        #endregion
    }
}
