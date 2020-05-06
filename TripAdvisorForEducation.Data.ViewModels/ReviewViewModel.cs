using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TripAdvisorForEducation.Data.ViewModels
{
    public class ReviewViewModel
    {
        public int Rating { get; set; }
        
        public string Body { get; set; }
        
        public string UserId { get; set; }
        
        public string ProductId { get; set; }
    }
}
