using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            //'Greeting no existe hasta que le asigno valor(ternario en este caso)'
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        
        //METODO GET
        [HttpGet]
        public ViewResult RsvpForm()
        /**
            AQUI EL ACTION METHOD LLAMA A `View` SIN ARGUMENTOS,
            LO QUE MEANS QUE RENDERIZARA LAS VISTA ASOCIADA AL ACTION METHOD
            QUE ES LA MISMA QUE EL PROPIO METODO
        */
        {
            return View();
        }
        //METODO POST
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if(ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
            
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
