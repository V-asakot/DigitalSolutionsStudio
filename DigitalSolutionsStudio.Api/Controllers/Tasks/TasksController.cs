using DigitalSolutionsStudio.Api.Controllers.Tasks.Models;
using DigitalSolutionsStudio.Api.Features.GetTasks;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DigitalSolutionsStudio.Api.Controllers.Tasks
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {

        private readonly IMediator _mediator;
        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieve all tasks from database. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<GetTasksResponse>> GetTasks()
        {
            var getTaskQuery = new GetTasksQuery();

            var getTaskQueryResult = await _mediator.Send(getTaskQuery);

            var res = getTaskQueryResult.Adapt<GetTasksResponse>();
            return res;
        }
    }
}
