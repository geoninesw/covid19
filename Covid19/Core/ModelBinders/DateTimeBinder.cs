using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Core.ModelBinders
{
    public class DateTimeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            // Check if the argument value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            if (!DateTime.TryParse(value, out var checkDate))
            {
                // Non-integer arguments result in model state errors
                bindingContext.ModelState.TryAddModelError(
                    modelName, "Invalid input string: require DateTime");

                return Task.CompletedTask;
            }

            DateTime dt;
            if (DateTime.TryParseExact(value, "dd/MM/yyyy HH:mm", new System.Globalization.CultureInfo("th-TH"), System.Globalization.DateTimeStyles.None, out dt))
            {
                bindingContext.Result = ModelBindingResult.Success(dt);
                return Task.CompletedTask;
            }
            else if (DateTime.TryParseExact(value, "dd/MM/yyyy", new System.Globalization.CultureInfo("th-TH"), System.Globalization.DateTimeStyles.None, out dt))
            {
                bindingContext.Result = ModelBindingResult.Success(dt);
                return Task.CompletedTask;
            }
            else
            {
                DateTime.TryParseExact(value, "MM/yyyy", new System.Globalization.CultureInfo("th-TH"), System.Globalization.DateTimeStyles.None, out dt);
                bindingContext.Result = ModelBindingResult.Success(dt);
                return Task.CompletedTask;
            }
        }
    }
}
