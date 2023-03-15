using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Journal.Dto;

public class GetRangeDto
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
    public FilterDto? Filter { get; set; }
}

public class FilterDto
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public string? Search { get; set; }
}