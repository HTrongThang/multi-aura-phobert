using BLL.DataProviders;
using BLL.Network;
using BLL.Repositories.IRepositories;
using BLL.Repository;
using DTO;
using DTO.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SearchService
    {
        private readonly ISearchRepository _searchRepository;

        public SearchService(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public async Task<(List<UserSummary>, string)> SearchPeopleAsync(string query = "", int page = 1, int limit = 10)
        {
            var response = await _searchRepository.SearchPeopleAsync(query, page, limit);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<UserSummary>(), string.Empty);
                }
                return await UserSummary.ParseUserSummaryListAsync(successResponse.Data);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<Post>, string)> SearchForYouAsync(string query = "", int page = 1, int limit = 10)
        {
            var response = await _searchRepository.SearchForYouAsync(query, page, limit);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<Post>(), string.Empty);
                }
                var posts = await Post.ParsePostListAsync(successResponse.Data);
                return (posts, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<Post>, string)> SearchTrendingAsync(string query = "", int page = 1, int limit = 10)
        {
            var response = await _searchRepository.SearchTrendingAsync(query, page, limit);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<Post>(), string.Empty);
                }
                var posts = await Post.ParsePostListAsync(successResponse.Data);
                return (posts, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<Post>, string)> SearchNewsAsync(string query = "", int page = 1, int limit = 10)
        {
            var response = await _searchRepository.SearchNewsAsync(query, page, limit);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<Post>(), string.Empty);
                }
                var posts = await Post.ParsePostListAsync(successResponse.Data);
                return (posts, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }

        public async Task<(List<Post>, string)> SearchPostsAsync(string query = "", int page = 1, int limit = 10)
        {
            var response = await _searchRepository.SearchPostsAsync(query, page, limit);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<Post>(), string.Empty);
                }
                var posts = await Post.ParsePostListAsync(successResponse.Data);
                return (posts, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }
    }
}
