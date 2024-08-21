using System.ComponentModel.DataAnnotations;

namespace CEM_TUT.Models
{
    public class Feedback
    {
        [Key]
        public int feedbackId { get; set; }

        public string serviceName{ get; set; }

        public string customerName { get; set;}

        public int rating { get; set; }

        
    }
}
