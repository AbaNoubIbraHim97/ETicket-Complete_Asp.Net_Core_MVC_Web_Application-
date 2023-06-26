using System.ComponentModel.DataAnnotations;

namespace ETicket.Models
{
    public class Parties
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Parties_Movies> Parties_Movies { get; set; }

    }
}
