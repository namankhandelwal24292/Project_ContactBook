using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        
        [Required(ErrorMessage = "Please provide First Name", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide Last Name", AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide a phone number")]        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Please provide Email Id", AllowEmptyStrings = false)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Not a valid Email")]
        public string EmailID { get; set; }

        public bool IsActive { get; set; }
    }
}