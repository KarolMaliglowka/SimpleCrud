using SimpleCrud.Application.Abstractions;
using SimpleCrud.Application.Dtos;
using SimpleCrud.Application.Queries;

namespace SimpleCrud.Web;

public static class PhoneApi
{
    private const string MeRoute = "me";

    public static WebApplication UsePhoneApi(this WebApplication app)
    {
        app.MapGet("api/phones/me",
            async (HttpContext context, IQueryHandler<GetPhonesNumbers, IEnumerable<PhoneDto>> handler) =>
            {
                var phoneDto = await handler.HandleAsync(new GetPhonesNumbers());
                return Results.Ok(phoneDto);
            }).RequireAuthorization().WithName(MeRoute);

        return app;
    }
}