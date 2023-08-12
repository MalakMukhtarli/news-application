using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NewsApplication.MVC.Models;

public sealed class PagedViewModel<T>
    where T : class
{
    public List<T> Items { get; }
    public int PageIndex { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public PagedViewModel(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int) Math.Ceiling(count / (double) pageSize);
        TotalCount = count;
        Items = items; 
    }

    public PagedViewModel<T> AfterLoad(Action<PagedViewModel<T>> action)
    {
        action.Invoke(this);
        return this;
    }
    
    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;

    public static async Task<PagedViewModel<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedViewModel<T>(items, count, pageIndex, pageSize);
    }

    public static async Task<PagedViewModel<T>> CreateAsync(IEnumerable<T> source, int pageIndex, int pageSize)
    {
        var count = source.Count();
        var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

        return new PagedViewModel<T>(items, count, pageIndex, pageSize);
    }
}