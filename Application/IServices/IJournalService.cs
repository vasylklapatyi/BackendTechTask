using Application.Services.Journal.Dto;

namespace Application.IServices;

public interface IJournalService
{
    List<LogDto> GetRange(GetRangeDto query);
    LogDto GetSingle(long id);
}
