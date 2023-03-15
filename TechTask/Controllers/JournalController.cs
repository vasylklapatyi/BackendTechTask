using Application.IServices;
using Application.Services.Journal.Dto;
using Microsoft.AspNetCore.Mvc;

namespace TechTask.Controllers;

[ApiController]
public class JournalController : ControllerBase
{
    private readonly IJournalService _service;
    public JournalController(IJournalService treeService)
    {
        _service = treeService;
    }
    [HttpPost("api.user.journal.getRange")]
    public List<LogDto> GetRange([FromQuery]GetRangeDto dto)
    {
        return _service.GetRange(dto);
    }
    [HttpPost("api.user.journal.getSingle")]
    public LogDto GetSingle([FromQuery]long id)
    {
        return _service.GetSingle(id);
    }
}