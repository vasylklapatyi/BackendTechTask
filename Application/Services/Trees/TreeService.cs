using Application.Exceptions;
using Application.IServices;
using Application.Services.Dto;
using Persistence.DAL;
using Persistence.DAL.Entities;

namespace Application.Services.Trees;

public class TreeService : ITreeService
{
    private readonly TechTaskDbContext _dbContext;
    public TreeService(TechTaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateNode(CreateNodeDto dto)
    {
        var existingNode = _dbContext
                                    .Nodes
                                    .Any(n => n.TreeName == dto.TreeName && n.Name == dto.Name);
        if (existingNode)
        {
            throw new NodeAlreadyExistsException();
        }

        //check if the tree we try to insertin has a root item
        var rootExists = _dbContext.Nodes.Any(n => n.TreeName == dto.TreeName && n.ParentNodeId == null);
        if (!rootExists && dto.ParentNodeId != null)
        {
            throw new TreeDoesNotExistException();
        }

        _dbContext.Nodes.Add(new()
        {
            Name = dto.Name,
            ParentNodeId = dto.ParentNodeId,
            TreeName = dto.TreeName,
            DateCreated = DateTime.UtcNow
        });
        _dbContext.SaveChanges();
    }

    public void DeleteNode(DeletenodeDto dto)
    {
        var entity = _dbContext.Nodes.FirstOrDefault(x => x.TreeName == dto.TreeName && x.Id == dto.NodeId);
        if (entity == null)
        {
            throw new NodeNotFoundException();
        }
        _dbContext.Nodes.Remove(entity);
        _dbContext.SaveChanges();
    }

    public TreeDto Get(string treeName)
    {
        var nodes = _dbContext.Nodes.Where(x => x.TreeName == treeName);
        var root = nodes.FirstOrDefault(x => x.ParentNodeId == null);
        var result = new TreeDto()
        {
            Id = root.Id,
            Name = root.Name,
            Children = nodes.Except(new List<Node>() { root }).Select(x => new NodeDto()
            {
                Id = x.Id,
                Name = x.Name,
                ParentNodeId = x.ParentNodeId,
                DateCreated = x.DateCreated
            }).ToList()
        };
        return result;
    }

    public void RenameNode(RenameNodeDto dto)
    {
        var entity = _dbContext.Nodes.FirstOrDefault(x => x.TreeName == dto.TreeName && x.Id == dto.NodeId);
        if (entity == null)
        {
            throw new NodeNotFoundException();
        }
        entity.Name = dto.NewNodeName;
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }
}
