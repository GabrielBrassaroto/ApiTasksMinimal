using Dapper.Contrib.Extensions;
using System.Linq;
using static ApiTasksMinimal.Data.TaskContext;


namespace ApiTasksMinimal.Endpoints
{
    public static class TasksEnpoints
    {
        public static void MapTasksEndPoints(this WebApplication app)
        {
            app.MapGet("/", () => $"Welcome APi TAKS {DateTime.Now}");

            app.MapGet("/tasks", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                var tasks = con.GetAll<Task>().ToList();

                if (tasks is null)
                    return Results.NotFound();  

                return  Results.Ok(tasks);  
            });

            app.MapGet("/tasks/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();


                return  con.Get<Task>(id) is Task task ? Results.Ok(task) :Results.NotFound();
            });

            app.MapPost("/taks", async (GetConnection connectionGetter, Task Task) => {

                using var con = await connectionGetter();
                var id = con.Insert(Task);
                return Results.Created($"/tasks/{id}", Task);
            });

            app.MapPut("/taks", async (GetConnection connectionGetter, Task Task) => {

                using var con = await connectionGetter();
                var id = con.Update(Task);
                return Results.Ok();
            });

        }
    }
}
