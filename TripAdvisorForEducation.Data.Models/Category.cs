using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripAdvisorForEducation.Data.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<ProductCategory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CategoryId { get; set; }

        [Required]
        [MaxLength(60)]
        public string CategoryName { get; set; }

        public ICollection<ProductCategory> Products { get; set; }

        public Category()
        {
            this.Products = new List<ProductCategory>();
        }
    }
}
