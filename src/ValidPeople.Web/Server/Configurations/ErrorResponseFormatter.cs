using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ValidPeople.Web.Shared;

namespace ValidPeople.Web.Server.Configurations
{
    public static class ErrorResponseFormatter
    {
        public static void UseErrorTemplate(this ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = c =>
            {
                var errors = new List<ErrorViewModel>();

                foreach (string key in c.ModelState.Keys)
                {
                    var state = c.ModelState[key];

                    var stateErrors = state.Errors.Select(e => new ErrorViewModel
                    {
                        Field = key,
                        Message = e.ErrorMessage,
                        Value = state.RawValue
                    });

                    errors.AddRange(stateErrors);
                }

                return new BadRequestObjectResult(errors);
            };
        }
    }
}
