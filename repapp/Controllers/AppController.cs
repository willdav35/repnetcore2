using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using repapp.Services;
using repapp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using repapp.Data;

namespace repapp.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IProductRepository _repository ;

        public AppController(IMailService mailService, IProductRepository context)
        {
            _mailService = mailService;
            _repository = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        /* this will make it more direct and remove the app/contact link to just contact */
        [HttpGet("contact")]
        public IActionResult Contact()
        
        {
          //  throw new InvalidOperationException("A Bad Thing hapened ");
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the Email
                _mailService.SendMessage("shawn@wildermuth.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent...";
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet("shop")]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
              
           
            return View(results);
        }
    }
}
