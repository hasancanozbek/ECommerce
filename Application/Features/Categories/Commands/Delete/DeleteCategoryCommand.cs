using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<DeletedCategoryResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }

        public string CacheKey => string.Empty;

        public bool BypassCache => false;

        public string? CacheGroupKey => "GetCategories";

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<DeletedCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                Category? category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
                await _categoryRepository.DeleteAsync(category);
                DeletedCategoryResponse response = _mapper.Map<DeletedCategoryResponse>(category);

                return response;
            }
        }
    }
}
