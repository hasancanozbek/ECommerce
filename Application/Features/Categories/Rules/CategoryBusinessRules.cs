using Application.Features.Categories.Constants;
using Application.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Categories.Rules
{
    public class CategoryBusinessRules : BaseBusinessRules
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CategoryNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _categoryRepository.GetAsync(predicate: c => c.Name.ToLower() == name.ToLower());
            if (result != null) 
            {
                throw new BusinessException(CategoryMessages.CategoryNameExist);
            }
        }
    }
}
