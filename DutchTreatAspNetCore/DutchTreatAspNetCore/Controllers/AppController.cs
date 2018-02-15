using DutchTreatAspNetCore.Services;
using DutchTreatAspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreatAspNetCore.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contacts")]
        public IActionResult Contacts()
        {
            return View();
        }
        
        [HttpPost("contacts")]
        public IActionResult Contacts(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                _mailService.SendMessage("ppokrovskiy@croc.ru", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ModelState.Clear();
            }

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        
    }
}
