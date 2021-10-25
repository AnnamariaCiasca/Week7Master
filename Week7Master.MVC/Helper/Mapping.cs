using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.MVC.Models;

namespace Week7Master.MVC.Helper
{
    public static class Mapping
    {
        public static CorsoViewModel ToCorsoViewModel(this Corso corso) //Prendo un oggetto di tipo Corso e lo converto in un oggetto di tipo CorsoViewModel
        {
            return new CorsoViewModel
            {
                CodiceCorso = corso.CodiceCorso,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione
            };
        }

        
        public static Corso ToCorso (this CorsoViewModel corsoViewModel) //Contrario di prima
        {
            return new Corso
            {
                CodiceCorso = corsoViewModel.CodiceCorso,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione,
                Studenti = null,
                Lezioni = null
            };
        }


        public static DocenteViewModel ToDocenteViewModel(this Docente docente) 
        {
            return new DocenteViewModel
            {
                Id = docente.Id,
                Nome = docente.Nome,
                Cognome = docente.Cognome,
                Email = docente.Email,
                Telefono = docente.Telefono
            };
        }


        public static Docente ToDocente(this DocenteViewModel docenteViewModel) //Contrario di prima
        {
            return new Docente
            {
                Id = docenteViewModel.Id,
                Nome = docenteViewModel.Nome,
                Cognome = docenteViewModel.Cognome,
                Email = docenteViewModel.Email,
                Telefono = docenteViewModel.Telefono
            };
        }

        public static StudenteViewModel ToStudenteViewModel(this Studente studente)
        {
            return new StudenteViewModel
            {
                Id = studente.Id,
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                Email = studente.Email,
                DataNascita = studente.DataNascita,
                Titolo = studente.Titolo
            };
        }


        public static Studente ToStudente(this StudenteViewModel studenteViewModel) 
        {
            return new Studente
            {
                Id = studenteViewModel.Id,
                Nome = studenteViewModel.Nome,
                Cognome = studenteViewModel.Cognome,
                Email = studenteViewModel.Email,
                DataNascita = studenteViewModel.DataNascita,
                Titolo = studenteViewModel.Titolo
            };
        }



        public static LezioneViewModel ToLezioneViewModel(this Lezione lezione)
        {
            return new LezioneViewModel
            {
                IdLezione = lezione.IdLezione,
                DataOraInizio = lezione.DataOraInizio,
                Durata = lezione.Durata,
                Aula = lezione.Aula
            };
        }


        public static Lezione ToLezione(this LezioneViewModel lezioneViewModel)
        {
            return new Lezione
            {
                IdLezione = lezioneViewModel.IdLezione,
                DataOraInizio = lezioneViewModel.DataOraInizio,
                Durata = lezioneViewModel.Durata,
                Aula = lezioneViewModel.Aula
            };
        }

    }
}
