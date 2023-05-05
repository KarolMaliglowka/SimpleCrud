using SimpleCrud.Application.Abstractions;
using SimpleCrud.Application.Dtos;
using SimpleCrud.Application.Queries;

namespace SimpleCrud.Web;

public static class PhoneApi
{
    public static WebApplication UsePhoneApi(this WebApplication app)
    {
        // app
        //     .MapGet("api/phones/",
        //     async (IQueryHandler<GetPhonesNumbers, IEnumerable<PhoneDto>> handler) =>
        //     {
        //         var phoneDto = await handler.HandleAsync(new GetPhonesNumbers());
        //         return Results.Ok(phoneDto);
        //     });

        app.MapGet("api/phones1/", () => "hello world");

        return app;
    }
}