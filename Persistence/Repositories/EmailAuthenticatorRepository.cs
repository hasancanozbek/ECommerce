﻿using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EmailAuthenticatorRepository : EFRepositoryBase<EmailAuthenticator, int, BaseDbContext>, IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(BaseDbContext context)
        : base(context) { }
}
