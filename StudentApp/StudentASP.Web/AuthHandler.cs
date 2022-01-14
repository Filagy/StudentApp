using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace StudentASP.Web
{
    public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public AuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {

        }

        protected async  override Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            return await AuthenticateAsync();
        }
    }
}
