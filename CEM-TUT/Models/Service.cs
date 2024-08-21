using System.ComponentModel.DataAnnotations;

namespace CEM_TUT.Models
{
    public class Service
    {

        [Key]
        public int serviceId { get; set; }

       public string serviceName { get; set; }

        public string serviceDescription { get; set; }

        public int providerId { get; set; }
    }
}
