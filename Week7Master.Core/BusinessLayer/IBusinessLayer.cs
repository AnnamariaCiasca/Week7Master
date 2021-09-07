using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.Core.BusinessLayer
{
   public interface IBusinessLayer  //serve per comunicare con il livello più alto
    {
        //Aggiungere 

        #region Funzionalità Corsi
       //Visualizza corsi
        public List<Corso> FetchCorsi();

        public string InserisciNuovoCorso(Corso newCorso);

        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione);
        //Elimina corso
        public string EliminaCorso(string codiceCorsoDaEliminare);



        #endregion




        #region Funzionalità Studenti

        public List<Studente> FetchStudenti();

        public string InserisciNuovoStudente(Studente nuovoStudente);
        public string EliminaStudente(int idStudenteDaEliminare);
        public string ModificaStudente(int id, string nuovaEmail);

        public List<Studente> GetStudentiByCodiceCorso(string codiceCorso);


        #endregion



        #region Funzionalità Docenti

        public List<Docente> FetchDocenti();

        public string InserisciNuovoDocente(Docente nuovoDocente);
        public string EliminaDocente(int idDocenteDaEliminare);
        public string ModificaDocente(int id, string nuovaEmail, string nuovoTelefono);



        #endregion


        #region Funzionalità Lezioni

        public List<Lezione> FetchLezioni();

        public string InserisciNuovaLezione(Lezione nuovaLezionw);
        public string EliminaLezione(int idLezioneDaEliminare);
        public string ModificaLezione(int id, string nuovaAula);
        public Lezione RicercaLezionePerCodiceCorso(string codiceCorso);
        public Lezione RicercaLezionePerNomeCorso(string nomeCorso);



        #endregion
    }
}
