namespace ETicket.Models
{
    public class Parties_Movies
    {
        public int PartyId { get; set; }
        public Parties Parties { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
