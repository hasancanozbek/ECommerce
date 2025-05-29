
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<UpdatedCategoryResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string CacheKey => string.Empty;

        public bool BypassCache => false;

        public string? CacheGroupKey => "GetCategories";

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category? category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
                category = _mapper.Map(request, category);

                await _categoryRepository.UpdateAsync(category);
                UpdatedCategoryResponse response = _mapper.Map<UpdatedCategoryResponse>(category);

                return response;
            }
        }
    }
}
