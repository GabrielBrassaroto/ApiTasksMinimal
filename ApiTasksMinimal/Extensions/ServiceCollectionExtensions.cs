using System.Data.SqlClient;
using static ApiTasksMinimal.Data.TaskContext;

namespace ApiTasksMinimal.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            //Take string data base appsettings
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddScoped<GetConnection>(
                sp => async () =>
                {
                    var connection = new SqlConnection(connectionString);
                    await connection.OpenAsync();
                    return connection;
                });
            return builder;
        }
    }
}
