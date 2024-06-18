using System.Net;
using MessagingApp.Contracts;
using MessagingApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ILogger = MessagingApp.Infrastructure.ILogger;

namespace MessagingApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
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

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _groupService.GetAllGroups();

        if (result is null)
        {
            _logger.Info(nameof(GroupsController), nameof(GetAll), "Failed to get all groups");

            return BadRequest();
        }

        return Ok(result);
    }

    [HttpGet("id/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _groupService.GetGroupById(id);

        if (result is null)
        {
            _logger.Info(nameof(GroupsController), nameof(GetById), $"Failed to get group with id:{id}");

            return BadRequest();
        }

        return Ok(result);
    }

    [HttpGet("name/{name}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetByName(string name)
    {
        var result = await _groupService.GetGroupByName(name);

        if (result is null)
        {
            _logger.Info(nameof(GroupsController), nameof(GetByName), $"Failed to get group with name:{name}");

            return BadRequest();
        }

        return Ok(result);
    }


    [HttpPost]
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

    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] GroupDto groupDto)
    {
        var result = await _groupService.UpdateGroup(id, groupDto);

        if (!result)
        {
            _logger.Info(nameof(GroupsController), nameof(Update), $"Update group failed for group:{groupDto.Name}");

            return BadRequest();
        }

        _logger.Info(nameof(GroupsController), nameof(Create), $"Update group:{groupDto.Name}");

        return Ok();
    }


    [HttpDelete("id/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _groupService.DeleteGroupById(id);

        if (!result)
        {
            _logger.Info(nameof(GroupsController), nameof(Delete), $"Delete group failed for group with id:{id}");

            return BadRequest();
        }

        _logger.Info(nameof(GroupsController), nameof(Create), $"Deleted group with id:{id}");

        return Ok();
    }

    [HttpDelete("name/{name}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete(string name)
    {
        var result = await _groupService.DeleteGroupByName(name);

        if (!result)
        {
            _logger.Info(nameof(GroupsController), nameof(Delete), $"Delete group failed for group named:{name}");

            return BadRequest();
        }

        _logger.Info(nameof(GroupsController), nameof(Create), $"Deleted group named:{name}");

        return Ok();
    }
}
