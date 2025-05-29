
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }

        public string CacheKey => string.Empty;

        public bool BypassCache => false;

        public string? CacheGroupKey => "GetCategories";

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<CreatedCategoryResponse>? Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);

                Category category = _mapper.Map<Category>(request);
                category.Id = Guid.NewGuid();

                var result = await _categoryRepository.AddAsync(category);
                CreatedCategoryResponse response = _mapper.Map<CreatedCategoryResponse>(result);

                return response;
            }
        }
    }
}
