using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripAdvisorForEducation.Data.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public int Rating { get; set; }

        [MaxLength(1000)]
        public string Body { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AcademicsUser User { get; set; }

        public string ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
