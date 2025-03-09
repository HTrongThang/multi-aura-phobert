using BLL.DataProviders;
using CustomControl.Commons;
using CustomControl.Modals;
using CustomControl.Utils;
using DTO;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class HomeForm : Form
    {
        private AppDataProvider appDataProvider;
        private RelationshipDataProvider relationshipDataProvider;
        private PostDataProvider postDataProvider;
        private bool isPanelProfileLoaded = false;
        private bool hasPostsData = false;

        public bool IsReload
        {
            get => isPanelProfileLoaded;
            set
            {
                if (isPanelProfileLoaded != value)
                {
                    isPanelProfileLoaded = value;

                    if (!isPanelProfileLoaded)
                    {
                        this.panelProfile.Dock = DockStyle.Top;
                        this.panelProfile.Visible = false;

                        this.panelPosts.Visible = true;
                    }
                    else
                    {
                        //TODO: Reload home page
                        relationshipDataProvider.FetchUserFriends();
                        relationshipDataProvider.FetchSuggestedFriends();

                        postDataProvider.FetchRecentPosts();
                    }
                }
            }
        }

        public void Reload()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(Reload));
                return;
            }

            if (!isPanelProfileLoaded)
            {
                isPanelProfileLoaded = false;
                this.panelProfile.Dock = DockStyle.Top;
                this.panelProfile.Visible = false;

                this.panelPosts.Visible = true;
            }

            // TODO: Reload home page
            relationshipDataProvider.FetchUserFriends();
            //relationshipDataProvider.FetchSuggestedFriends();

            postDataProvider.FetchRecentPosts();
        }

        private ProfileDetails profileForm = null;
        public HomeForm()
        {
            InitializeComponent();
            this.NotFoundContainer.Visible = false;
            appDataProvider = AppDataProvider.Instance;

            relationshipDataProvider = RelationshipDataProvider.Instance;
            relationshipDataProvider.FriendDataLoaded += LoadFriends;
            relationshipDataProvider.SuggestDataLoaded += LoadSuggestFriends;

            postDataProvider = PostDataProvider.Instance;
            postDataProvider.RecentPostsDataLoaded += LoadPanelRecentPosts;
            postDataProvider.OnCreatePostSuccess += PostDataProvider_OnCreatePostSuccess;

            if (!isPanelProfileLoaded)
            {
                this.panelProfile.Dock = DockStyle.Top;
                this.panelProfile.Visible = false;
            }
        }

        private void PostDataProvider_OnCreatePostSuccess(Post obj)
        {
            UpdateUI(panelPosts, () =>
            {
                var postCommon = new PostCommon
                {
                    CurrentPost = obj,
                    Dock = DockStyle.Top,
                    Margin = new Padding(0, 0, 0, 0)
                };

                panelPosts.Controls.Add(postCommon);
                hasPostsData = true;
            });
        }

        private void UpdateUI(Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action()));
            }
            else
            {
                action();
            }
        }
        private void LoadPanelRecentPosts()
        {
            UpdateUI(panelPosts, () =>
            {
                panelPosts.Controls.Clear();
                this.NotFoundContainer.Visible = false;

                if (postDataProvider.RecentPosts != null && postDataProvider.RecentPosts.Count > 0)
                {
                    foreach (var item in postDataProvider.RecentPosts)
                    {
                        var postCommon = new PostCommon
                        {
                            CurrentPost = item,
                            Dock = DockStyle.Top,
                            Margin = new Padding(0, 0, 0, 0),
                        };
                        panelPosts.Controls.Add(postCommon);
                        panelPosts.Controls.SetChildIndex(postCommon, 0);
                    }
                    hasPostsData = true;
                }
                else
                {
                    hasPostsData = false;
                    if (!isPanelProfileLoaded)
                    {
                        this.NotFoundContainer.Visible = true;
                    }
                }
            });
        }
        private bool isLoading = false;

        private async void LoadFriends()
        {
            if (isLoading)
            {
                return;
            }

            isLoading = true;

            try
            {
                if (flowLayoutPanelFriends.InvokeRequired)
                {
                    flowLayoutPanelFriends.BeginInvoke(new Action(LoadFriends));
                    return;
                }

                if (relationshipDataProvider.Friends == null || relationshipDataProvider.Friends.Count == 0)
                {
                    MessageBox.Show("No friends found.");
                    return;
                }

                flowLayoutPanelFriends.Controls.Clear();

                foreach (var friend in relationshipDataProvider.Friends)
                {
                    AvatarCommon avatarCommon = new AvatarCommon
                    {
                        Dock = DockStyle.None,
                        Cursor = Cursors.Hand,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Margin = new Padding(10, 0, 0, 0),
                        Size = new Size(50, 50),
                        MinimumSize = new Size(50, 50),
                        MaximumSize = new Size(50, 50),
                        CurrentUser = friend,
                    };
                    avatarCommon.Click += FriendAvatar_Click;

                    var image = await LoadAvatarImageAsync(friend.Avatar);
                    avatarCommon.Image = image ?? Properties.Resources.person;

                    // Chỉ gọi BeginInvoke nếu cần thiết
                    if (flowLayoutPanelFriends.InvokeRequired)
                    {
                        flowLayoutPanelFriends.BeginInvoke(new Action(() =>
                        {
                            flowLayoutPanelFriends.Controls.Add(avatarCommon);
                        }));
                    }
                    else
                    {
                        flowLayoutPanelFriends.Controls.Add(avatarCommon);
                    }
                }
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task<Image> LoadAvatarImageAsync(string avatarUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(avatarUrl))
                {
                    var image = await NetworkLoader.LoadImageFromUrlAsync(avatarUrl);
                    return image ?? Properties.Resources.person;
                }
                return Properties.Resources.person;
            }
            catch (Exception)
            {
                return Properties.Resources.person;
            }
        }


        private void LoadSuggestFriends()
        {
            if (relationshipDataProvider.SuggestedFriends == null || relationshipDataProvider.SuggestedFriends.Count == 0)
            {
                MessageBox.Show("No suggested friends found.");
                return;
            }

            if (panelSuggests.InvokeRequired)
            {
                panelSuggests.Invoke(new Action(LoadSuggestFriends));
                return;
            }

            panelSuggests.Controls.Clear();

            SuggestForYouCommon suggestForYouCommon = new SuggestForYouCommon
            {
                UserSummaries = relationshipDataProvider.SuggestedFriends,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 0),
            };

            panelSuggests.Controls.Add(suggestForYouCommon);
        }

        private async void FriendAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                var userSummaryCommon = (AvatarCommon)sender;
                string username = userSummaryCommon.CurrentUser.Username;
                if (!string.IsNullOrEmpty(username))
                {
                    var (profile, errorMessage) = await relationshipDataProvider.GetProfileAsync(username);

                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        LoadPanelProfile(profile);
                    }
                    else
                    {
                        MessageBox.Show("Can not go to this profile \nError fetching other profile: " + errorMessage);
                    }

                }
                else
                {
                    MessageBox.Show("Can not go to this profile");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong \nCan not go to this profile!");
            }
        }

        private void LoadPanelProfile(UserProfile profile)
        {
            //this.panelPosts.Visible = false;
            //if (!isPanelProfileLoaded)
            //{
            //    if(profileForm == null)
            //    {
            //        profileForm = new ProfileDetails
            //        {
            //            CurrentUserProfile = profile,
            //            Width = appDataProvider.ScreenWidth - 100,
            //            Height = appDataProvider.ScreenHeight - 100,
            //            StartPosition = FormStartPosition.CenterScreen,
            //            ShowInTaskbar = false,
            //            TopLevel = false,
            //            FormBorderStyle = FormBorderStyle.None,
            //            Dock = DockStyle.Fill,
            //        };
            //        profileForm.FormClosed += ProfileForm_FormClosed;
            //        this.panelProfile.Controls.Add(profileForm);
            //        this.panelProfile.Dock = DockStyle.Fill;
            //        this.panelProfile.Tag = profileForm;
            //        profileForm.BringToFront();
            //        profileForm.Show();
            //    }
            //    this.panelProfile.Visible = true;
            //    isPanelProfileLoaded = true;
            //}
            //else
            //{
            //    profileForm.CurrentUserProfile = profile;
            //    this.panelProfile.Visible = true;
            //    isPanelProfileLoaded = true;
            //}

            this.panelPosts.Visible = false;

            profileForm = new ProfileDetails
            {
                CurrentUserProfile = profile,
                Width = appDataProvider.ScreenWidth - 100,
                Height = appDataProvider.ScreenHeight - 100,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            profileForm.FormClosed += ProfileForm_FormClosed;
            this.panelProfile.Controls.Add(profileForm);
            this.panelProfile.Dock = DockStyle.Fill;
            this.panelProfile.Tag = profileForm;
            profileForm.BringToFront();
            profileForm.Show();

            // Hiển thị panelProfile
            this.panelProfile.Visible = true;
            isPanelProfileLoaded = true;
            this.NotFoundContainer.Visible = false;
        }

        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.panelProfile.Visible = false;
            isPanelProfileLoaded = false;
            this.panelPosts.Visible = true;

            if (hasPostsData)
            {
                this.NotFoundContainer.Visible = false;
            }
            else
            {
                this.NotFoundContainer.Visible = true;
            }
        }
    }
}
