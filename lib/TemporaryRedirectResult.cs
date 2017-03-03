using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace AppAPI
{
    public class TemporaryRedirectResult : ObjectResult
    {
        private string _location;
        public TemporaryRedirectResult(string location, object value)
            : base(value)
        {
            _location = location;
        }

        public override void OnFormatting(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            base.OnFormatting(context);

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.RedirectKeepVerb;
            context.HttpContext.Response.Headers[HeaderNames.Location] = _location;
        }
    }
}
