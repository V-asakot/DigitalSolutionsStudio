using DigitalSolutionsStudio.Api.Controllers.Tasks.Models;
using DigitalSolutionsStudio.Api.Db.Entities;

namespace DigitalSolutionsStudio.Api.Features.GetTasks
{
    public record GetTasksResult
    {
        public List<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    }
}
