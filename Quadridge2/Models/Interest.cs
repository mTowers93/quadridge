using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class Interest
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Contact")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}