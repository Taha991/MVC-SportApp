using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportWebApp.Helpers;
using SportWebApp.Interfaces;
using SportWebApp.Models;
using SportWebApp.ViewModels;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace SportWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClubRepository _clubRepository;

        public HomeController(ILogger<HomeController> logger , IClubRepository clubRepository)
        {
            _logger = logger;
            _clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ipInfo = new IpInfo();
            var homeViewModel = new HomeViewModel();
            try
            {
                string url = "ipinfo.io/102.47.33.96?token=ce98eb06e6dc59";
                var info = new WebClient().DownloadString(url);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
                homeViewModel.City = ipInfo.City;
                homeViewModel.State = ipInfo.Region;
                if(homeViewModel.City != null)
                {
                    homeViewModel.Clubs = await _clubRepository.GetClubByCity(homeViewModel.City);
                }
                else
                {
                    homeViewModel.Clubs = null;
                }
                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                homeViewModel.Clubs = null;
            }

            return View(homeViewModel);
          
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
    }
}