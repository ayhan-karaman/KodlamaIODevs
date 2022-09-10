namespace Application.Features.Languages.Dtos;
public class LanguageListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public List<TechnologyNameModels> TechnologyNames { get; set; }
    public struct TechnologyNameModels
    {
        public string Name { get; set; }
    }
}
