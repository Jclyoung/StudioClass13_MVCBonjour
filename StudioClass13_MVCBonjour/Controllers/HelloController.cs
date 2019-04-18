using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudioClass13_MVCBonjour.Controllers
{
    public class HelloController : Controller
    {
        private string htmlForm = @"
            <form method='post'>
                <input name='userName' />
                <select name='language'>
                    <option>English</option>
                    <option>Russian</option>
                    <option>Spanish</option>
                    <option>French</option>
                </select>
                <button type='submit'>Greet me!</button>
            </form>";


        [HttpGet]
        public IActionResult Index()
        {
            return Content(htmlForm, "text/html");
        }

        [HttpPost]
        public IActionResult Index(string userName, string language)
        {
            return RedirectToAction(actionName: nameof(Greeting), routeValues: new { userName, language });
        }

        public IActionResult Greeting(string userName, string language)
        {
            string greeting = "";
            if (language.ToLower() == "english")
                greeting = "Hello";
            if (language.ToLower() == "russian")
                greeting = "Priviet";
            if (language.ToLower() == "spanish")
                greeting = "Hola";
            if (language.ToLower() == "french")
                greeting = "Bonjour";

            return Content($"{greeting} {userName}!");
        }
    }
}