using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TripAdvisorForEducation.Data.Models
{
    public class CompanyUser : IdentityUser
    {
        public CompanyUser()
        {
            Products = new List<Product>();
        }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(60)]
        public string Website { get; set; }


        [MaxLength(60)]
        public string Industry { get; set; }

        [MaxLength(60)]
        public string AnnualRevenue { get; set; }

        [MaxLength(60)]
        public string CompanySize { get; set; }

        [MaxLength(60)]
        public string YearFound { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
