using Microsoft.AspNetCore.Mvc;
using ToolsOfElesoftV2025.Models;
using ToolsOfElesoftV2025.Models.Ai;
using Newtonsoft.Json.Linq;
using System.Text;


namespace ToolsOfElesoftV2025.Controllers
{
    [LayoutClass]
    public class NewsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult lead_writer()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> lead_writer(string input)
        {
            string Output = await Api.GetFromAiAsync($"'{input}'\n\n Choose a suitable news lead for the above text. Suppose you are a reporter, and you have to choose a lead for a news story on a news agency website. This lead should be between 15 and 30 words long. The news lead may start with the sentence \"A person said:\" (for example:رئیس جمهور ایران گفت: ادامه جمله). Tell me the lead and nothing else. Write this text in Persian.");

            ViewBag.Output = Output;
            ViewBag.Input = input;

            add_work(input, Output, 1);

            return View("result");
        }

        public IActionResult titr_writer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> titr_writer(string input)
        {
            string Titr = await Api.GetFromAiAsync($"'{input}'\n\n Choose three suitable headlines for the text above. Suppose you are a journalist, and you have to choose a headline for a news agency website. Tell me the headlines and separate them with ( - ) and say nothing else. Write this text in Persian.");

            ViewBag.Output = Titr;
            ViewBag.Input = input;

            add_work(input, Titr, 2);

            return View("result");
        }

        public IActionResult words_writer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> words_writer(string input)
        {
            string Titr = await Api.GetFromAiAsync($"{input}\n\n Find three keywords in this text that are the main words of the text. The keyword can be a single word or a combination of 1, 2, or 3 words. After you find the keywords, separate them with a hyphen (-) and send. Don't send anything else. Write this result in Persian.");
            ViewBag.Output = Titr;
            ViewBag.Input = input;

            add_work(input, Titr, 2);

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
