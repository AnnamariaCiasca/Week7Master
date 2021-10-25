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
    }
}
