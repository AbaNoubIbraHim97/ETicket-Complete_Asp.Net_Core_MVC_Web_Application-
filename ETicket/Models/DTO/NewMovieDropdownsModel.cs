namespace ETicket.Models.DTO
{
    public class NewMovieDropdownsModel
    {
        public NewMovieDropdownsModel()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
            Parties = new List<Parties>();
        }

        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Parties> Parties { get; set; }
    }
}
