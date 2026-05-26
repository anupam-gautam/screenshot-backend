using System.Collections.Generic;

namespace application.Tenants
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int Total { get; set; }
    }
}