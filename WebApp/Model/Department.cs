using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebApp.Model
{
	public class Department
	{
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Describe { get; set; }

		public int? Id { get; set; }
		[Required]
		[EmailAddress(ErrorMessage ="Email Must be Validation")]
		public string? Email { get; set; }

		public Department(string name,string describe,int? id,string? email = null)
		{
			Name = name;
			Describe = describe;
			Id = id;
			if (email != null)
			{
				Email = email;
			}
			else
			{
				Email = "114514@qq.com";
			}

		}

		public Department()
		{
			
		}
	}
}
