using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi_.NetCore.Model_Binders
{
	public class CustomModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			var data = bindingContext.HttpContext.Request.Query;

			var value = data.TryGetValue("countries", out var countries);

			if(value)
			{
				var countryList = countries.ToString().Split("|");

				bindingContext.Result = ModelBindingResult.Success(countryList);
			}

			return Task.CompletedTask;
		}
	}
}
