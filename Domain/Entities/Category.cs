
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }

        public Category()
        {
                
        }

        public Category(Guid id, string name, Guid parentCategoryId)
        {
            Id = id;
            Name = name;
            ParentCategoryId = parentCategoryId;
        }
    }
}
