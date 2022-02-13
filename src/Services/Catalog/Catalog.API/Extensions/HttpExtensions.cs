using System.Text.Json;

namespace Catalog.API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage,
            int itemsPerPage, int totalItems, int totalPages, string search)
        {
            var paginationHeader = new
            {
                currentPage,
                itemsPerPage,
                totalItems,
                totalPages
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader));
            response.Headers.Add("Search", JsonSerializer.Serialize(search));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
