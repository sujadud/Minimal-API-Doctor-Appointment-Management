using AMS.MinimalAPI.Application.Roles.Commands;
using AMS.MinimalAPI.Application.Roles.Queries;
using MediatR;

namespace AMS.MinimalAPI.Presentation.Endpoints;

public static class RoleEndpoints
{
    public static void MapRoleEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/roles").WithTags("Roles");

        group.MapPost("/", async (IMediator mediator, CreateRoleCommand command) =>
        {
            var result = await mediator.Send(command);
            return Results.Created($"/api/roles/{result}", result);
        });

        group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var result = await mediator.Send(new GetRoleByIdQuery(id));
            return result is not null ? Results.Ok(result) : Results.NotFound();
        });

        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetRolesQuery());
            return Results.Ok(result);
        });

        group.MapPut("/{id:guid}", async (IMediator mediator, Guid id, UpdateRoleCommand command) =>
        {
            if (id != command.Id) return Results.BadRequest();
            var result = await mediator.Send(command);
            return result ? Results.NoContent() : Results.NotFound();
        });

        group.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var result = await mediator.Send(new DeleteRoleCommand(id));
            return result ? Results.NoContent() : Results.NotFound();
        });
    }
}