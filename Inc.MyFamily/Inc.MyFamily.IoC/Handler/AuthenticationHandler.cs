using Inc.MyFamily.Shared.Constants;
using Microsoft.AspNetCore.Http;

namespace Inc.MyFamily.IoC.Handler
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _Context;

        public AuthenticationHandler(IHttpContextAccessor context)
        {
            _Context = context;
        }

        private const string CacheKey = $"{nameof(AuthenticationHandler)} CacheKey";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var inforUser = _Context.HttpContext.User;
            var claim = inforUser.FindFirst("TOKEN");
            if (claim != null)
            {
                var accessToken = claim.Value;
                request.Headers.Authorization = new("Bearer", accessToken);
            }
            else
                throw new HttpRequestException(ErrorMessages.ErrorCommunicatingAuthenticate.Message);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
