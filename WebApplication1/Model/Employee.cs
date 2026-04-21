using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Employee
    {
        [Required]
        [Range(1,1000)]
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Department { get; set; }

        public Employee(int? id,string? name,string? department)
        {
            this.Id = id;
            this.Name = name;
            this.Department = department;
        }
    }
}
