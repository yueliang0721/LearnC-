using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;

namespace WebApp.Pages.Employees
{
    public class DepartmentEmployeesModel : PageModel
    {
        private IDepartmentRespository departmentRespository;

		public DepartmentEmployeesModel(IDepartmentRespository departmentRespository)
		{
			this.departmentRespository = departmentRespository;
		}
		public string? DepartmentName {  get; set; }

        [BindProperty(SupportsGet = true)]
        [FromRoute]
        public int? DepartmentId {  get; set; }
        public void OnGet()
        {
            DepartmentName = departmentRespository.GetDepartmentById(DepartmentId)?.Name;
        }
    }
}
