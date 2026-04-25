using System.Runtime.CompilerServices;

namespace WebApp.Model
{
	public class EmployeeRespository : IEmployeeRespository
	{
		private IDepartmentRespository departmentRespository;
		private int _count { get; set; }
		public EmployeeRespository(IDepartmentRespository departmentRespository)
		{
			this.departmentRespository = departmentRespository;
			_count = _employees.Count;
		}

		private List<Employee> _employees = new List<Employee>()
		{
			new Employee(1,"John Doe","Engineer",60000,1),
			new Employee(2,"Jane Smith","Manager",75000,1),
			new Employee(3,"Sam Brown","Technician",50000,1),

			new Employee(4,"Alice Johnson","Analyst",55000,2),
			new Employee(5,"Bob Lee","Developer",65000,2),
			new Employee(6,"Carol Wang","Designer",70000,2),

			new Employee(7,"David Kim","Support",48000,3),
			new Employee(8,"Eve Rougers","Consultant",72000,3),
			new Employee(9,"Franklin Zhang","Architect",80000,3),

			new Employee(10,"Grace Liu","Coordinator",53000,1),
			new Employee(11,"Henry Tomspson","Specialitt",62000,2),
			new Employee(12,"Isabelle Nguyen","Techniciaan",57000,3),
		};

		public List<Employee> GetEmployees(string? filter = null, int? departmentId = null)
		{
			//filter是员工名字的筛选
			foreach (var emp in _employees)
			{
				//妈的这个GetEmployee的时候把Department给赋值了 我说怎么莫名其妙把这个Department给绑定了
				emp.Department = departmentRespository.GetDepartmentById(emp.DepartmentId);
			}
			if (departmentId.HasValue)
			{
				//这里ToList的时候相当于从模板里面又刻出来一份是一个新的集合，但是引用的还是原来引用里面的对象
				var newEmployees = _employees.Where(x => x.DepartmentId == departmentId).ToList();
				return newEmployees;
			}
			else if (!string.IsNullOrEmpty(filter))
			{
				return _employees.Where(x => x.Name is not null && x.Name.Contains(filter, StringComparison.CurrentCultureIgnoreCase)).ToList();
			}
			return _employees;
		}

		public Employee? GetEmployeeById(int id) => _employees.FirstOrDefault(x => x.Id == id);

		public void AddEmployee(Employee? employee)
		{
			if (employee != null)
			{
				_count++;
				employee.Id = _count;
				_employees.Add(employee);
			}
		}

		public bool UpdateEmployee(Employee? employee)
		{
			if (employee != null)
			{
				//根据id找到要更改的员工
				var emp = _employees.FirstOrDefault(x => x.Id == employee.Id);
				if (emp != null)
				{
					emp.Name = employee.Name;
					emp.Position = employee.Position;
					emp.Salary = employee.Salary;
					emp.DepartmentId = employee.DepartmentId;
					return true;
				}
			}
			return false;
		}

		public bool DeleteEmployee(Employee? employee)
		{
			if (employee != null)
			{
				_employees.Remove(employee);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
