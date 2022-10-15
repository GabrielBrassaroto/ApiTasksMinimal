using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTasksMinimal.Data
{

      [Table("Tasks")]
      public record Task(int Id,string Tasks ,string Status);
}
