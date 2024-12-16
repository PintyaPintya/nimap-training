using System.ComponentModel.DataAnnotations;

namespace WebApiPractice.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
    }
}