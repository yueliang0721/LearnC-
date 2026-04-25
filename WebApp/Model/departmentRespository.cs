namespace WebApp.Model
{
	public class departmentRespository : IDepartmentRespository
	{
		private int count;
		private List<Department> departments;


		public departmentRespository()
		{
			departments = new List<Department>()
			{
				new Department("Sales","SalesDepartment",1),
				new Department("Engineering","Engineering Department",2),
				new Department("QA","Quanlity Assurance",3),
				new Department("IT","IT support department",4)
			};
			count = departments.Count;
		}

		public List<Department> GetDepartments(string? filter = null)
		{
			if (filter == null)
			{
				return departments;
			}
			else
			{
				var departs = departments.Where(department => department.Name!.ToLower().Contains(filter.ToLower())).ToList();
				return departs;
			}
		}

		public void AddDepartment(Department? department)
		{
			if (department == null)
			{
				return;
			}
			else
			{
				count++;
				department.Id = count;
				var newDepart = new Department(department.Name, department.Describe, department.Id);
				departments.Add(newDepart);
			}
		}

		public bool DeleteDepartmentById(int? id)
		{
			//名字为空，或者 没有一个名字和输入的名字匹配
			var department = departments.FirstOrDefault(department => department.Id == id);
			if (id == null || department == null)
			{
				return false;
			}
			departments.Remove(department);
			return true;
		}

		public bool UpdateDepartment(Department? department)
		{

			if (department == null || !departments.Any(x => x.Id == department.Id))
			{
				return false;
			}

			var newDepartment = departments.FirstOrDefault(x => x.Id == department.Id);
			if (newDepartment == null)
			{
				return false;
			}
			newDepartment.Name = department.Name;
			newDepartment.Describe = department.Describe;
			newDepartment.Email = department.Email;
			return true;
		}

		public Department? GetDepartmentById(int? departmentId)
		{
			if (departmentId == null)
			{
				return null;
			}
			return departments.FirstOrDefault(x => x.Id == departmentId);
		}

		//检查这个部门是否存在
		public bool IsDepartmentExist(int id)
		{
			return departments.Any(x => x.Id == id);
		}
	}
}
