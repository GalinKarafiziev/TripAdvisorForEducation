using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TripAdvisorForEducation.Web.Models;

namespace TripAdvisorForEducation.Data.Models
{
    public class CompanyUser : ApplicationUser
    {
        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(60)]
        public string Website { get; set; }
    }
}
