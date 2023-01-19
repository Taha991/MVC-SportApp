using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportWebApp.Data;
using SportWebApp.Interfaces;
using SportWebApp.Models;

namespace RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
        
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            
            _clubRepository = clubRepository;
        }

      

        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await  _clubRepository.GetAll();
            return View(clubs); 
          
        }

        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }   
    }
}       