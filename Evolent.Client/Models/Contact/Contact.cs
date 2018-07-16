using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evolent.Client.Models.Contact
{
    public class Contact
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [StringLength(20), Required]
        [RegularExpression("^[a-zA-Z]{1,20}$")]
        public string FirstName { get; set; }

        [StringLength(20), Required]
        [RegularExpression("^[a-zA-Z]{1,20}$")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-mail address is not valid")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone Number is not valid")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Status")]
        public ContactStatus Status { get; set; }
    }
    public enum ContactStatus
    {
        Active,
        Inactive
    }
}