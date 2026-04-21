using WebApplication1.Model;

namespace WebApplication1
{
    public interface IEmployeeResposity
    {
        void AddEmployee(Employee em);
        void AddEmployee(int id, string name, string depart);
        bool DeleteEmployeeById(int id);
        Employee? GetEmployeeById(int id);
        List<Employee> GetEmployees();
        void Updata(int id, Employee employee);
    }
}