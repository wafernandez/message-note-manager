using Microsoft.OpenApi.Models;

namespace MessageNoteManager.WebAPI.OpenApiSecurity
{
    public class OpenApiOAuthSecurityScheme : OpenApiSecurityScheme
    {
        public OpenApiOAuthSecurityScheme(string domain, string audience)
        {
            Type = SecuritySchemeType.OAuth2;
            Flows = new OpenApiOAuthFlows()
            {
                Implicit = new OpenApiOAuthFlow()
                {
                    AuthorizationUrl = new Uri($"https://{domain}/authorize"),
                    TokenUrl = new Uri($"https://{audience}/token")
                }
            };
        }
    }
}
