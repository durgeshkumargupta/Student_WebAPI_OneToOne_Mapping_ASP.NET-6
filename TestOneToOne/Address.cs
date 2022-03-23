using System.ComponentModel.DataAnnotations.Schema;

namespace TestOneToOne
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
    }
}
