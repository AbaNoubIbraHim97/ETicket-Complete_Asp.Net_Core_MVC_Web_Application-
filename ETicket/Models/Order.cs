using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicket.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }

        [Display (Name ="Phone Number")]
        public string PhoneNumber { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
