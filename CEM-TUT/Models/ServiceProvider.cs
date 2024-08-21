using System.ComponentModel.DataAnnotations;

namespace CEM_TUT.Models
{
    public class ServiceProvider
    {

        public ServiceProvider()
        {
            
        }
        [Key]
        public int providerId { get; set; }

        public string providerName { get; set; }

        public string username  { get; set; }

        public string password { get; set; }



        public ICollection<Service> services { get; set; }
    }
}
