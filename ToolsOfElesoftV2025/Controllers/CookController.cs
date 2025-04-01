using Microsoft.AspNetCore.Mvc;
using ToolsOfElesoftV2025.Models;
using ToolsOfElesoftV2025.Models.Ai;
using Newtonsoft.Json.Linq;
using System.Text;


namespace ToolsOfElesoftV2025.Controllers
{
    [LayoutClass]
    public class CookController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult tell_me_what()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> tell_me_what(string input, string input_also)
        {
            string Output = await Api.GetFromAiAsync($"I have the following ingredients at home {{${input}}}. Suggest me an Iranian dish with a recipe so I can make it. Remember to be authentic, and use only these ingredients, Skip the obvious foods that are always at home, such as onions, spices, water, bread, and rice. also ${input_also}. write <br/> whenever you need to go to the next line. Write this text in Persian.");

            ViewBag.Output = Output;
            ViewBag.Input = input;

            add_work(input, Output, 5);

            return View("result");
        }

        public IActionResult tell_me_how()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> tell_me_how(string input, string input_also)
        {
            string Output = await Api.GetFromAiAsync($"I want to cook a dish called {{${input}}}. Suppose my information is not very good, so explain to me and provide a recipe so that I can do this.\r\n also ${input_also}. write <br/> whenever you need to go to the next line. Write this text in Persian.");

            ViewBag.Output = Output;
            ViewBag.Input = input;

            add_work(input, Output, 5);

            return View("result");
        }

        public static void add_work(string Input, string Output, int TypeCode)
        {
            ElesoftiToolsContext db = new ElesoftiToolsContext();

            Twork twork = new Twork()
            {
                InputText = Input,
                OutputText = Output,
                Date = DateTime.Now,
                WorkType = TypeCode
            };

            db.Tworks.Add(twork);
            db.SaveChanges();
        }
    }
}
