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
    public class LezioniController : Controller
    {
        private readonly IBusinessLayer BL;

        public LezioniController(IBusinessLayer bl)
        {
            BL = bl;
        }

   

        [HttpGet]
        public IActionResult Index()
        {
            var lezioni = BL.FetchLezioni();

            List<LezioneViewModel> lezioniiViewModel = new List<LezioneViewModel>();

            foreach (var item in lezioni)
            {
                lezioniiViewModel.Add(item.ToLezioneViewModel());
            }

            return View(lezioniiViewModel);
        }

    }
}
