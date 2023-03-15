using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAL.Entities;

public class Log
{
    public long Id { get; set; }
    public string Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Message { get; set; }
    public string StackTrace { get; set; }
    public string Route { get; set; }
    public string Headers { get; set; }
    public string Body { get; set; }
}
