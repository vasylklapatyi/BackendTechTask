using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Dto;

public class CreateNodeDto
{
    public string TreeName { get; set; }
    public string Name { get; set; }
    public long ParentNodeId { get; set; }
}
