using FeedbackSystem.Application.Commands.SubmitFeedback;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FeedbackSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {
        private readonly IMediator _mediator;

        public FeedbackController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<string> Post([FromBody] SubmitFeedbackCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
