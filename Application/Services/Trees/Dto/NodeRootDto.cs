using Application.Services.Dto;
public class TreeDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<NodeDto> Children { get; set; }
}