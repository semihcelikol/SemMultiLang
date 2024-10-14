using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace SemMultiLang.LanguageWEB.Middleware
{
    public class MiddlewareCookiesRequestLocalization : IMiddleware
    {
        readonly CookieRequestCultureProvider _provider;

        public MiddlewareCookiesRequestLocalization(IOptions<RequestLocalizationOptions> requestLocalizationOptions)
        {
            _provider = requestLocalizationOptions.Value.RequestCultureProviders.
                        Where(x => x is CookieRequestCultureProvider)
                        .Cast<CookieRequestCultureProvider>()
                        .FirstOrDefault();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (_provider != null)
            {
                IRequestCultureFeature feature = context.Features.Get<IRequestCultureFeature>();

                if (feature != null)
                {
                    context.Response.Cookies.Append(_provider.CookieName,
                                                    CookieRequestCultureProvider.MakeCookieValue(feature.RequestCulture));
                }
            }

            await next(context);
        }
    }
}
