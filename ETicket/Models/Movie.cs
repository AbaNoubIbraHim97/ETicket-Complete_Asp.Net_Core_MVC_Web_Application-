using ETicket.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicket.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory moviecategory { get; set; }


        //Relationships
        public List<Actor_Movie> Actor_Movies { get; set; }
        public List<Cinemas_Movies> Cinemas_Movies { get; set; }
        public List<Parties_Movies> Parties_Movies { get; set; }

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }





    }
}
