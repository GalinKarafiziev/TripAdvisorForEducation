using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripAdvisorForEducation.Data.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public CompanyUser User { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(60)]
        public string Website { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
