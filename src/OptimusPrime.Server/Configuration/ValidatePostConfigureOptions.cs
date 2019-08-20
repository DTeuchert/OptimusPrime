﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;
using OptimusPrime.Server.Configuration.Options;


namespace OptimusPrime.Server.Configuration
{
    public class ValidatePostConfigureOptions<TOptions> : IPostConfigureOptions<TOptions> where TOptions : class
    {
        public void PostConfigure(string name, TOptions options)
        {
            var context = new ValidationContext(options);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(options, context, validationResults, validateAllProperties: true))
            {
                var optionName = OptionNameOrNull(options);
                var message = (optionName == null)
                    ? $"Invalid options"
                    : $"Invalid '{optionName}' options";

                throw new InvalidOperationException(
                    $"{message}: {string.Join("\n", validationResults)}");
            }
        }
        private string OptionNameOrNull(TOptions options)
        {
            if (options is OptimusPrimeOptions) return null;

            if (options is DatabaseOptions) return "Database";

            // Trim the "Options" suffix.
            var optionsName = typeof(TOptions).Name;
            if (optionsName.EndsWith("Options"))
            {
                return optionsName.Substring(0, optionsName.Length - "Options".Length);
            }

            return optionsName;
        }
    }
}
