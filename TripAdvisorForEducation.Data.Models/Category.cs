using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TripAdvisorForEducation.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(60)]
        public string CategoryName { get; set; }

        public ICollection<ProductCategory> Products { get; set; }
    }
}
