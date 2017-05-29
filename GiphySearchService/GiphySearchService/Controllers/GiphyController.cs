using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiphySearchService.Controllers
{
    [Route("[controller]")]
    public class GiphyController : Controller
    {
        [HttpGet("/search")]
        public async Task<IActionResult> Get([FromQuery] string q)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"http://api.giphy.com/v1/gifs/search?q={WebUtility.UrlDecode(q)}&api_key=dc6zaTOxFJmzC");

            JToken result = JObject.Parse(JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result).ToString());

            return Json(result["data"][0]["images"]["original"]);
        }
    }
}
