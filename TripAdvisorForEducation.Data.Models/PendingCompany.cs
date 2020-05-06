using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripAdvisorForEducation.Data.Models
{
    public class PendingCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PendingCompanyId { get; set; }

        [MaxLength(60)]
        public string CompanyName { get; set; }

        [MaxLength(60)]
        public string Website { get; set; }

        [MaxLength(60)]
        public string Email { get; set; }

        [MaxLength(60)]
        public string FirstName { get; set; }

        [MaxLength(60)]
        public string LastName { get; set; }

        [MaxLength(60)]
        public string PhoneNumber { get; set; }

        [MaxLength(60)]
        public string Country { get; set; }

        public string Token { get; set; }

        public bool IsTokenActive { get; set; }
    }
}
