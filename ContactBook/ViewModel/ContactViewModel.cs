using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactBook.ViewModel
{
    public class ContactViewModel
    {              
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
    }
}