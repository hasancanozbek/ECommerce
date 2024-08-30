
namespace Application.Features.Categories.Commands.Create
{
    public class CreatedCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
