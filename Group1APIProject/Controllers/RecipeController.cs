using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Group1APIProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Group1APIProject.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ISession _session;
        private readonly IHttpClientFactory _httpClientFactory;

        public RecipeController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult NewRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRecipe(string search)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://www.recipepuppy.com");

            var response = await client.GetAsync($"api/?i={search}");

            var body = await response.Content.ReadAsStringAsync();

            var content = JsonConvert.DeserializeObject<Recipe>(body);

            return View("SearchResult", content);
        }
    }
}