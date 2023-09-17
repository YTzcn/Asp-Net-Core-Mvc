using System.ComponentModel;

namespace WebApplication1.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string Name { get; set; }
        public string SurName { get; set; }
        public int CityId{ get; set; }
    }
}
