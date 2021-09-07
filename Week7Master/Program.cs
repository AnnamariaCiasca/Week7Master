using System;
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
            Console.WriteLine("1. Visualizza Corsi");  //ok
            Console.WriteLine("2. Inserisci nuovo Corso");  //ok
            Console.WriteLine("3. Modifica Corso");  //ok
            Console.WriteLine("4. Elimina Corso");  //ok

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFunzionalità DOCENTI");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("5. Visualizza tutti i Docenti");   //ok
            Console.WriteLine("6. Inserisci nuovo Docente");   //ok
            Console.WriteLine("7. Modifica Docente");    //ok
            Console.WriteLine("8. Elimina Docente");    //ok

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFunzionalità LEZIONI");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("9.  Visualizza elenco delle lezioni completo");    //ok
            Console.WriteLine("10. Inserimento nuova lezione");    //ok
            Console.WriteLine("11. Modifica lezione");    //ok
            Console.WriteLine("12. Elimina lezione");    //ok
            Console.WriteLine("13. Visualizza le Lezioni di un Corso ricercando per Codice del Corso");    //ok
            Console.WriteLine("14. Visualizza le Lezioni di un Corso ricercando per Nome del Corso");    //ok

            //Funzionalità su Studenti
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFunzionalità STUDENTI");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("15. Visualizza l'elenco completo degli studenti"); //ok
            Console.WriteLine("16. Inserimento nuovo Studente"); //ok
            Console.WriteLine("17. Modifica Studente");          //ok
            Console.WriteLine("18. Elimina Studente");           //ok
            Console.WriteLine("19. Visualizza l'elenco degli studenti iscritti ad un corso");  //ok

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
                case 5:
                    VisualizzaDocenti();
                    break;
                case 6:
                    InserisciNuovoDocente();
                    break;
                case 7:
                    ModificaDocente();
                    break;
                case 8:
                    EliminaDocente();
                    break;
                case 9:
                    VisualizzaLezioni();
                    break;
                case 10:
                    InserisciNuovaLezione();
                    break;
                case 11:
                    ModificaLezione();
                    break;
                case 12:
                    EliminaLezione();
                    break;
                case 13:
                    RicercaLezionePerCodiceCorso();
                    break;
                case 14:
                    RicercaLezionePerNomeCorso();
                    break;
                case 15:
                    VisualizzaStudenti();
                    break;
                case 16:
                    InserisciNuovoStudente();
                    break;
                case 17:
                    ModificaStudente();
                    break;
                case 18:
                    EliminaStudente();
                    break;
                case 19:
                    VisualizzaStudentiIscrittiCorso();
                    break;
                case 0:
                    return false;
            }
            return true;
        }

        private static void RicercaLezionePerNomeCorso()
        {
            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice del corso di cui vuoi conoscere le lezioni");
            string nomeCorso = Console.ReadLine();

            var esito = bl.RicercaLezionePerNomeCorso(nomeCorso);
            Console.WriteLine(esito);
        }

        private static void RicercaLezionePerCodiceCorso()
        {
            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice del corso di cui vuoi conoscere le lezioni");
            string codiceCorso = Console.ReadLine();

            var esito = bl.RicercaLezionePerCodiceCorso(codiceCorso);
            Console.WriteLine(esito);
        }

        private static void EliminaLezione()
        {
            Console.WriteLine("Ecco l'elenco delle lezioni");
            VisualizzaLezioni();
            Console.WriteLine("Quale lezione vuoi eliminare? Inserisci il codice");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Inserire valore corretto");
            }
            string esito = bl.EliminaLezione(id);
            Console.WriteLine(esito);
        }

        private static void ModificaLezione()
        {
            Console.WriteLine("Ecco l'elenco delle lezioni");
            VisualizzaLezioni();
            Console.WriteLine("Quale lezione vuoi modificare? Inserisci il codice");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Inserire valore corretto");
            }
            Console.WriteLine("Inserisci la nuova aula");
            string nuovaAula = Console.ReadLine();

            var esito = bl.ModificaLezione(id, nuovaAula);
            Console.WriteLine(esito);
        }
            private static void InserisciNuovaLezione()
        {
            Console.WriteLine("Inserisci data di inizio");
            DateTime dataOraInizio = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci durata in giorni");
            int durata = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci l'Aula in cui si svolge la lezione");
            string aula = Console.ReadLine();

            VisualizzaDocenti();
            Console.WriteLine("Inserisci l'id del docente che tiene la lezione");
            int idDocente = int.Parse(Console.ReadLine());

            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice del corso di cui fa parte la lezione");
            string codiceCorso = Console.ReadLine();

            Lezione nuovaLezione = new Lezione();
            nuovaLezione.DataOraInizio = dataOraInizio;
            nuovaLezione.Durata = durata;
            nuovaLezione.Aula = aula;
            nuovaLezione.IdDocente = idDocente;
            nuovaLezione.CodiceCorso = codiceCorso;


            var esito = bl.InserisciNuovaLezione(nuovaLezione);
            Console.WriteLine(esito);
        }

        private static void VisualizzaLezioni()
        {
            var lezioni = bl.FetchLezioni();
            if (lezioni.Count == 0)
            {
                Console.WriteLine("Nessuna Lezione presente");
            }
            else
            {
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void EliminaDocente()
        {
            Console.WriteLine("Ecco l'elenco dei docenti disponibili:");
            VisualizzaDocenti();
            Console.WriteLine("Quale docente vuoi eliminare? Inserisci il codice");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Inserire valore corretto");
            }
            string esito = bl.EliminaDocente(id);
            Console.WriteLine(esito);
        }

        private static void ModificaDocente()
        {
            Console.WriteLine("Ecco l'elenco dei docenti");
            VisualizzaDocenti();
            Console.WriteLine("Quale docente vuoi modificare? Inserisci il codice");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Inserire valore corretto");
            }
            Console.WriteLine("Inserisci la nuova email");
            string nuovaEmail = Console.ReadLine();

            Console.WriteLine("Inserisci il nuovo numero di telefono");
            string nuovoTelefono = Console.ReadLine();


            var esito = bl.ModificaDocente(id, nuovaEmail, nuovoTelefono);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoDocente()
        {
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci email");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di telefono");
            string telefono = Console.ReadLine();
          


            Docente nuovoDocente = new Docente();
            nuovoDocente.Nome = nome;
            nuovoDocente.Cognome = cognome;
            nuovoDocente.Telefono = telefono;
            nuovoDocente.Email = email;
           

            var esito = bl.InserisciNuovoDocente(nuovoDocente);
            Console.WriteLine(esito);
        }

        private static void VisualizzaDocenti()
        {
            var docenti = bl.FetchDocenti();
            if (docenti.Count == 0)
            {
                Console.WriteLine("Nessun Docente presente");
            }
            else
            {
                foreach (var item in docenti)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void VisualizzaStudentiIscrittiCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi:");
            VisualizzaCorsi();
            Console.WriteLine("Inserisci il codice del corso");
            string codiceCorso = Console.ReadLine();

            var listaStudentiCorso = bl.GetStudentiByCodiceCorso(codiceCorso);
            if (listaStudentiCorso == null)
            {
                Console.WriteLine("Codice Corso errato!");
            }
            if (listaStudentiCorso.Count == 0)
            {
                Console.WriteLine("Non ci sono studenti iscritti a questo corso!");
            }
            else
            {
                foreach (var item in listaStudentiCorso)
                {
                    Console.WriteLine(item);
                }
            }

        }

        private static void EliminaStudente()
        {
            Console.WriteLine("Ecco l'elenco degli studenti disponibili:");
            VisualizzaStudenti();
            Console.WriteLine("Quale studente vuoi eliminare? Inserisci il codice");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Inserire valore corretto");
            }
            string esito = bl.EliminaStudente(id);
            Console.WriteLine(esito);
        }

        private static void ModificaStudente()
        {
            Console.WriteLine("Ecco l'elenco degli studenti");
            VisualizzaStudenti();
            Console.WriteLine("Quale studente vuoi modificare? Inserisci il codice");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Inserire valore corretto");
            }
            Console.WriteLine("Inserisci la nuova email");
            string nuovaEmail = Console.ReadLine();
           

            var esito = bl.ModificaStudente(id, nuovaEmail);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoStudente()
        {
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci email");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci data di nascita");
            DateTime dataNascita = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci titolo di studio");
            string titoloStudio = Console.ReadLine();
            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice corso a cui è iscritto");
            string codiceCorso = Console.ReadLine();

           
            Studente nuovoStudente = new Studente();
            nuovoStudente.Nome = nome;
            nuovoStudente.Cognome = cognome;
            nuovoStudente.DataNascita = dataNascita;
            nuovoStudente.Email = email;
            nuovoStudente.Titolo = titoloStudio;
            nuovoStudente.CodiceCorso = codiceCorso;

            
            var esito = bl.InserisciNuovoStudente(nuovoStudente);
            Console.WriteLine(esito);

        }

        private static void VisualizzaStudenti()
        {
            var studenti = bl.FetchStudenti();
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
            var corsi = bl.FetchCorsi();
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