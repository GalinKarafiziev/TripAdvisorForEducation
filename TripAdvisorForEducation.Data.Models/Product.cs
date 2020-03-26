using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TripAdvisorForEducation.Web.Models;

namespace TripAdvisorForEducation.Data.Models
{
    public class Product
    {
        [Key]
        public int ToolId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(60)]
        public string Website { get; set; }

        public virtual ICollection<ProductCategory> Categories { get; set; }
    }
}
