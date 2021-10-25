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
    }

}