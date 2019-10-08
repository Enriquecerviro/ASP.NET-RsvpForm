using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Enter name: alphanumeric, one word, one letter and 6-15 lenght")]
        [RegularExpression("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,15})$",
            ErrorMessage = "Valid username: C2dfeed")
            ]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter your email address:")]
        [RegularExpression("^(\\D)+(\\w)*((\\.(\\w)+)?)+@(\\D)+(\\w)*((\\.(\\D)+(\\w)*)+)?(\\.)[a-z]{2,}$",
            ErrorMessage ="A valid, email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "US Phone: 123 123 1234,1-800-ALPHNUM")]
        [RegularExpression("^([0-9]( |-)?)?(\\(?[0-9]{3}\\)?|[0-9]{3})( |-)?([0-9]{3}( |-)?[0-9]{4}|[a-zA-Z0-9]{7})$",
            ErrorMessage ="US Phone number, area code required")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Please specify whether you´ll attend")]
        public bool? WillAttend { get; set; }
    }
}
