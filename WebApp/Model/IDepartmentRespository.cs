
namespace WebApp.Model
{
	public interface IDepartmentRespository
	{
		abstract void AddDepartment(Department? department);
		abstract bool DeleteDepartmentById(int? id);
		abstract Department? GetDepartmentById(int? departmentId);
		abstract List<Department> GetDepartments(string? filter = null);
		bool IsDepartmentExist(int id);
		abstract bool UpdateDepartment(Department? department);
	}
}