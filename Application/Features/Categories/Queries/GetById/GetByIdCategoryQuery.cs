﻿
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetById
{
    public class GetByIdCategoryQuery : IRequest<GetByIdCategoryResponse>
    {
        public Guid Id { get; set; }
        
        public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponse>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryRepository _categoryRepository;

            public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdCategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
            {
                Category? category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
                GetByIdCategoryResponse response = _mapper.Map<GetByIdCategoryResponse>(category);
                return response;
            }
        }
    }
}
