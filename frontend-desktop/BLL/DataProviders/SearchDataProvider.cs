using BLL.Repository;
using BLL.Services;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.DataProviders
{
    public class SearchDataProvider
    {
        private static SearchDataProvider instance;
        private static readonly object padlock = new object();
        public static SearchDataProvider Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SearchDataProvider();
                    }
                    return instance;
                }
            }
        }


        private AppDataProvider appDataProvider = AppDataProvider.Instance;

        private RelationshipRepository relationshipRepository;
        private RelationshipService relationshipService;
        private SearchRepository searchRepository;
        private SearchService searchService;

        //No Query
        private List<Post> forYouNoQueryPosts = null;
        public List<Post> ForYouNoQueryPosts
        {
            get => forYouNoQueryPosts;
        }

        private List<Post> trendingsNoQuery = null;
        public List<Post> TrendingsNoQuery
        {
            get => trendingsNoQuery;
        }

        private List<Post> newsNoQuery = null;
        public List<Post> NewsNoQuery
        {
            get => newsNoQuery;
        }

        private List<UserSummary> peopleNoQuery = null;
        public List<UserSummary> PeopleNoQuery
        {
            get => peopleNoQuery;
        }

        private List<Post> postsNoQuery = null;
        public List<Post> PostsNoQuery
        {
            get => postsNoQuery;
        }

        //With Query
        private List<Post> forYouPosts = null;
        public List<Post> ForYouPosts
        {
            get => forYouPosts;
        }

        private List<Post> trendings = null;
        public List<Post> Trendings
        {
            get => trendings;
        }

        private List<Post> news = null;
        public List<Post> News
        {
            get => news;
        }

        private List<UserSummary> people = null;
        public List<UserSummary> People
        {
            get => people;
        }

        private List<Post> posts = null;
        public List<Post> Posts
        {
            get => posts;
        }

        public event Action ForYouNoQueryDataLoaded;
        public event Action TrendingNoQueryDataLoaded;
        public event Action NewsNoQueryDataLoaded;
        public event Action PeopleNoQueryDataLoaded;
        public event Action PostsNoQueryDataLoaded;

        public event Action ForYouDataLoaded;
        public event Action TrendingDataLoaded;
        public event Action NewsDataLoaded;
        public event Action PeopleDataLoaded;
        public event Action PostsDataLoaded;

        private SearchDataProvider()
        {
            relationshipRepository = RelationshipRepository.Instance;
            relationshipService = new RelationshipService(relationshipRepository);

            searchRepository = SearchRepository.Instance;
            searchService = new SearchService(searchRepository);

            appDataProvider.DataLoaded += Initialize;
        }

        public void Initialize()
        {
            relationshipRepository = RelationshipRepository.Instance;
            relationshipService = new RelationshipService(relationshipRepository);

            searchRepository = SearchRepository.Instance;
            searchService = new SearchService(searchRepository);

            Search();
        }
        public string Query { get; set; } = "";
        public void Search(string query = "", int page = 1, int limit = 10)
        {
            Query = query;
            SearchForYou(query, page, limit);
            SearchTrending(query, page, limit);
            SearchNews(query, page, limit);
            SearchPeople(query, page, limit);
            SearchPosts(query, page, limit);
        }

        public async void SearchForYou(string query = "", int page = 1, int limit = 10)
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await searchService.SearchForYouAsync(query, page, limit);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        this.forYouPosts = list;
                        ForYouDataLoaded?.Invoke();
                    }
                    else
                    {
                        this.forYouNoQueryPosts = list;
                        ForYouNoQueryDataLoaded?.Invoke();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        this.forYouPosts = null;
                        ForYouDataLoaded?.Invoke();
                    }
                    else
                    {
                        this.forYouNoQueryPosts = null;
                        ForYouNoQueryDataLoaded?.Invoke();
                    }
                }
            }
        }

        public async void SearchTrending(string query = "", int page = 1, int limit = 10)
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await searchService.SearchTrendingAsync(query, page, limit);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        this.trendings = list;
                        TrendingDataLoaded?.Invoke();
                    }
                    else
                    {
                        this.trendingsNoQuery = list;
                        TrendingNoQueryDataLoaded?.Invoke();
                    }                    
                }
                else
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        this.trendings = null;
                        TrendingDataLoaded?.Invoke();
                    }
                    else
                    {
                        this.trendingsNoQuery = null;
                        TrendingNoQueryDataLoaded?.Invoke();
                    }
                }
            }
        }

        public async void SearchNews(string query = "", int page = 1, int limit = 10)
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await searchService.SearchNewsAsync(query, page, limit);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        this.news = list;
                        NewsDataLoaded?.Invoke();
                    }
                    else
                    {
                        this.newsNoQuery = list;
                        NewsNoQueryDataLoaded?.Invoke();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        this.news = null;
                        NewsDataLoaded?.Invoke();
                    }
                    else
                    {
                        this.newsNoQuery = null;
                        NewsNoQueryDataLoaded?.Invoke();
                    }
                }
            }
        }

        public async void SearchPeople(string query = "", int page = 1, int limit = 10)
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await searchService.SearchPeopleAsync(query, page, limit);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        this.people = list;
                        PeopleDataLoaded?.Invoke();
                    }
                    else
                    {
                        this.peopleNoQuery = list;
                        PeopleNoQueryDataLoaded?.Invoke();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        this.people = null;
                        PeopleDataLoaded?.Invoke();
                    }
                    else
                    {
                        this.peopleNoQuery = null;
                        PeopleNoQueryDataLoaded?.Invoke();
                    }
                }
            }
        }

        public async Task<(List<UserSummary>, string)> SearchSuggestedPeople( int page = 1, int limit = 10)
        {
            try
            {
                if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
                {
                    return await searchService.SearchPeopleAsync("", page, limit);
                }
            }
            catch (Exception ex) {
                return (null, "Have a problem: " + ex.Message);
            }
            return (null, "Unknown error");
        }

        public async void SearchPosts(string query = "", int page = 1, int limit = 10)
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await searchService.SearchPostsAsync(query, page, limit);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        this.posts = list;
                        PostsDataLoaded?.Invoke();
                    }
                    else
                    {
                        this.postsNoQuery = list;
                        PostsNoQueryDataLoaded?.Invoke();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        this.posts = null;
                        PostsDataLoaded?.Invoke();
                    }
                    else
                    {
                        this.postsNoQuery = null;
                        PostsNoQueryDataLoaded?.Invoke();
                    }
                }
            }
        }
    }
}
