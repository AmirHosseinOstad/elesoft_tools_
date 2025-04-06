using Microsoft.AspNetCore.Mvc;
using ToolsOfElesoftV2025.Models;
using ToolsOfElesoftV2025.Models.Ai;
using Newtonsoft.Json.Linq;
using System.Text;


namespace ToolsOfElesoftV2025.Controllers
{
    [LayoutClass]
    public class TeachController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult quiz()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> quiz(string input, string input_also)
        {
            string Output = await Api.GetFromAiAsync($"I'm asking you a question, and that question is: {{${input}}}. Please tell me the answer and do the calculations if necessary. also {input_also}. write <br/> whenever you need to go to the next line. Write this text in Persian.");

            ViewBag.Output = Output;
            ViewBag.Input = input;

            add_work(input, Output, 10);

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
