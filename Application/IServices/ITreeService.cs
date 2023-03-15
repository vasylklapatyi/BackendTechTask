using Application.Services.Dto;

namespace Application.IServices;

public interface ITreeService
{
    void RenameNode(RenameNodeDto dto);
    void DeleteNode(DeletenodeDto dto);
    void CreateNode(CreateNodeDto dto);
    TreeDto Get(string treeName);
}
