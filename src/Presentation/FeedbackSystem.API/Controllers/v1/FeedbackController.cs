using Asp.Versioning;
using FeedbackSystem.Application.Commands.SubmitFeedback;
using FeedbackSystem.Application.Queries.GetAllFeedback;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.API.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{v:apiVersion}/feedback")]
public class FeedbackController : Controller
{
    private readonly IMediator _mediator;

    public FeedbackController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [MapToApiVersion("1")]
    [HttpPost]
    public Task<string> Post([FromBody] SubmitFeedbackCommand command)
    {
        return _mediator.Send(command);
    }

    [Authorize]
    [MapToApiVersion("1")]
    [HttpGet("all")]
    public Task<GetFeedbacksVm> Get()
    {
        return _mediator.Send(new GetFeedbacksQuery());
    }
}
