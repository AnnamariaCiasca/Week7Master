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
    public class DocentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public DocentiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var docenti = BL.FetchDocenti();

            List<DocenteViewModel> docentiViewModel = new List<DocenteViewModel>();

            foreach (var item in docenti)
            {
                docentiViewModel.Add(item.ToDocenteViewModel());
            }

            return View(docentiViewModel);
        }

        [HttpGet("Docenti/Recapiti/{id}")]
        public IActionResult Recapiti(int id)
        {
            var docente = BL.FetchDocenti().FirstOrDefault(d => d.Id == id);

            var docenteViewModel = docente.ToDocenteViewModel();

            return View(docenteViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.ToDocente();
                BL.InserisciNuovoDocente(docente);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel);
        }


        [HttpGet("Docenti/Update/{id}")]
        public IActionResult Update(int id)
        {
            var docente = BL.FetchDocenti().FirstOrDefault(d => d.Id == id);
            var docenteViewModel = docente.ToDocenteViewModel();

            return View(docenteViewModel);
        }


        [HttpPost("Docenti/Update/{id}")]
        public IActionResult Update(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.ToDocente();
                BL.ModificaDocente(docente.Id, docente.Email, docente.Telefono);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel);
        }


        [HttpGet("Docenti/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var docente = BL.FetchDocenti().FirstOrDefault(d => d.Id == id);
            var docenteViewModel = docente.ToDocenteViewModel();
            return View(docenteViewModel);
        }

        [HttpPost("Docenti/Delete/{id}")]
        public IActionResult Delete(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {

                var docente = docenteViewModel.ToDocente();
                BL.EliminaDocente(docente.Id);
                return RedirectToAction(nameof(Index));

            }
            return View(docenteViewModel);
        }
    }

}