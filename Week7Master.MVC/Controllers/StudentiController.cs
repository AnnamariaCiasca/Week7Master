using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7Master.Core.BusinessLayer;
using Week7Master.MVC.Helper;
using Week7Master.MVC.Models;

namespace Week7Master.MVC.Controllers
{
    public class StudentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public StudentiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var studenti = BL.FetchStudenti();

            List<StudenteViewModel> studentiViewModel = new List<StudenteViewModel>();

            foreach (var item in studenti)
            {
                studentiViewModel.Add(item.ToStudenteViewModel());
            }

            return View(studentiViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studenteViewModel.ToStudente();
                BL.InserisciNuovoStudente(studente);
                return RedirectToAction(nameof(Index));
            }
            return View(studenteViewModel);
        }


        [HttpGet("Studenti/Update/{id}")]
        public IActionResult Update(int id)
        {
            var studente = BL.FetchStudenti().FirstOrDefault(s => s.Id == id);
            var studenteViewModel = studente.ToStudenteViewModel();

            return View(studenteViewModel);
        }


        [HttpPost("Studenti/Update/{id}")]
        public IActionResult Update(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studenteViewModel.ToStudente();
                BL.ModificaStudente(studente.Id, studente.Email);
                return RedirectToAction(nameof(Index));
            }
            return View(studenteViewModel);
        }


        [HttpGet("Studenti/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var studente = BL.FetchStudenti().FirstOrDefault(s => s.Id == id);
            var studenteViewModel = studente.ToStudenteViewModel();
            return View(studenteViewModel);
        }

        [HttpPost("Studenti/Delete/{id}")]
        public IActionResult Delete(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {

                var studente = studenteViewModel.ToStudente();
                BL.EliminaStudente(studente.Id);
                return RedirectToAction(nameof(Index));

            }
            return View(studenteViewModel);
        }
    }
}
