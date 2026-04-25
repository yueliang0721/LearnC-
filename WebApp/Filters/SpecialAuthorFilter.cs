using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
	public class SpecialAuthorFilter : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var user = context.HttpContext.User;
			if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
			{
				context.Result =  new UnauthorizedResult();
			}

			if(!user!.HasClaim(c=>c.Type == "UserClaim" && c.Value == "UserValue"))
			{
				context.Result = new UnauthorizedResult();
			}


		}
	}
}
