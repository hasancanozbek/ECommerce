﻿
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ICategoryRepository : IAsyncRepository<Category, Guid>, IRepository<Category, Guid>
    {

    }
}
