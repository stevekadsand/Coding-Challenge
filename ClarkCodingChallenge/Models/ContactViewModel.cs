using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ClarkCodingChallenge.Models
{
    public class ContactViewModel
    {
        [BindProperty]
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [RegularExpression(@"/^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/")]
        public string Email { get; set; }
    }
}