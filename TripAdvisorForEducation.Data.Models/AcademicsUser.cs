using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TripAdvisorForEducation.Data.Models
{
    public class AcademicsUser : IdentityUser
    {
        public AcademicsUser()
        {
            Reviews = new List<Review>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
