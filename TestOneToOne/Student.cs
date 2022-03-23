using System.ComponentModel.DataAnnotations.Schema;

namespace TestOneToOne
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

    //    public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}
