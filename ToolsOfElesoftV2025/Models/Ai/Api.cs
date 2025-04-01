using Newtonsoft.Json.Linq;
using System.Text;

namespace ToolsOfElesoftV2025.Models.Ai
{
    public static class Api
    {
        public static async Task<string> GetFromAiAsync(string Text)
        {
            DateTime LastUseTime = Convert.ToDateTime(System.IO.File.ReadAllText("wwwroot/News/last-use.txt"));
            TimeSpan timeDifference = DateTime.Now.Subtract(LastUseTime);

            int Seconds = Convert.ToInt32(timeDifference.TotalSeconds);

            if (Seconds < 10)
            {
                Thread.Sleep((10 - Seconds) * 1000);
            }

            var apiKey = "[your api key]";
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";

            var jsonContent = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new { text = Text }
                    }
                }
            }
            };

            using (var client = new HttpClient())
            {
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                System.IO.File.WriteAllText("wwwroot/News/last-use.txt", DateTime.Now.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(responseString);

                    // استخراج مقدار text
                    string text = jsonObject["candidates"][0]["content"]["parts"][0]["text"].ToString();

                    return text;
                }
                else
                {
                    return response.StatusCode.ToString();
                }
            }
        }
    }
}
