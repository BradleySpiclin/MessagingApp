using System.Net;
using MessagingApp.Contracts;
using MessagingApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ILogger = MessagingApp.Infrastructure.ILogger;

namespace MessagingApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupsController : ControllerBase
{
    private readonly IGroupService _groupService;
    private readonly ILogger _logger;

    public GroupsController(
        IGroupService groupService,
        ILogger logger)
    {
        _groupService = groupService;
        _logger = logger;
    }

    [HttpPost]
    [Route("Groups")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] GroupDto groupDto)
    {
        var result = await _groupService.CreateGroup(groupDto);

        if (!result)
        {
            _logger.Info(nameof(GroupsController), nameof(Create), $"Create group failed for group:{groupDto.Name}");

            return BadRequest();
        }

        _logger.Info(nameof(GroupsController), nameof(Create), $"Created group:{groupDto.Name}");

        return Ok();
    }
}
