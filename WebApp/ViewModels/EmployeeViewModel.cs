using WebApp.Model;

namespace WebApp.ViewModels
{
	public class EmployeeViewModel
	{
		public Employee? Employee { get; set; }
		public List<Department>? departments { get; set; }

		public void Deconstruct(out Employee? employee,out List<Department>? departs)
		{
			employee = Employee;
			departs = departments;
		}
	}
}
