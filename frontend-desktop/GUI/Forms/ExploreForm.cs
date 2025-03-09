using BLL.DataProviders;
using CustomControl.Commons;
using CustomControl.Modals;
using DTO;
using GUI.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class ExploreForm : Form
    {
        private Label currentTaskBar;
        private Panel currentPanelResults;
        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        private RelationshipDataProvider relationshipDataProvider;
        private SearchDataProvider searchDataProvider;

        private bool hasForYouNoQueryData = false;
        private bool hasTrendingNoQueryData = false;
        private bool hasNewsNoQueryData = false;
        private bool hasPeopleNoQueryData = false;
        private bool hasPostsNoQueryData = false;

        private bool hasForYouWithQueryData = false;
        private bool hasTrendingWithQueryData = false;
        private bool hasNewsWithQueryData = false;
        private bool hasPeopleWithQueryData = false;
        private bool hasPostsWithQueryData = false;

        public SearchBarCommon SearchBar()
        {
            return this.searchBarCommon;
        }

        public void Reload()
        {
            ResetData();
            ShowLoading();
            searchDataProvider.Search();
        }

        public ExploreForm()
        {
            InitializeComponent();
            relationshipDataProvider = RelationshipDataProvider.Instance;
            relationshipDataProvider.SuggestDataLoaded += LoadSuggestFriends;

            searchDataProvider = SearchDataProvider.Instance;
            searchDataProvider.ForYouNoQueryDataLoaded += LoadForYouNoQueryPosts;
            searchDataProvider.TrendingNoQueryDataLoaded += LoadTrendingNoQueryPosts;
            searchDataProvider.NewsNoQueryDataLoaded += LoadNewsNoQueryPosts;
            searchDataProvider.PeopleNoQueryDataLoaded += LoadPeopleNoQueryPosts;
            searchDataProvider.PostsNoQueryDataLoaded += LoadPostsNoQuery;

            searchDataProvider.ForYouDataLoaded += LoadForYouWithQueryPosts;
            searchDataProvider.TrendingDataLoaded += LoadTrendingWithQueryPosts;
            searchDataProvider.NewsDataLoaded += LoadNewsWithQueryPosts;
            searchDataProvider.PeopleDataLoaded += LoadPeopleWithQueryPosts;
            searchDataProvider.PostsDataLoaded += LoadPostsWithQuery;

            SetUpNavigations();

            this.searchBarCommon.OnEnter += (sender, args) =>
            {
                OnSearchEnter(sender, args);
            };
        }
        private void SetUpNavigations()
        {
            this.labelForYou.Click += LabelForYou_Click;
            this.labelTrending.Click += LabelTrending_Click;
            this.labelNews.Click += LabelNews_Click;
            this.labelPeople.Click += LabelPeople_Click;
            this.labelPosts.Click += LabelPosts_Click;
            this.Load += (sender, e) => LabelForYou_Click(this.labelForYou, e);

            this.panelForYouNoQueryPosts.Visible = true;
            this.currentPanelResults = this.panelForYouNoQueryPosts;
            this.panelForYouPosts.Visible = false;

            this.panelTrendingNoQueryPosts.Visible = false;
            this.panelTrendingPostsWithQuery.Visible = false;

            this.panelNewsNoQueryPosts.Visible = false;
            this.panelNewsPostsWithQuery.Visible = false;

            this.panelPeopleNoQuery.Visible = false;
            this.panelPeopleWithQuery.Visible = false;

            this.panelPostsNoQuery.Visible = false;
            this.panelPostsWithQuery.Visible = false;
        }

        private void ResetData()
        {
            ClearPanel(panelForYouNoQueryPosts);
            //this.panelForYouNoQueryPosts.Visible = false;
            hasForYouNoQueryData = false;

            ClearPanel(panelForYouPosts);
            //this.panelForYouPosts.Visible = false;
            hasForYouWithQueryData = false;

            ClearPanel(panelTrendingNoQueryPosts);
            //this.panelTrendingNoQueryPosts.Visible = false;
            hasTrendingNoQueryData = false;

            ClearPanel(panelTrendingPostsWithQuery);
            //this.panelTrendingPostsWithQuery.Visible = false;
            hasTrendingWithQueryData = false;

            ClearPanel(panelNewsNoQueryPosts);
            //this.panelNewsNoQueryPosts.Visible = false;
            hasNewsNoQueryData = false;

            ClearPanel(panelNewsPostsWithQuery);
            //this.panelNewsPostsWithQuery.Visible = false;
            hasNewsWithQueryData = false;

            ClearPanel(panelPeopleNoQuery);
            //this.panelPeopleNoQuery.Visible = false;
            hasPeopleNoQueryData = false;

            ClearPanel(panelPeopleWithQuery);
            //this.panelPeopleWithQuery.Visible = false;
            hasPeopleWithQueryData = false;

            ClearPanel(panelPostsNoQuery);
            //this.panelPostsNoQuery.Visible = false;
            hasPostsNoQueryData = false;

            ClearPanel(panelPostsWithQuery);
            //this.panelPostsWithQuery.Visible = false;
            hasPostsWithQueryData = false;

            //ResetPanelResults();
        }

        private void OnSearchEnter(object sender, EventArgs e)
        {
            string query = this.searchBarCommon.Query;
            if (query != null)
            {
                ShowLoading();
                searchDataProvider.Search(query, 1, 10);                
                //ResetPanelResults();
            }
        }

        private void ShowLoading()
        {
            this.NotFoundContainer.Visible = false;
            this.currentPanelResults.Visible = false;
            this.LoadingContainer.Visible = true;
        }

        private void HideLoading()
        {
            this.currentPanelResults.Visible = true;
            this.LoadingContainer.Visible = false;
        }

        private void ResetPanelResults()
        {
            if (currentTaskBar == labelTrending)
            {
                LabelTrending_Click(this.labelTrending, EventArgs.Empty);
            }
            else if (currentTaskBar == labelNews)
            {
                LabelNews_Click(this.labelNews, EventArgs.Empty);
            }
            else if (currentTaskBar == labelPeople)
            {
                LabelPeople_Click(this.labelPeople, EventArgs.Empty);
            }
            else if (currentTaskBar == labelPosts)
            {
                LabelPosts_Click(this.labelPosts, EventArgs.Empty);
            }
            else 
            {
                LabelForYou_Click(this.labelForYou, EventArgs.Empty);
            }
        }

        private void LabelPosts_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBarCommon.Query))
            {
                //TODO: load data with searching
                LoadPanel(sender, this.panelPostsWithQuery, hasPostsWithQueryData);
            }
            else
            {
                LoadPanel(sender, this.panelPostsNoQuery, hasPostsNoQueryData);
            }
        }

        private void LabelPeople_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBarCommon.Query))
            {
                //TODO: load data with searching
                LoadPanel(sender, this.panelPeopleWithQuery, hasPeopleWithQueryData);
            }
            else
            {
                LoadPanel(sender, this.panelPeopleNoQuery, hasPeopleNoQueryData);
            }
        }

        private void LabelNews_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBarCommon.Query))
            {
                //TODO: load data with searching
                LoadPanel(sender, this.panelNewsPostsWithQuery, hasNewsWithQueryData);
            }
            else
            {
                LoadPanel(sender, this.panelNewsNoQueryPosts, hasNewsNoQueryData);
            }
        }

        private void LabelTrending_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBarCommon.Query))
            {
                //TODO: load data with searching
                LoadPanel(sender, this.panelTrendingPostsWithQuery, hasTrendingWithQueryData);
            }
            else
            {
                LoadPanel(sender, this.panelTrendingNoQueryPosts, hasTrendingNoQueryData);
            }
        }

        private void LabelForYou_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBarCommon.Query))
            {
                //TODO: load data with searching
                LoadPanel(sender, this.panelForYouPosts, hasForYouWithQueryData);
            }
            else
            {
                LoadPanel(sender, this.panelForYouNoQueryPosts, hasForYouNoQueryData);
            }
        }

        private void LoadPanel(object btnSender, object panelSender, bool hasData)
        {
            this.LoadingContainer.Visible = false;
            if (hasData)
            {
                this.NotFoundContainer.Visible = false;
            }
            else
            {
                this.NotFoundContainer.Visible = true;
            }
            ActivateButton(btnSender);
            ActivatePanel(panelSender);
        }

        private void ClearPanel(Panel sender)
        {
            if (sender.InvokeRequired)
            {
                sender.Invoke(new Action(() =>
                {
                    sender.Controls.Clear();
                }));
            }
            else
            {
                sender.Controls.Clear();
            }
        }

        private void LoadSuggestFriends()
        {
            if (relationshipDataProvider.SuggestedFriends == null)
            {
                return;
            }

            if (panelSuggests.InvokeRequired)
            {
                panelSuggests.Invoke(new Action(LoadSuggestFriends));
                return;
            }

            ClearPanel(panelSuggests);

            SuggestForYouCommon suggestForYouCommon = new SuggestForYouCommon
            {
                UserSummaries = relationshipDataProvider.SuggestedFriends,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 0),
            };

            
            if (panelSuggests.InvokeRequired)
            {
                panelSuggests.Invoke(new Action(() =>
                {
                    panelSuggests.Controls.Add(suggestForYouCommon);
                }));
            }
            else
            {
                panelSuggests.Controls.Add(suggestForYouCommon);
            }
        }

        private void LoadForYouNoQueryPosts()
        {
            if (panelForYouNoQueryPosts.InvokeRequired)
            {
                panelForYouNoQueryPosts.Invoke(new Action(LoadForYouNoQueryPosts));
                return;
            }


            //if (panelForYouNoQueryPosts.InvokeRequired)
            //{
            //    panelForYouNoQueryPosts.Invoke(new Action(() =>
            //    {
            //        panelForYouNoQueryPosts.Controls.Clear();
            //    }));
            //}
            //else
            //{
            //    panelForYouNoQueryPosts.Controls.Clear();
            //}

            ClearPanel(panelForYouNoQueryPosts);
            hasForYouNoQueryData = false;
            if (searchDataProvider.ForYouNoQueryPosts != null)
            {
                foreach (var item in searchDataProvider.ForYouNoQueryPosts)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };                    

                    if (panelForYouNoQueryPosts.InvokeRequired)
                    {
                        panelForYouNoQueryPosts.Invoke(new Action(() =>
                        {
                            panelForYouNoQueryPosts.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelForYouNoQueryPosts.Controls.Add(postCommon);
                    }
                    if (!hasForYouNoQueryData)
                    {
                        hasForYouNoQueryData = true;
                    }
                }
            }
            else
            {
                hasForYouNoQueryData = false;
            }

            if (currentTaskBar == labelForYou)
            {
                HideLoading();
                LabelForYou_Click(this.labelForYou, EventArgs.Empty);
            }
        }

        private void LoadTrendingNoQueryPosts()
        {
            if (panelTrendingNoQueryPosts.InvokeRequired)
            {
                panelTrendingNoQueryPosts.Invoke(new Action(LoadTrendingNoQueryPosts));
                return;
            }

            
            //if (panelTrendingNoQueryPosts.InvokeRequired)
            //{
            //    panelTrendingNoQueryPosts.Invoke(new Action(() =>
            //    {
            //        panelTrendingNoQueryPosts.Controls.Clear();
            //    }));
            //}
            //else
            //{
            //    panelTrendingNoQueryPosts.Controls.Clear();
            //}

            ClearPanel(panelTrendingNoQueryPosts);
            hasTrendingNoQueryData = false;
            if (searchDataProvider.TrendingsNoQuery != null)
            {
                foreach (var item in searchDataProvider.TrendingsNoQuery)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelTrendingNoQueryPosts.InvokeRequired)
                    {
                        panelTrendingNoQueryPosts.Invoke(new Action(() =>
                        {
                            panelTrendingNoQueryPosts.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelTrendingNoQueryPosts.Controls.Add(postCommon);
                    }
                    if (!hasTrendingNoQueryData)
                    {
                        hasTrendingNoQueryData = true;
                    }
                }
            }
            else
            {
                hasTrendingNoQueryData = false;
            }

            if (currentTaskBar == labelTrending)
            {
                HideLoading();
                LabelTrending_Click(this.labelTrending, EventArgs.Empty);
            }
        }

        private void LoadNewsNoQueryPosts()
        {
            if (panelNewsNoQueryPosts.InvokeRequired)
            {
                panelNewsNoQueryPosts.Invoke(new Action(LoadNewsNoQueryPosts));
                return;
            }


            //if (panelNewsNoQueryPosts.InvokeRequired)
            //{
            //    panelNewsNoQueryPosts.Invoke(new Action(() =>
            //    {
            //        panelNewsNoQueryPosts.Controls.Clear();
            //    }));
            //}
            //else
            //{
            //    panelNewsNoQueryPosts.Controls.Clear();
            //}
            ClearPanel(panelNewsNoQueryPosts);
            hasNewsNoQueryData = false;
            if (searchDataProvider.NewsNoQuery != null)
            {
                foreach (var item in searchDataProvider.NewsNoQuery)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelNewsNoQueryPosts.InvokeRequired)
                    {
                        panelNewsNoQueryPosts.Invoke(new Action(() =>
                        {
                            panelNewsNoQueryPosts.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelNewsNoQueryPosts.Controls.Add(postCommon);
                    }
                    if (!hasNewsNoQueryData)
                    {
                        hasNewsNoQueryData = true;
                    }
                }
            }
            else
            {
                hasNewsNoQueryData = false;
            }

            if (currentTaskBar == labelNews)
            {
                HideLoading();
                LabelNews_Click(this.labelNews, EventArgs.Empty);
            }
        }

        private void LoadPeopleNoQueryPosts()
        {
            if (panelPeopleNoQuery.InvokeRequired)
            {
                panelPeopleNoQuery.Invoke(new Action(LoadPeopleNoQueryPosts));
                return;
            }


            //if (panelPeopleNoQuery.InvokeRequired)
            //{
            //    panelPeopleNoQuery.Invoke(new Action(() =>
            //    {
            //        panelPeopleNoQuery.Controls.Clear();
            //    }));
            //}
            //else
            //{
            //    panelPeopleNoQuery.Controls.Clear();
            //}

            ClearPanel(panelPeopleNoQuery);
            hasPeopleNoQueryData = false;
            if (searchDataProvider.PeopleNoQuery != null)
            {
                foreach (var item in searchDataProvider.PeopleNoQuery)
                {
                    UserSummaryCommon userSummary = new UserSummaryCommon
                    {
                        CurrentUserSummary = item,
                        IsFollowing = false,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(10, 4, 10, 4),
                    };

                    if (panelPeopleNoQuery.InvokeRequired)
                    {
                        panelPeopleNoQuery.Invoke(new Action(() =>
                        {
                            panelPeopleNoQuery.Controls.Add(userSummary);
                        }));
                    }
                    else
                    {
                        panelPeopleNoQuery.Controls.Add(userSummary);
                    }
                    if (!hasPeopleNoQueryData)
                    {
                        hasPeopleNoQueryData = true;
                    }
                }
            }
            else
            {
                hasPeopleNoQueryData = false;
            }

            if (currentTaskBar == labelPeople)
            {
                HideLoading();
                LabelPeople_Click(this.labelPeople, EventArgs.Empty);
            }
        }

        private void LoadPostsNoQuery()
        {
            if (panelPostsNoQuery.InvokeRequired)
            {
                panelPostsNoQuery.Invoke(new Action(LoadPostsNoQuery));
                return;
            }

            //if (panelPostsNoQuery.InvokeRequired)
            //{
            //    panelPostsNoQuery.Invoke(new Action(() =>
            //    {
            //        panelPostsNoQuery.Controls.Clear();
            //    }));
            //}
            //else
            //{
            //    panelPostsNoQuery.Controls.Clear();
            //}

            ClearPanel(panelPostsNoQuery);
            hasPostsNoQueryData = false;
            if (searchDataProvider.PostsNoQuery != null)
            {
                foreach (var item in searchDataProvider.PostsNoQuery)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelPostsNoQuery.InvokeRequired)
                    {
                        panelPostsNoQuery.Invoke(new Action(() =>
                        {
                            panelPostsNoQuery.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelPostsNoQuery.Controls.Add(postCommon);
                    }
                    if (!hasPostsNoQueryData)
                    {
                        hasPostsNoQueryData = true;
                    }
                }
            }
            else
            {
                hasPostsNoQueryData = false;
            }

            if (currentTaskBar == labelPosts)
            {
                HideLoading();
                LabelPosts_Click(this.labelPosts, EventArgs.Empty);
            }
        }

        //With Query
        private void LoadForYouWithQueryPosts()
        {
            if (panelForYouPosts.InvokeRequired)
            {
                panelForYouPosts.Invoke(new Action(LoadForYouWithQueryPosts));
                return;
            }

            //if (panelForYouPosts.InvokeRequired)
            //{
            //    panelForYouPosts.Invoke(new Action(() =>
            //    {
            //        panelForYouPosts.Controls.Clear();
            //    }));
            //}
            //else
            //{
            //    panelForYouPosts.Controls.Clear();
            //}

            ClearPanel(panelForYouPosts);
            hasForYouWithQueryData = false;
            if (searchDataProvider.ForYouPosts != null)
            {
                foreach (var item in searchDataProvider.ForYouPosts)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelForYouPosts.InvokeRequired)
                    {
                        panelForYouPosts.Invoke(new Action(() =>
                        {
                            panelForYouPosts.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelForYouPosts.Controls.Add(postCommon);
                    }
                    if (!hasForYouWithQueryData)
                    {
                        hasForYouWithQueryData = true;
                    }
                }
            }
            else
            {
                hasForYouWithQueryData = false;
            }

            if (currentTaskBar == labelForYou)
            {
                HideLoading();
                LabelForYou_Click(this.labelForYou, EventArgs.Empty);
            }
        }

        private void LoadTrendingWithQueryPosts()
        {
            if (panelTrendingPostsWithQuery.InvokeRequired)
            {
                panelTrendingPostsWithQuery.Invoke(new Action(LoadTrendingWithQueryPosts));
                return;
            }

            
            //if (panelTrendingPostsWithQuery.InvokeRequired)
            //{
            //    panelTrendingPostsWithQuery.Invoke(new Action(() =>
            //    {
            //        panelTrendingPostsWithQuery.Controls.Clear();
            //    }));
            //}
            //else
            //{
            //    panelTrendingPostsWithQuery.Controls.Clear();
            //}

            ClearPanel(panelTrendingPostsWithQuery);
            hasTrendingWithQueryData = false;
            if (searchDataProvider.Trendings != null)
            {
                foreach (var item in searchDataProvider.Trendings)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelTrendingPostsWithQuery.InvokeRequired)
                    {
                        panelTrendingPostsWithQuery.Invoke(new Action(() =>
                        {
                            panelTrendingPostsWithQuery.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelTrendingPostsWithQuery.Controls.Add(postCommon);
                    }
                    if (!hasTrendingWithQueryData)
                    {
                        hasTrendingWithQueryData = true;
                    }
                }
            }
            else
            {
                hasTrendingWithQueryData = false;
            }

            if (currentTaskBar == labelTrending)
            {
                HideLoading();
                LabelTrending_Click(this.labelTrending, EventArgs.Empty);
            }
        }

        private void LoadNewsWithQueryPosts()
        {
            if (panelNewsPostsWithQuery.InvokeRequired)
            {
                panelNewsPostsWithQuery.Invoke(new Action(LoadNewsWithQueryPosts));
                return;
            }

            
            //if (panelNewsPostsWithQuery.InvokeRequired)
            //{
            //    panelNewsPostsWithQuery.Invoke(new Action(() =>
            //    {
            //        panelNewsPostsWithQuery.Controls.Clear();
            //    }));
            //}
            //else
            //{
            //    panelNewsPostsWithQuery.Controls.Clear();
            //}

            ClearPanel(panelNewsPostsWithQuery);
            hasNewsWithQueryData = false;
            if (searchDataProvider.News != null)
            {
                foreach (var item in searchDataProvider.News)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelNewsPostsWithQuery.InvokeRequired)
                    {
                        panelNewsPostsWithQuery.Invoke(new Action(() =>
                        {
                            panelNewsPostsWithQuery.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelNewsPostsWithQuery.Controls.Add(postCommon);
                    }
                    if (!hasNewsWithQueryData)
                    {
                        hasNewsWithQueryData = true;
                    }
                }
            }
            else
            {
                hasNewsWithQueryData = false;
            }

            if (currentTaskBar == labelNews)
            {
                HideLoading();
                LabelNews_Click(this.labelNews, EventArgs.Empty);
            }
        }

        private void LoadPeopleWithQueryPosts()
        {
            if (panelPeopleWithQuery.InvokeRequired)
            {
                panelPeopleWithQuery.Invoke(new Action(LoadPeopleWithQueryPosts));
                return;
            }

            
            //if (panelPeopleWithQuery.InvokeRequired)
            //{
            //    panelPeopleWithQuery.Invoke(new Action(() =>
            //    {
            //        panelPeopleWithQuery.Controls.Clear();
            //    }));
            //}
            //else
            //{
            //    panelPeopleWithQuery.Controls.Clear();
            //}

            ClearPanel(panelPeopleWithQuery);
            hasPeopleWithQueryData = false;
            if (searchDataProvider.People != null)
            {
                foreach (var item in searchDataProvider.People)
                {
                    bool isFollowing = false;
                    if (relationshipDataProvider.Followings != null && relationshipDataProvider.Followings.Exists(user => user.Username == appDataProvider.User.Username))
                    {
                        isFollowing = true;
                    }

                    UserSummaryCommon userSummary = new UserSummaryCommon
                    {
                        CurrentUserSummary = item,
                        IsFollowing = isFollowing,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(10, 4, 10, 4),
                    };

                    if (panelPeopleWithQuery.InvokeRequired)
                    {
                        panelPeopleWithQuery.Invoke(new Action(() =>
                        {
                            panelPeopleWithQuery.Controls.Add(userSummary);
                        }));
                    }
                    else
                    {
                        panelPeopleWithQuery.Controls.Add(userSummary);
                    }
                    if (!hasPeopleWithQueryData)
                    {
                        hasPeopleWithQueryData = true;
                    }
                }
            }
            else
            {
                hasPeopleWithQueryData = false;
            }

            if (currentTaskBar == labelPeople)
            {
                HideLoading();
                LabelPeople_Click(this.labelPeople, EventArgs.Empty);
            }
        }

        private void LoadPostsWithQuery()
        {
            if (panelPostsWithQuery.InvokeRequired)
            {
                panelPostsWithQuery.Invoke(new Action(LoadPostsWithQuery));
                return;
            }

            //if (panelPostsWithQuery.InvokeRequired)
            //{
            //    panelPostsWithQuery.Invoke(new Action(() =>
            //    {
            //        panelPostsWithQuery.Controls.Clear();
            //    }));
            //}
            //else
            //{
            //    panelPostsWithQuery.Controls.Clear();
            //}

            ClearPanel(panelPostsWithQuery);
            hasPostsWithQueryData = false;
            if (searchDataProvider.Posts!= null)
            {
                foreach (var item in searchDataProvider.Posts)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelPostsWithQuery.InvokeRequired)
                    {
                        panelPostsWithQuery.Invoke(new Action(() =>
                        {
                            panelPostsWithQuery.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelPostsWithQuery.Controls.Add(postCommon);
                    }
                    if (!hasPostsWithQueryData)
                    {
                        hasPostsWithQueryData = true;
                    }
                }
            }
            else
            {
                hasPostsWithQueryData = false;
            }

            if (currentTaskBar == labelPosts)
            {
                HideLoading();
                LabelPosts_Click(this.labelPosts, EventArgs.Empty);
            }
        }

        private void ActivatePanel(object sender)
        {
            if (sender != null)
            {
                if (currentPanelResults != (Panel)sender)
                {
                    currentPanelResults.Visible = false;
                    currentPanelResults = (Panel)sender;
                    currentPanelResults.Visible = true;
                }
            }
        }

        private void ActivateButton(object sender)
        {
            if (sender != null)
            {
                if (currentTaskBar != (Label)sender)
                {
                    DisableButton();
                    currentTaskBar = (Label)sender;
                    currentTaskBar.ForeColor = Color.White;
                    currentTaskBar.Font = new Font(currentTaskBar.Font, FontStyle.Bold);
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousTaskBar in tableLayoutPanelSearchTaskBar.Controls)
            {
                if (previousTaskBar.GetType() == typeof(Label))
                {
                    previousTaskBar.ForeColor = Color.FromArgb(222, 222, 222);
                    previousTaskBar.Font = new Font(previousTaskBar.Font, FontStyle.Regular);
                }
            }
        }
    }
}
