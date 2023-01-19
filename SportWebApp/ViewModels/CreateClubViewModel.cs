
using SportWebApp.Data.Enum;
using SportWebApp.Models;

namespace SportWebApp.ViewModels
{
    public class CreateClubViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public ClubCategory CLubCategory { get; set; }

    }
}
