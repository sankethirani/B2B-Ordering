using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVCManukauTech.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MVCManukauTechUser class
    public class MVCManukauTechUser : IdentityUser
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        //public DateTime ExpiryDate { get; set; }
        public string MembershipType { get; set; }
    }
}
