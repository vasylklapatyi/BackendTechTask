using Application.IServices;
using Application.Services.Journal.Dto;
using Persistence.DAL;

namespace Application.Services.Journal;

public class JournalService : IJournalService
{
    private readonly TechTaskDbContext _dbContext;
    public JournalService(TechTaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<LogDto> GetRange(GetRangeDto dto)
    {
        var query = _dbContext.Logs.AsQueryable();
        if(dto?.Filter?.From != null)
        {
            query = query.Where(x => x.CreatedAt >= dto.Filter.From);
        }
        if (dto?.Filter?.To != null)
        {
            query = query.Where(x => x.CreatedAt <= dto.Filter.To);
        }
        if (!string.IsNullOrEmpty(dto?.Filter?.Search))
        {
            var searchtext = dto?.Filter?.Search;
            query = query.Where(x => x.Message.Contains(searchtext) || x.Type.Contains(searchtext));
        }
        if (dto?.Skip != null)
        {
            query = query.Skip(dto.Skip.Value);
        }   
        if (dto?.Take != null)
        {
            query = query.Skip(dto.Take.Value);
        }
        var result = query.ToList();

        var mapped = result.Select(x => new LogDto
        {
            Id = x.Id,
            CreatedAt = x.CreatedAt,
            Message = x.Message,
        }).ToList();
        return mapped;
    }

    public LogDto GetSingle(long id)
    {
        var searchResult = _dbContext.Logs.FirstOrDefault(x => x.Id == id);
        if(searchResult != null)
        {
            var mapped = new LogDto()
            {
                Id = searchResult.Id,
                CreatedAt = searchResult.CreatedAt,
                Message = searchResult.Message
            };
            return mapped;
        }
        else
        {
            return null;
        }
    }
}
