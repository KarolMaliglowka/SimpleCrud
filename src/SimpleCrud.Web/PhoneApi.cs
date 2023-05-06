using SimpleCrud.Core.Repositories;

namespace SimpleCrud.Web;

public static class PhoneApi
{
    public static WebApplication UsePhoneApi(this WebApplication app)
    {
        app
            .MapGet("api/phones/",
                async (IPhoneBookRepository phoneBookRepository) =>
                {
                    var results = await phoneBookRepository.GetAllAsync();
                    return Results.Ok(results);
                });
        app
            .MapGet("api/phones/{id:guid}",
            async (IPhoneBookRepository phoneBookRepository, Guid id) =>
            {
                var results = await phoneBookRepository.GetAsyncById(id);
                return Results.Ok(results);
            });

        return app;
    }
}