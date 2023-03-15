using Application.IServices;
using Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace TechTask.Controllers;

[ApiController]
public class NodeController : ControllerBase
{
    private readonly ITreeService _service;
	public NodeController(ITreeService treeService)
	{
		_service = treeService;
	}

	[HttpPost("api.user.tree.node.create")]
	public IActionResult CreeateNode([FromQuery]CreateNodeDto dto)
	{
		_service.CreateNode(dto);
		return Ok();
	}

	[HttpPost("api.user.tree.node.delete")]
	public IActionResult DeleteNode([FromQuery]DeletenodeDto
		dto)
	{
		_service.DeleteNode(dto);
		return Ok();
	}

	[HttpPost("api.user.tree.node.rename")]
	public IActionResult RenameNode([FromQuery]RenameNodeDto dto)
	{
		_service.RenameNode(dto);
		return Ok();
	}
}
