using AMS.MinimalAPI.Application.Users.Commands;
using AMS.MinimalAPI.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AMS.MinimalAPI.Presentation.Endpoints;
public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/users");

        // Create User
        group.MapPost("/", async ([FromBody] CreateUserCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Results.Ok(result);
        });

        // Update User
        group.MapPut("/{id:guid}", async (Guid id, [FromBody] UpdateUserCommand command, ISender sender) =>
        {
            if (id != command.Id) return Results.BadRequest("User ID mismatch");

            var result = await sender.Send(command);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        });

        // Soft Delete User
        group.MapDelete("/{id:guid}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteUserCommand(id));
            return result ? Results.NoContent() : Results.NotFound();
        });

        // Get User by ID
        group.MapGet("/{id:guid}", async (Guid id, ISender sender) =>
        {
            var user = await sender.Send(new GetUserByIdQuery(id));
            return user is not null ? Results.Ok(user) : Results.NotFound();
        });

        // Get All Users
        group.MapGet("/", async (ISender sender) =>
        {
            var users = await sender.Send(new GetUsersQuery());
            return Results.Ok(users);
        });
    }
}