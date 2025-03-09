using BLL.Network;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BLL.Repositories.IRepositories
{
    public interface ISearchRepository
    {
        Task<APIResponse<string>> SearchPeopleAsync(string query, int page, int limit);
        Task<APIResponse<string>> SearchForYouAsync(string query, int page, int limit);
        Task<APIResponse<string>> SearchTrendingAsync(string query, int page, int limit);
        Task<APIResponse<string>> SearchNewsAsync(string query, int page, int limit);
        Task<APIResponse<string>> SearchPostsAsync(string query, int page, int limit);
    }
}
