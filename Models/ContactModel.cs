using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApplication.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string DoB { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string IDNo { get; set; }
        public bool IsActive { get; set; }
    }
}
