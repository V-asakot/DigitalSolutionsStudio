using DigitalSolutionsStudio.Api.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DigitalSolutionsStudio.Api.Features.GetTasks
{
    public class GetTasksHandler : IRequestHandler<GetTasksQuery, GetTasksResult>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetTasksHandler(ApplicationDbContext repository)
        {
            _dbContext = repository;
        }

        public async Task<GetTasksResult> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _dbContext.Tasks.ToListAsync();
            return new GetTasksResult { Tasks = tasks };
        }
    }
}
