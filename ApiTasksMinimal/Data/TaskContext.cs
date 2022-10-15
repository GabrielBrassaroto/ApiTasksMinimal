
using System.Data;

namespace ApiTasksMinimal.Data
{
    public class TaskContext
    {
        public delegate Task<IDbConnection> GetConnection();
    }
}
