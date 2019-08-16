using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Group1APIProject.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Newtonsoft.Json;


namespace Group1APIProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly ISession _session;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, DataContext context)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;
            _httpClientFactory = httpClientFactory;
        }
        
        public IActionResult Index()
        {
            ViewBag.LoggedIn = User.Identity.IsAuthenticated;
            ViewBag.UID = User.Identity.Name;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
