using System.ComponentModel.DataAnnotations;

namespace ETicket.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Logo")]
        public string Logo { get; set; }


        [Display(Name = "Cinema Name")]
        public string Name { get; set; }


        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //Relationships
        public List<Cinemas_Movies> Cinemas_Movies { get; set; }


    }
}
