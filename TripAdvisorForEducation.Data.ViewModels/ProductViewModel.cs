using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TripAdvisorForEducation.Data.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            CategoryIds = new List<string>();
        }

        public string Description { get; set; }

        public string Website { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public IReadOnlyCollection<string> CategoryIds { get; }
    }
}
