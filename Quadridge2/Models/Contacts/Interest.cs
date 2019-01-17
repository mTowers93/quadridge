using Quadridge2.Models.Contacts;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models.Contacts
{
    public class Interest
    {
        public int Id { get; set; }

        [Required]
        public string InterestText { get; set; }

        [Required]
        [Display(Name="Contact")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}