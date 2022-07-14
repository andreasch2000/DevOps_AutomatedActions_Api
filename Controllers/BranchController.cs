using System.Text.Json;
using DevOps.AutomatedActions.Api.Domain.Branches;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevOps.AutomatedActions.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BranchController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public BranchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Returns all the branches of the repos
    /// </summary>
    /// <response code="201">Successfully finished execution</response>
    /// <response code="400">Error occured</response>
    [HttpGet(Name = "Get All")]
    public async Task<IActionResult> GetAll(BranchesData branchesData)
    {
        string jsonString = JsonSerializer.Serialize(branchesData);
        Console.WriteLine(jsonString);

        return Ok("Data imported.");
    }
}