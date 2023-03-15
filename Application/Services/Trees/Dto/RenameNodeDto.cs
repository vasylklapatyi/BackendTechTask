using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Dto;

public class RenameNodeDto
{
    public string TreeName { get; set; }
    public long NodeId { get; set; }
    public string NewNodeName { get; set; }
}
