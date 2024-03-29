﻿namespace Ebla.Web.Services.Interfaces
{
    public interface IHttpService<T>
    {
        Task<T> GetAsync(string url);
        Task<IEnumerable<T>> GetListAsync(string url);
        Task<T> PostAsync(string url, object data);
        Task<T> DeleteAsync(string url, object data);
    }
}
