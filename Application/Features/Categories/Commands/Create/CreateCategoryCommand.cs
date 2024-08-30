
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<CreatedCategoryResponse>? Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category category = _mapper.Map<Category>(request);
                category.Id = Guid.NewGuid();

                var result = await _categoryRepository.AddAsync(category);
                CreatedCategoryResponse response = _mapper.Map<CreatedCategoryResponse>(result);

                return response;
            }
        }
    }
}
