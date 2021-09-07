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
        public List<Corso> GetAllCorsi();

        public string InserisciNuovoCorso(Corso newCorso);

        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione);
        //Elimina corso
        public string EliminaCorso(string codiceCorsoDaEliminare);



        #endregion


        #region Funzionalità Lezioni


        #endregion


        #region Funzionalità Docenti


        #endregion


        #region Funzionalità Studenti

        public List<Studente> GetAllStudenti();

        public string InserisciNuovoStudente(Studente nuovoStudente);

        #endregion
    }
}
