using System.ComponentModel.DataAnnotations;

namespace CEM_TUT.Models
{
    public class Customer
    {
        [Key]
        public int custmerID { get; set; }

        public string Name { get; set; }

        public string cellNumber { get; set; }

        public string email { get; set; }

        public string gender{ get; set; }

        public string age { get; set; }

        public string location { get; set; }
        public string serviceName { get; set; }

    }
}
