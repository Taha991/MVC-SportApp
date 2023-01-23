namespace SportWebApp.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        // pace = how fast is take to run  , how much u run in week
        public  int?  Pace { get; set; }
        public int? Mileage { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
