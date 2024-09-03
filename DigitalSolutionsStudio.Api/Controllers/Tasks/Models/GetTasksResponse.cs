namespace DigitalSolutionsStudio.Api.Controllers.Tasks.Models
{
    public record GetTasksResponse
    {
        public List<GetTasksResponseItem> Tasks { get; set; } = new List<GetTasksResponseItem>();
    }
}
