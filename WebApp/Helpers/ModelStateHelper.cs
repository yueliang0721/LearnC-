using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Helpers
{
	public static class ModelStateHelper
	{
		public static List<string?> GetErrors(ModelStateDictionary modelState)
		{
			List<string?> errors = new List<string?>();
			foreach (var value in modelState.Values)
			{
				foreach (var error in value.Errors)
				{
					errors.Add(error.ErrorMessage);
				}
			}
			return errors;
		}
	}
}
