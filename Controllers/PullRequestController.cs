﻿using System.Text.Json;
using DevOps.AutomatedActions.Api.Domain.PullRequest.Webhook;
using DevOps.AutomatedActions.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevOps.AutomatedActions.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PullRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PullRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "Creation")]
        public IActionResult Creation(object pullRequestData)
        {
            string jsonString = JsonSerializer.Serialize(pullRequestData);

            Console.WriteLine(jsonString);

            return Ok("Looks good!");
        }

        [HttpPost(Name = "Commented")]
        public async Task<IActionResult> Commented(PullRequestData pullRequestData)
        {
            await _mediator.Send(new AddReviewerHandler.Query(pullRequestData));
            return Ok("Looks good!");
        }
        
        
    }

}
