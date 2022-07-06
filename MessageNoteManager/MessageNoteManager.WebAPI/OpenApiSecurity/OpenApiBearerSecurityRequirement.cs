using Microsoft.OpenApi.Models;

namespace MessageNoteManager.WebAPI.OpenApiSecurity
{
    public class OpenApiBearerSecurityRequirement : OpenApiSecurityRequirement
    {
        public OpenApiBearerSecurityRequirement(OpenApiSecurityScheme securityScheme)
        {
            this.Add(securityScheme, new[] { "Bearer" });
        }
    }
}
