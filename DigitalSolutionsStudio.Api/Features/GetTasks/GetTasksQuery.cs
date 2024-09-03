using DigitalSolutionsStudio.Api.Db;
using MediatR;

namespace DigitalSolutionsStudio.Api.Features.GetTasks
{
    public record GetTasksQuery : IRequest<GetTasksResult>
    { 
    }
}
