namespace SemMultiLang.LanguageWEB.Middleware
{
    public static class MiddlewareExtensionsCookiesRequestLocalization
    {
        public static IApplicationBuilder UseRequestLocalizationCookies(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MiddlewareCookiesRequestLocalization>();
        }
    }
}
