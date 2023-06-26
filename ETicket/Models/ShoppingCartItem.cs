using System.ComponentModel.DataAnnotations;

namespace ETicket.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public Movie Movie { get; set; }

        //public List<Parties_Movies> Parties_Movies { get; set; }
        //public List<Cinemas_Movies> Cinemas_Movies { get; set; }
        //public DateTime Date { get; set; }

        public string ShoppingCartId { get; set; }

        
    }
}
