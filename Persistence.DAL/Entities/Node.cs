using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAL.Entities;

public class Node
{
    public long Id { get; set; }
    public string TreeName { get; set; }
    public long? ParentNodeId { get; set; }
    public Node ParentNode { get; set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; set; }
}
