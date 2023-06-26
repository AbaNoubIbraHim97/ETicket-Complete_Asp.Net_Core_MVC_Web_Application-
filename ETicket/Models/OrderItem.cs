using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicket.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        
        public double Price { get; set; }

        //public int CinemaId { get; set; }
        //[ForeignKey("CinemaId")]
        //public Cinema Cinema { get; set; }

        //public int PartyId { get; set; }
        //[ForeignKey("PartyId")]
        //public Parties Parties { get; set; }

        //public DateTime Date { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }


        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
