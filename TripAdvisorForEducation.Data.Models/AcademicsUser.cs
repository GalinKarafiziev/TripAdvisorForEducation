using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TripAdvisorForEducation.Data.Models
{
    public class AcademicsUser : IdentityUser
    {
        [MaxLength(60)]
        public string FirstName { get; set; }

        [MaxLength(60)]
        public string LastName { get; set; }

        [MaxLength(60)]
        public string Role { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public AcademicsUser()
        {
            Reviews = new List<Review>();
        }
    }
}
