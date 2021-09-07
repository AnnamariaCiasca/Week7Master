﻿using System;
using Week7Master.Core.BusinessLayer;
using Week7Master.Core.Entities;
using Week7Master.RepositoryMock;

namespace Week7Master
{
    class Program
    {
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new CorsoRepositoryMock(), new DocenteRepositoryMock(), new StudenteRepositoryMock(), new LezioneRepositoryMock());
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto!\n");
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static int SchermoMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n**********************Menu**********************");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFunzionalità CORSI");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Visualizza Corsi");
            Console.WriteLine("2. Inserisci nuovo Corso");
            Console.WriteLine("3. Modifica Corso");
            Console.WriteLine("4. Elimina Corso");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFunzionalità DOCENTI");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("5. Visualizza Docenti");
            Console.WriteLine("6. Inserisci nuovo Docente");
            Console.WriteLine("7. Modifica Docente");
            Console.WriteLine("8. Elimina Docente");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFunzionalità LEZIONI");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("9. Visualizza elenco delle lezioni completo");
            Console.WriteLine("10. Inserimento nuova lezione");
            Console.WriteLine("11. Modifica lezione");//per semplicità solo modifica Aula
            Console.WriteLine("12. Elimina lezione");
            Console.WriteLine("13. Visualizza le Lezioni di un Corso ricercando per Codice del Corso");
            Console.WriteLine("14. Visualizza le Lezioni di un Corso ricercando per Nome del Corso");

            //Funzionalità su Studenti
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFunzionalità STUDENTI");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("15. Visualizza l'elenco completo degli studenti");
            Console.WriteLine("16. Inserimento nuovo Studente");
            Console.WriteLine("17. Modifica Studente");//per semplicità solo email
            Console.WriteLine("18. Elimina Studente");
            Console.WriteLine("19. Visualizza l'elenco degli studenti iscritti ad un corso");

            //Exit
            Console.WriteLine("\n0. Exit");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("********************************************");
            Console.ForegroundColor = ConsoleColor.White;

            int scelta;
            Console.Write("Inserisci scelta:\n");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 19)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;


        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaCorsi();
                    break;
                case 2:
                    InserisciNuovoCorso();
                    break;
                case 3:
                    ModificaCorso();
                    break;
                case 4:
                    EliminaCorso();
                    break;
                case 15:
                    VisualizzaStudenti();
                    break;
                case 16:
                    InserisciNuovoStudente();
                    break;
                case 0:
                    return false;
            }
            return true;
        }

        private static void InserisciNuovoStudente()
        {
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci email");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci dat di nascita (formato gg-mm-aaaa)");
            DateTime dataNascita = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci titolo studio");
            string titoloStudio = Console.ReadLine();
            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice corso a cui è iscritto");
            string codiceCorso = Console.ReadLine();

            //lo creo
            Studente nuovoStudente = new Studente();
            nuovoStudente.Nome = nome;
            nuovoStudente.Cognome = cognome;
            nuovoStudente.DataNascita = dataNascita;
            nuovoStudente.Email = email;
            nuovoStudente.Titolo = titoloStudio;
            nuovoStudente.CodiceCorso = codiceCorso;

            //lo passo al bl
            var esito = bl.InserisciNuovoStudente(nuovoStudente);
            Console.WriteLine(esito);

        }

        private static void VisualizzaStudenti()
        {
            var studenti = bl.GetAllStudenti();
            if (studenti.Count == 0)
            {
                Console.WriteLine("Nessuno Studente presente");
            }
            else
            {
                foreach (var item in studenti)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void EliminaCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi disponibili:");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi eliminare? Inserisci il codice");
            string codice = Console.ReadLine();
            string esito = bl.EliminaCorso(codice);
            Console.WriteLine(esito);
        }

        private static void ModificaCorso()
        {
            Console.WriteLine("Ecco l'elenco de i corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi modificare? Inserisci il codice");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo nome del corso");
            string nuovoNome = Console.ReadLine();
            Console.WriteLine("Inserisci la nua descrizione del corso");
            string nuovaDescrizione = Console.ReadLine();

            var esito = bl.ModificaCorso(codice, nuovoNome, nuovaDescrizione);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoCorso()
        {
            //Chiedo all'utente i dati per creare il nuovo corso
            Console.WriteLine("Inserisci il codice del nuovo corso");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nome del nuovo corso");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci la descrizione del nuovo corso");
            string descrizione = Console.ReadLine();

            //lo creo
            Corso nuovoCorso = new Corso();
            nuovoCorso.Nome = nome;
            nuovoCorso.CodiceCorso = codice;
            nuovoCorso.Descrizione = descrizione;

            //lo passo al business layer per controllare i dati ed aggiungerlo poi nel "DB"
            string esito = bl.InserisciNuovoCorso(nuovoCorso);
            //Stampo il messaggio
            Console.WriteLine(esito);
        }


        private static void VisualizzaCorsi()
        {
            var corsi = bl.GetAllCorsi();
            if (corsi.Count == 0)
            {
                Console.WriteLine("Non ci sono corsi");
            }
            else
            {
                Console.WriteLine("I corsi disponibili sono: ");
                foreach (var item in corsi)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }

}