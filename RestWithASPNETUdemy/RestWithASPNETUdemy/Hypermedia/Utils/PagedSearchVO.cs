using RestWithASPNETUdemy.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Hypermedia.Utils
{
    public class PagedSearchVO<T> where T : ISupportHyperMedia 
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public string SortFIelds { get; set; }
        public string SortDirections { get; set; }
        public Dictionary<string, object> Filters { get; set; }
        public List<T> List { get; set; }

        public PagedSearchVO() {}

        public PagedSearchVO(int currentPage, int pageSize, string sortFIelds, string sortDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFIelds = sortFIelds;
            SortDirections = sortDirections;
        }

        public PagedSearchVO(int currentPage, int pageSize, string sortFIelds, string sortDirections, Dictionary<string, object> filters) : this(currentPage, pageSize, sortFIelds, sortDirections)
        {
            Filters = filters;
        }

        public PagedSearchVO(int currentPage, string sortFIelds, string sortDirections) : this(currentPage, 10, sortFIelds, sortDirections) {}

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }

        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : PageSize;
        }
    }
}
