using ChickenResturantsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChickenResturantsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Get_CRList()
        {
            var ResultList = new List<Restaurant>();
            
            string url = "https://localhost:7139/api/Restaurants/GetAllRestaurants";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                ResultList = JsonConvert.DeserializeObject<List<Restaurant>>(data);
                return View(ResultList);
                
            }
            else
                return RedirectToAction("Error");
        }

        [HttpGet]
        public IActionResult Add_CRList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add_CRList(Restaurant request)
        {
            string Jdata = JsonConvert.SerializeObject(request);
            StringContent Content = new StringContent(Jdata, Encoding.UTF8,"application/Json");
            string url = "https://localhost:7139/api/Restaurants/AddRestaurant";
            var response = await client.PostAsync(url,Content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Get_CRList");
            }
            else
            return RedirectToAction("Error");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}