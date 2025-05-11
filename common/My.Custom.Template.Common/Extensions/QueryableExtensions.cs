﻿using Microsoft.EntityFrameworkCore;
using My.Custom.Template.Common.Response;

namespace My.Custom.Template.Common.Extensions;

public static class QueryableExtensions
{
    public static async Task<PaginatedResult<T>> ToPaginatedResultAsync<T>(
        this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var totalRecords = await query.CountAsync(cancellationToken);

        var data = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedResult<T>(data, totalRecords, pageNumber, pageSize);
    }
}
