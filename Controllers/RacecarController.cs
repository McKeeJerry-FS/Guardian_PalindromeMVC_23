using Guardian_PalindromeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Guardian_PalindromeMVC.Controllers
{
    public class RacecarController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            RacecarDataModel model = new RacecarDataModel();
            model.UserInput = string.Empty;

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(RacecarDataModel model)
        {
            if(!string.IsNullOrEmpty(model.UserInput))
            {
                string userInput = model.UserInput;
                string temp = string.Empty;
                for (int i = userInput.Length - 1; i >= 0; i--)
                {
                    temp += userInput[i];
                }

                //Regex rx = new Regex(@"/[^a-zA-Z0-9]\g");

                bool result;
                if (temp.ToLower() != userInput.ToLower())
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
                model.IsPalindrome = result;
                model.ReversedWord = temp;
            }



            return View(model);
        }
    }
}
