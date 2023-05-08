using CDFApps.TZ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using CDFApps.Domain.ViewModels;
using Newtonsoft.Json;
using CDFApps.Domain.dbModels;
using System.Text.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using CDFApps.Domain.Dto;

namespace CDFApps.TZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ScannedItemsAsync()
        {
            var apiClient = _httpClientFactory.CreateClient();
            string url = "https://localhost:7267/api/Boxes";
            var response = await apiClient.GetAsync(url);
            string boxes = await response.Content.ReadAsStringAsync();

            //create view model
            
             List<Boxes> boxesList = JsonConvert.DeserializeObject<List<Boxes>>(boxes);
            return View(boxesList);
        }
        [HttpPost]
        public async Task<IActionResult> ScannedItemsAsync(string box)
        {
            var apiClient = _httpClientFactory.CreateClient();
            string url = "https://localhost:7267/api/Boxes/";

            var todoItemJson = new StringContent(
                JsonConvert.SerializeObject(box)
                ,Encoding.UTF8,
                Application.Json);

            var response = await apiClient.PutAsync(url, todoItemJson);
            string boxes = await response.Content.ReadAsStringAsync();

            //create view model

            List<Boxes> boxesList = JsonConvert.DeserializeObject<List<Boxes>>(boxes);
            return View(boxesList);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> EditBoxAsync(Guid Id)
        {
            var apiClient = _httpClientFactory.CreateClient();
            string url = "https://localhost:7267/api/Boxes/"+Id;
            var response = await apiClient.GetAsync(url);
            string boxString = await response.Content.ReadAsStringAsync();

            Boxes? box = JsonConvert.DeserializeObject<Boxes>(boxString);
            return View(box);
        }
        [HttpPost]
        public async Task<IActionResult> EditBoxAsync(UpdateBox update)
        {
            var apiClient = _httpClientFactory.CreateClient();
            string url = "https://localhost:7267/api/Boxes/"+update.Id;

            var todoItemJson = new StringContent(
                JsonConvert.SerializeObject(update)
                , Encoding.UTF8,
                Application.Json);

            var response = await apiClient.PutAsync(url, todoItemJson);
            string content = await response.Content.ReadAsStringAsync();

            return RedirectToAction("ScannedItems");
        }
    }
}