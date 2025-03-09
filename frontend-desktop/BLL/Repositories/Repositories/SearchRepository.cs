using BLL.Network;
using BLL.Repositories.IRepositories;
using BLL.Repositories.Repositories;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class SearchRepository : BaseRepository, ISearchRepository
    {
        private static SearchRepository instance;
        private static readonly object padlock = new object();
        public static SearchRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SearchRepository();
                    }
                    return instance;
                }
            }
        }

        private SearchRepository() : base()
        {
        }

        public async Task<APIResponse<string>> SearchPeopleAsync(string query, int page, int limit)
        {
            var requestBody = new
            {
                limit = limit,
                page = page
            };

            string url = !string.IsNullOrWhiteSpace(query)
                ? $"{NetworkUrls.Search.SearchPeople}?q={query}"
                : NetworkUrls.Search.SearchPeople;

            return await PostAsync(url, requestBody);
        }

        public async Task<APIResponse<string>> SearchForYouAsync(string query, int page, int limit)
        {
            var requestBody = new
            {
                limit = limit,
                page = page
            };

            string url = !string.IsNullOrWhiteSpace(query)
                ? $"{NetworkUrls.Search.SearchForYou}?q={query}"
                : NetworkUrls.Search.SearchForYou;

            return await PostAsync(url, requestBody);
        }

        public async Task<APIResponse<string>> SearchTrendingAsync(string query, int page, int limit)
        {
            var requestBody = new
            {
                limit = limit,
                page = page
            };

            string url = !string.IsNullOrWhiteSpace(query)
                ? $"{NetworkUrls.Search.SearchTrending}?q={query}"
                : NetworkUrls.Search.SearchTrending;

            return await PostAsync(url, requestBody);
        }

        public async Task<APIResponse<string>> SearchNewsAsync(string query, int page, int limit)
        {
            var requestBody = new
            {
                limit = limit,
                page = page
            };

            string url = !string.IsNullOrWhiteSpace(query)
                ? $"{NetworkUrls.Search.SearchNews}?q={query}"
                : NetworkUrls.Search.SearchNews;

            return await PostAsync(url, requestBody);
        }

        public async Task<APIResponse<string>> SearchPostsAsync(string query, int page, int limit)
        {
            var requestBody = new
            {
                limit = limit,
                page = page
            };

            string url = !string.IsNullOrWhiteSpace(query)
                ? $"{NetworkUrls.Search.SearchPosts}?q={query}"
                : NetworkUrls.Search.SearchPosts;

            return await PostAsync(url, requestBody);
        }
    }
}
