using ClienteQrCodeConverter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClienteQrCodeConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Create(string parametro)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:60265/api/QrCode");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var conteudo = new QrCodeParametros();

            var dict = new Dictionary<string, string> {
                { "Parametro", parametro }
            };

            var bodyJson = JsonSerializer.Serialize(dict);
            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            //var stringContent = new StringContent(JsonConvert.SerializeObject(bodyJson, Formatting.Indented, Encoding.UTF8, "application/json");

            HttpResponseMessage retorno = client.PostAsync("", stringContent).Result;

            if (retorno.IsSuccessStatusCode)
            {
                var resultado = retorno.Content.ReadAsStringAsync().Result;
                conteudo = JsonSerializer.Deserialize<QrCodeParametros>(resultado);

                Bitmap bmp;
                using (var ms = new MemoryStream(conteudo.bytesConverted))
                {
                    bmp = new Bitmap(ms);
                }

                TempData["imagemQrCodeBase64"] = "data:image/bmp;base64," + conteudo.textConverted;
                TempData["imagemQrCodeBitmap"] = "data:image/image/bmp," + bmp;
                TempData["imagemQrCodeBytes"] = "data:image/bmp;base64," + Convert.ToBase64String(conteudo.bytesConverted);
            }

            return View("Index");
        }
    }
}
