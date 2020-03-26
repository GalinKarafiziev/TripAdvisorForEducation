using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TripAdvisorForEducation.Web.Models;

namespace TripAdvisorForEducation.Data.Models
{
    public class AcademicsUser : ApplicationUser
    {
        [MaxLength(60)]
        public string FirstName { get; set; }

        [MaxLength(60)]
        public string LastName { get; set; }

        [MaxLength(60)]
        public string Role { get; set; }
    }
}
