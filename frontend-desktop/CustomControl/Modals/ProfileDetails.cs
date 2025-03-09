using BLL.DataProviders;
using CustomControl.Commons;
using CustomControl.Extensions;
using CustomControl.Properties;
using CustomControl.Utils;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Modals
{
    public partial class ProfileDetails : Form
    {
        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        private PostDataProvider postDataProvider;
        private RelationshipDataProvider relationshipDataProvider;

        private List<Post> currentUserPosts;

        private UserProfile currentUserProfileBlocked;
        private UserProfile currentUserProfile;
        private bool isBlocking;
        public UserProfile CurrentUserProfile
        {
            get => currentUserProfile;
            set
            {
                currentUserProfile = value;
                
                LoadUserPosts();
                LoadProfile();
                LoadFollowerCounter();
                LoadFollowingCounter();
                OnFriendDataLoaded();

                this.buttonFollow.Text = GetRelationshipText();
                if (currentUserProfile != null && currentUserProfile.RelaStatus != null) {
                    isBlocking = currentUserProfile.RelaStatus.Status == RelationshipStatusType.Blocking;
                    if (isBlocking)
                    {
                        this.buttonBlock.Image = Resources.unlock;
                        this.buttonFollow.Enabled = false;
                    }
                    else
                    {
                        this.buttonBlock.Image = Resources.block;
                        this.buttonFollow.Enabled = true;
                    }
                    //this.buttonBlock.Image = isBlocking ? Resources.unlock : Resources.block;
                }
            }
        }

        private Label currentTaskBar;
        private Panel currentPanelResults;

        private bool hasPostsData = false;
        private bool hasMediasData = false;
        private bool hasFriendsData = false;
        private bool hasMoreData = true;

        public ProfileDetails()
        {
            InitializeComponent();
            this.CloseWindowControlButton.Click += CloseWindowControlButton_Click;

            postDataProvider = PostDataProvider.Instance;
            relationshipDataProvider = RelationshipDataProvider.Instance;

            RegisterHoverAndClickEventsForLabels();

            currentPanelResults = panelPosts;
            LoadPanel(currentPanelResults, hasPostsData);

            this.buttonFollow.Text = GetRelationshipText();
            this.buttonFollow.Click += ButtonFollow_Click;

            this.buttonBlock.Click += ButtonBlock_Click;

            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void ButtonBlock_Click(object sender, EventArgs e)
        {
            this.buttonBlock.Image = Resources.loading24;
            this.buttonBlock.Enabled = false;
            this.buttonFollow.Text = "Processing..";
            this.buttonFollow.Enabled = false;

            Task.Run(async () =>
            {
                try
                {
                    if (isBlocking)
                    {
                        if (currentUserProfileBlocked != null && currentUserProfileBlocked.User != null && !string.IsNullOrEmpty(currentUserProfileBlocked.User.UserID))
                        {
                            var (result, newRelationshipStatus) = await relationshipDataProvider.Unblock(UserSummary.CopyFrom(currentUserProfileBlocked.User), currentUserProfileBlocked.RelaStatus);
                            currentUserProfileBlocked.RelaStatus = newRelationshipStatus;
                            this.Invoke(new Action(() =>
                            {
                                if(currentUserProfileBlocked.RelaStatus != null)
                                {
                                    isBlocking = currentUserProfileBlocked.RelaStatus.Status == RelationshipStatusType.Blocking;
                                    if (isBlocking)
                                    {
                                        this.buttonBlock.Image = Resources.unlock;
                                        this.buttonBlock.Enabled = true;
                                        this.buttonFollow.Enabled = false;
                                    }
                                    else
                                    {
                                        CurrentUserProfile = this.currentUserProfileBlocked;
                                        this.buttonBlock.Image = Resources.block;
                                        this.buttonBlock.Enabled = true;
                                        this.buttonFollow.Enabled = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Something went wrong! Please try again after 15mins");
                                }
                                
                                this.buttonFollow.Text = GetRelationshipText();
                            }));
                        }
                        else
                        {
                            this.buttonFollow.Text = GetRelationshipText();
                            this.buttonBlock.Enabled = true;
                            this.buttonFollow.Enabled = true;
                        }
                    }
                    else
                    {
                        if (currentUserProfile != null && currentUserProfile.User != null && !string.IsNullOrEmpty(currentUserProfile.User.UserID))
                        {
                            this.currentUserProfileBlocked = currentUserProfile;
                            var (result, newRelationshipStatus) = await relationshipDataProvider.Block(UserSummary.CopyFrom(CurrentUserProfile.User), CurrentUserProfile.RelaStatus);
                            currentUserProfile.RelaStatus = newRelationshipStatus;
                            isBlocking = result;
                            this.Invoke(new Action(() =>
                            {
                                if (isBlocking)
                                {
                                    this.buttonBlock.Image = Resources.unlock;
                                    this.buttonBlock.Enabled = true;
                                    this.buttonFollow.Enabled = false;

                                    CurrentUserProfile = null;
                                }
                                else
                                {
                                    this.buttonBlock.Image = Resources.block;
                                    this.buttonBlock.Enabled = true;
                                    this.buttonFollow.Enabled = true;
                                }
                                this.buttonFollow.Text = GetRelationshipText();
                            }));
                        }
                        else
                        {
                            this.buttonFollow.Text = GetRelationshipText();
                            this.buttonBlock.Enabled = true;
                            this.buttonFollow.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Operation failed: {ex.Message}");
                        this.buttonFollow.Text = GetRelationshipText();
                        this.buttonBlock.Enabled = true;
                        this.buttonFollow.Enabled = true;
                    }));
                }
            });

        }

        private void ButtonFollow_Click(object sender, EventArgs e)
        {
            if (currentUserProfile != null && currentUserProfile.User != null && !string.IsNullOrEmpty(currentUserProfile.User.UserID))
            {
                this.buttonFollow.Text = "Processing..";

                Task.Run(async () =>
                {
                    try
                    {
                        if (currentUserProfile.RelaStatus.Status == RelationshipStatusType.Following
                            || currentUserProfile.RelaStatus.Status == RelationshipStatusType.Friend
                        )
                        {
                            var (result, newRelationshipStatus) = await relationshipDataProvider.Unfollow(UserSummary.CopyFrom(CurrentUserProfile.User), CurrentUserProfile.RelaStatus);
                            currentUserProfile.RelaStatus = newRelationshipStatus;
                            this.Invoke(new Action(() =>
                            {
                                this.buttonFollow.Text = GetRelationshipText();
                                if (currentUserProfile != null && currentUserProfile.RelaStatus != null)
                                {
                                    if(currentUserProfile.RelaStatus.Status == RelationshipStatusType.Follower)
                                    {
                                        if (this.currentUserProfile.Friends != null)
                                        {
                                            this.currentUserProfile.Friends.RemoveAll(f => f.UserID == appDataProvider.User.UserID);
                                            OnFriendDataLoaded();
                                        }
                                    }

                                    if(this.currentUserProfile.Followers != null)
                                    {
                                        this.currentUserProfile.Followers.RemoveAll(f => f.UserID == appDataProvider.User.UserID);
                                        LoadFollowerCounter();
                                    }

                                }
                            }));
                        }
                        else
                        {
                            var (result, newRelationshipStatus) = await relationshipDataProvider.Follow(UserSummary.CopyFrom(CurrentUserProfile.User), CurrentUserProfile.RelaStatus);
                            currentUserProfile.RelaStatus = newRelationshipStatus;
                            this.Invoke(new Action(() =>
                            {
                                this.buttonFollow.Text = GetRelationshipText();

                                if (currentUserProfile != null && currentUserProfile.RelaStatus != null)
                                {
                                    if (currentUserProfile.RelaStatus.Status == RelationshipStatusType.Friend)
                                    {
                                        if (this.currentUserProfile.Friends == null)
                                        {
                                            this.currentUserProfile.Friends = new List<UserSummary>();
                                        }

                                        this.currentUserProfile.Friends.Add(UserSummary.CopyFrom(appDataProvider.User));
                                        OnFriendDataLoaded();
                                    }

                                    if (this.currentUserProfile.Followers == null)
                                    {
                                        this.currentUserProfile.Friends = new List<UserSummary>();
                                    }
                                    this.currentUserProfile.Followers.Add(UserSummary.CopyFrom(appDataProvider.User));
                                    LoadFollowerCounter();
                                }
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show($"Operation failed: {ex.Message}");
                            this.buttonFollow.Text = GetRelationshipText();
                        }));
                    }
                });

            }
        }

        private string GetRelationshipText()
        {
            if (currentUserProfile != null && currentUserProfile.RelaStatus != null)
            {
                return currentUserProfile.RelaStatus.GetRelationshipStatusText();
            }

            return "Follow";
        }

        private async void LoadUserPosts()
        {
            if(currentUserProfile != null && currentUserProfile.User != null && !string.IsNullOrEmpty(currentUserProfile.User.UserID))
            {
                currentUserPosts = await postDataProvider.FetchOtherUserPosts(currentUserProfile.User.UserID);
                LoadPanelUserPosts();
            }
            else
            {
                this.panelPosts.Controls.Clear();
                hasPostsData = false;

                this.panelMedias.Controls.Clear();
                this.hasMediasData = false;
            }
        }

        private void LoadPanelUserPosts()
        {
            if (panelPosts.InvokeRequired)
            {
                panelPosts.Invoke(new Action(LoadUserPosts));
                return;
            }

            if (currentUserPosts != null)
            {
                hasPostsData = false;
                this.labelPostCounter.Text = currentUserPosts.Count.ToShortNumber() + " Posts";
                foreach (var item in currentUserPosts)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelPosts.InvokeRequired)
                    {
                        panelPosts.Invoke(new Action(() =>
                        {
                            panelPosts.Controls.Add(postCommon);
                            panelPosts.Controls.SetChildIndex(postCommon, 0);
                        }));
                    }
                    else
                    {
                        panelPosts.Controls.Add(postCommon);
                        panelPosts.Controls.SetChildIndex(postCommon, 0);
                    }
                    if (!hasPostsData)
                    {
                        hasPostsData = true;
                    }

                    if (item.Images != null && item.Images.Count != 0)
                    {
                        AddMediasDataItem(item);
                    }
                }

            }
            else
            {
                hasPostsData = false;
            }
            
            if (currentTaskBar == labelPosts)
            {
                HideLoading();
                LoadPanel(this.panelPosts, hasPostsData);
            }
        }

        private void AddMediasDataItem(Post post)
        {
            if (panelMedias.InvokeRequired)
            {
                panelMedias.Invoke(new Action(LoadPanelFriends));
                return;
            }

            BriefPost briefPost = new BriefPost
            {
                CurrentPost = post,
            };

            if (panelMedias.InvokeRequired)
            {
                panelMedias.Invoke(new Action(() =>
                {
                    panelMedias.Controls.Add(briefPost);
                }));
            }
            else
            {
                panelMedias.Controls.Add(briefPost);
            }


            if (!hasMediasData)
            {
                hasMediasData = true;
            }

            if (currentTaskBar == labelMedias)
            {
                HideLoading();
                LoadPanel(this.panelMedias, hasMediasData);
            }
        }

        private void LoadPanelFriends()
        {
            if(currentUserProfile != null)
            {
                if (panelFriends.InvokeRequired)
                {
                    panelFriends.Invoke(new Action(LoadPanelFriends));
                    return;
                }

                if (currentTaskBar == labelFriends)
                {
                    ShowLoading();
                }
                panelFriends.Controls.Clear();
                if (currentUserProfile.Friends != null)
                {
                    hasFriendsData = false;
                    foreach (var item in currentUserProfile.Friends)
                    {
                        UserSummaryCommon userSummary = new UserSummaryCommon
                        {
                            CurrentUserSummary = item,
                            IsFollowing = true,
                            Dock = DockStyle.Top,
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(10, 4, 10, 4),
                        };

                        if (panelFriends.InvokeRequired)
                        {
                            panelFriends.Invoke(new Action(() =>
                            {
                                panelFriends.Controls.Add(userSummary);
                            }));
                        }
                        else
                        {
                            panelFriends.Controls.Add(userSummary);
                        }
                        if (!hasFriendsData)
                        {
                            hasFriendsData = true;
                        }
                    }
                }
                else
                {
                    hasFriendsData = false;
                }

                if (currentTaskBar == labelFriends)
                {
                    HideLoading();
                    LoadPanel(this.panelFriends, hasFriendsData);
                }
            }
            else
            {
                this.panelFriends.Controls.Clear();
                hasFriendsData = false;
            }
        }

        private async void LoadProfile()
        {
            if (currentUserProfile != null)
            {
                LoadProfilePhoto();

                if(currentUserProfile.User != null)
                {
                    if (!string.IsNullOrEmpty(currentUserProfile.User.FullName))
                    {
                        this.labelFullName.Text = currentUserProfile.User.FullName;
                    }
                    if (!string.IsNullOrEmpty(currentUserProfile.User.Username))
                    {
                        this.labelUsername.Text = currentUserProfile.User.Username;
                    }
                }
            }
            else
            {
                this.userAvatar.Image = Resources.profile;
                this.labelFullName.Text = "Unknown";
                this.labelUsername.Text = "Unknown";
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

        private async void LoadProfilePhoto()
        {
            if (currentUserProfile.User != null && !string.IsNullOrEmpty(currentUserProfile.User.Avatar))
            {
                try
                {
                    var imageUrl = currentUserProfile.User.Avatar;

                    userAvatar.Image = await NetworkLoader.LoadImageFromUrlAsync(imageUrl);
                }
                catch (Exception ex)
                {
                    userAvatar.Image = Properties.Resources.profile;
                }
            }
            else
            {
                userAvatar.Image = Properties.Resources.profile;
            }
        }

        private void LoadFollowerCounter()
        {
            if (currentUserProfile != null)
            {
                if (currentUserProfile.Followers != null)
                {
                    this.labelFollowerCounter.Text = currentUserProfile.Followers.Count.ToShortNumber() + " Followers";
                }
                else
                {
                    this.labelFollowerCounter.Text = "0 Followers";
                }
            }
            else
            {
                this.labelFollowerCounter.Text = "0 Followers";
            }
        }

        private void LoadFollowingCounter()
        {
            if (currentUserProfile != null)
            {
                if (currentUserProfile.Followings != null)
                {
                    this.labelFollowingCounter.Text = currentUserProfile.Followings.Count.ToShortNumber() + " Followings";
                }
                else
                {
                    this.labelFollowingCounter.Text = "0 Followings";
                }
            }
            else
            {
                this.labelFollowingCounter.Text = "0 Followings";
            }
        }

        private void OnFriendDataLoaded()
        {
            LoadFriendCounter();
            LoadPanelFriends();
        }

        private void LoadFriendCounter()
        {
            if (currentUserProfile != null)
            {
                if (currentUserProfile.Friends != null)
                {
                    this.labelFriendCounter.Text = currentUserProfile.Friends.Count.ToShortNumber() + " Friends";
                }
                else
                {
                    this.labelFriendCounter.Text = "0 Friends";
                }
            }
            else
            {
                this.labelFriendCounter.Text = "0 Friends";
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (sender is Label clickedLabel)
            {
                SetSelectedLabel(clickedLabel);

                if (clickedLabel == labelMedias)
                {
                    LoadPanel(this.panelMedias, hasMediasData);
                }
                else if (clickedLabel == labelFriends)
                {
                    LoadPanel(this.panelFriends, hasFriendsData);
                }
                else if (clickedLabel == labelMore)
                {
                    LoadPanel(this.panelMore, hasMoreData);
                }
                else
                {
                    LoadPanel(this.panelPosts, hasPostsData);
                }
            }
        }

        private void LoadPanel(object panelSender, bool hasData)
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

            ActivatePanel(panelSender);
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

        private void SetFocusedLabel(Label label, bool isFocused)
        {
            label.Font = new Font(label.Font, isFocused ? FontStyle.Bold : FontStyle.Regular);
            label.BackColor = isFocused ? Color.FromArgb(148, 148, 148) : Color.Transparent;
        }

        private void UnsetSelectedLabel(Label label)
        {
            label.Font = new Font(label.Font, FontStyle.Regular);
            label.BackColor = Color.Transparent;
        }

        private void SetSelectedLabel(Label clickedLabel)
        {
            foreach (Control control in tableLayoutPanelProfileTaskBar.Controls)
            {
                if (control is Label label)
                {
                    UnsetSelectedLabel(label);
                }
            }

            clickedLabel.Font = new Font(clickedLabel.Font, FontStyle.Bold);
            clickedLabel.BackColor = Color.Transparent;
            currentTaskBar = clickedLabel;
        }

        private void RegisterHoverAndClickEventsForLabels()
        {
            foreach (Control control in tableLayoutPanelProfileTaskBar.Controls)
            {
                if (control is Label label)
                {
                    label.MouseHover += Label_MouseHover;
                    label.MouseLeave += Label_MouseLeave;

                    label.Click += Label_Click;
                }
            }
            this.panelFriends.Visible = false;
            this.panelMedias.Visible = false;
            this.panelMore.Visible = false;
            this.NotFoundContainer.Visible = false;
            this.LoadingContainer.Visible = true;

            SetSelectedLabel(labelPosts);
        }

        private void Label_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label label && label != currentTaskBar)
            {
                SetFocusedLabel(label, true);
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label && label != currentTaskBar)
            {
                SetFocusedLabel(label, false);
            }
        }

        private void CloseWindowControlButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
