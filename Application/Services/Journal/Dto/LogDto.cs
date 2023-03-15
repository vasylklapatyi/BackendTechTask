using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Journal.Dto;

public class LogDto
{
    public long Id { get; set; }
    public string Type { get; set; }
    public string EventId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Message { get; set; }

}
