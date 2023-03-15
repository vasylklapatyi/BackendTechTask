using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace TechTask.Web.Host.Controllers;

[ApiController]
public class TreeController : ControllerBase

{
    private readonly ITreeService _service;
    public TreeController(ITreeService treeService)
    {
        _service = treeService;
    }

    [HttpPost("api.user.tree.get")]
    public TreeDto GetTree([FromQuery] string treeName)
    {
        var tree = _service.Get(treeName);
        return tree;
    }

}