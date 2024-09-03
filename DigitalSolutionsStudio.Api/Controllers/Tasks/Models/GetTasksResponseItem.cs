using DigitalSolutionsStudio.Api.Db.Entities;

namespace DigitalSolutionsStudio.Api.Controllers.Tasks.Models
{
    public record GetTasksResponseItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TaskCompletionStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
