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
    public class CorsiController : Controller
    {
        private readonly IBusinessLayer BL;

        public CorsiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        //CRUD su Corsi

        [HttpGet]
        public IActionResult Index()
        {
            var corsi = BL.FetchCorsi();

            List<CorsoViewModel> corsiViewModel = new List<CorsoViewModel>();

            foreach(var item in corsi)
            {
               corsiViewModel.Add(item.ToCorsoViewModel());
            }

            return View(corsiViewModel);
        }


        [HttpGet ("Corsi/Details/{code}")]
        public IActionResult Details(string code)
        {
            var corso = BL.FetchCorsi().FirstOrDefault(c => c.CodiceCorso == code);

            var corsoViewModel = corso.ToCorsoViewModel();

            return View(corsoViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                BL.InserisciNuovoCorso(corso);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel);
        }


        [HttpGet("Corsi/Update/{code}")]
        public IActionResult Update(string code)
        {
            var corso = BL.FetchCorsi().FirstOrDefault(c => c.CodiceCorso == code);
            var corsoViewModel = corso.ToCorsoViewModel();

            return View(corsoViewModel);
        }


        [HttpPost("Corsi/Update/{code}")]
        public IActionResult Update(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                BL.ModificaCorso(corso.CodiceCorso, corso.Nome, corso.Descrizione);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel);
        }

        [HttpGet("Corsi/Delete/{code}")]
        public IActionResult Delete(string code)
        {
            var corso = BL.FetchCorsi().FirstOrDefault(c => c.CodiceCorso == code);
            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }

        [HttpPost("Corsi/Delete/{code}")]
        public IActionResult Delete(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {

                var corso = corsoViewModel.ToCorso();
                BL.EliminaCorso(corso.CodiceCorso);
                return RedirectToAction(nameof(Index));

            }
            return View(corsoViewModel);
        }
    }
}
