﻿using Microsoft.EntityFrameworkCore;
using RichDomain.API.Business.Domain.Handlers.PaginationHandler;
using RichDomain.API.Business.Domain.Interfaces.OthersContracts;

namespace RichDomain.API.Business.Insfrastructure.Services;
public sealed class PaginationQueryService<T> : IPaginationQueryService<T> where T : class
{
    public async Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();

        return new PageList<T>(items, count, pageNumber, pageSize);
    }
}
