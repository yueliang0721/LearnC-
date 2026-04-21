using System.Reflection.Metadata.Ecma335;
using WebApplication1.Model;

namespace WebApplication1
{
    public class EmployeeResposity : IEmployeeResposity
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee(1,"孙恩浩","414宿舍长"),
            new Employee(2,"丁盟","软件工程老师"),
            new Employee(3,"王伟","全栈老师")
        };

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public void AddEmployee(Employee em) => employees.Add(em);
        public void AddEmployee(int id, string name, string depart) => AddEmployee(new Employee(id, name, depart));

        public Employee? GetEmployeeById(int id) => employees.FirstOrDefault(x => x.Id == id);
        public bool DeleteEmployeeById(int id)
        {
            Employee? em = GetEmployeeById(id);
            if (em == null)
            {
                return false;
            }
            else
            {
                employees.Remove(em);
                return true;
            }
        }

        public void Updata(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return;
            }
            if (GetEmployeeById(id) == null)
            {
                employees.Add(employee);
            }
            else
            {
                Employee employee1 = GetEmployeeById(id)!;
                //通过指针修改 反正不是值类型
                employee1.Name = employee.Name;
                employee1.Id = employee.Id;
                employee1.Department = employee.Department;
            }
        }

    }
}
