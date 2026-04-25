using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Model
{
	public class Employee
	{
		[HiddenInput]
		public int Id { get; set; }//这里对应于数据库的主键 所以不能为空
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Position { get; set; }
		public double? Salary { get; set; }
		[Required]
		[Range(minimum:1,maximum:int.MaxValue,ErrorMessage ="请选择正确的部门！")]
		public int DepartmentId { get; set; } //这里对应于数据库的外键 要确保存在 也不能为空
		public Department? Department { get; set; }

		public Employee()
		{
			
		}

		public Employee(int id,string name,string position,double salary,int departmentId)
		{
			Id = id;
			Name = name;
			Position = position;
			Salary = salary;
			DepartmentId = departmentId;
		}
	}
}
