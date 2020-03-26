using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripAdvisorForEducation.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(60)]
        public string IsType { get; set; }
    }
}
