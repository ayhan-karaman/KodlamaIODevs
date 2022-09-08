using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Language : Entity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Technology> Technologies { get; set; }
    public Language()
    {
        
    }
    public Language(int id, string name, bool isActive):this()
    {
        Id = id;
        Name = name;
        IsActive = isActive;
        
    }
}