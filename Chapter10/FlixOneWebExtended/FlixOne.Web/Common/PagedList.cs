using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FlixOne.Web.Common
{
    public class PagedList<T> : List<T>
    {
        public PagedList(List<T> list, int totalRecords, int currentPage, int recordPerPage)
        {
            CurrentPage = currentPage;
            TotalPages = (int) Math.Ceiling(totalRecords / (double) recordPerPage);

            AddRange(list);
        }

        public int CurrentPage { get; }
        public int TotalPages { get; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> queryable, int currentPage, int recordPerPage)
        {
            var count = await queryable.CountAsync();
            var items = await queryable.Skip((currentPage - 1) * recordPerPage).Take(recordPerPage).ToListAsync();
            return new PagedList<T>(items, count, currentPage, recordPerPage);
        }

        public static PagedList<T> CreateSync(IQueryable<T> queryable, int currentPage, int recordPerPage)
        {
            var totalRecords = queryable.Count();
            var list = queryable.Skip((currentPage - 1) * recordPerPage).Take(recordPerPage).ToList();
            return new PagedList<T>(list, totalRecords, currentPage, recordPerPage);
        }

      
    }
}