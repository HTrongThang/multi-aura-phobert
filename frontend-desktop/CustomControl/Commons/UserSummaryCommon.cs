using BLL.DataProviders;
using CustomControl.Modals;
using DTO;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class UserSummaryCommon : UserControl
    {
        public AppDataProvider appDataProvider;
        public RelationshipDataProvider relationshipDataProvider;
        public UserSummary CurrentUserSummary = null;
        public bool IsFollowing = false;
        public bool IsBlocked = false;
        public UserSummaryCommon()
        {
            InitializeComponent();
            appDataProvider = AppDataProvider.Instance;
            relationshipDataProvider = RelationshipDataProvider.Instance;

            this.Load += UserSummaryCommon_Load;

            this.actionButton.MouseHover += ActionButton_MouseHover;
            this.actionButton.MouseLeave += ActionButton_MouseLeave;
            this.actionButton.Click += ActionButton_Click;

            this.Click += UserSummaryCommon_Click;
            this.userAvatar.Click += UserSummaryCommon_Click;
            this.labelFullName.Click += UserSummaryCommon_Click;
            this.labelUsername.Click += UserSummaryCommon_Click;

            relationshipDataProvider.OnFollowEvent += RelationshipDataProvider_OnFollowEvent;
            relationshipDataProvider.OnUnfollowEvent += RelationshipDataProvider_OnUnfollowEvent;
            relationshipDataProvider.OnBlockEvent += RelationshipDataProvider_OnBlockEvent;
            relationshipDataProvider.OnUnblockEvent += RelationshipDataProvider_OnUnblockEvent;
        }

        private void RelationshipDataProvider_OnUnblockEvent(string id)
        {
            Task.Run(() =>
            {
                if (id == CurrentUserSummary.UserID)
                {
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            this.Visible = true;
                        }));
                    }
                    else
                    {
                        this.HandleCreated += (sender, e) =>
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                this.Visible = true;
                            }));
                        };
                    }
                }
            });
        }

        private void RelationshipDataProvider_OnBlockEvent(string id)
        {
            Task.Run(() =>
            {
                if (id == CurrentUserSummary.UserID)
                {
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            this.Visible = false;
                        }));
                    }
                    else
                    {
                        this.HandleCreated += (sender, e) =>
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                this.Visible = false;
                            }));
                        };
                    }
                }
            });
        }

        private void RelationshipDataProvider_OnUnfollowEvent(string id)
        {
            Task.Run(() =>
            {
                if (id == CurrentUserSummary.UserID)
                {
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            this.actionButton.Text = "Follow";
                            IsFollowing = false;
                        }));
                    }
                    else
                    {
                        this.HandleCreated += (sender, e) =>
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                this.actionButton.Text = "Follow";
                                IsFollowing = false;
                            }));
                        };
                    }
                }
            });
        }

        private void RelationshipDataProvider_OnFollowEvent(string id)
        {
            Task.Run(() =>
            {
                if (id == CurrentUserSummary.UserID)
                {
                    if (this.IsHandleCreated)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            this.actionButton.Text = "Following";
                            IsFollowing = true;
                        }));
                    }
                    else
                    {
                        this.HandleCreated += (sender, e) =>
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                this.actionButton.Text = "Following";
                                IsFollowing = true;
                            }));
                        };
                    }
                }
            });
        }

        private async void UserSummaryCommon_Load(object sender, EventArgs e)
        {
            if(CurrentUserSummary != null)
            {
                if (!string.IsNullOrEmpty(CurrentUserSummary.Avatar))
                {
                    try
                    {
                        // Tải ảnh từ URL
                        var imageUrl = CurrentUserSummary.Avatar;
                        using (HttpClient httpClient = new HttpClient())
                        {
                            var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                // Gán ảnh vào PictureBox
                                userAvatar.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        userAvatar.Image = Properties.Resources.person; // ảnh mặc định trong Resources
                    }
                }
                else
                {
                    userAvatar.Image = Properties.Resources.person;
                }

                if (!string.IsNullOrEmpty(CurrentUserSummary.FullName))
                {
                    this.labelFullName.Text = CurrentUserSummary.FullName;
                }

                if (!string.IsNullOrEmpty(CurrentUserSummary.Username))
                {
                    this.labelUsername.Text = CurrentUserSummary.Username;
                }
            }

            this.actionButton.Text = IsBlocked ? "Unblock" : IsFollowing ? "Following" : "Follow";
        }

        private async void UserSummaryCommon_Click(object sender, EventArgs e)
        {
            try
            {
                if(CurrentUserSummary != null && !string.IsNullOrEmpty(CurrentUserSummary.Username))
                {
                    var (profile, errorMessage) = await relationshipDataProvider.GetProfileAsync(CurrentUserSummary.Username);

                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        RequestOpenModal(profile);
                    }
                    else
                    {
                        MessageBox.Show("Can not go to this profile \nError fetching other profile: " + errorMessage);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong \nCan not go to this profile!");
            }
        }

        private void RequestOpenModal(UserProfile profile)
        {
            Form modal = new ProfileDetails
            {
                CurrentUserProfile = profile,
                Width = appDataProvider.ScreenWidth - 100,
                Height = appDataProvider.ScreenHeight - 100,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopMost = true
            };

            appDataProvider.ShowModal(this, modal);
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if(CurrentUserSummary != null && CurrentUserSummary.UserID != null)
            {
                this.actionButton.Text = "Processing..";

                Task.Run(async () =>
                {
                    try
                    {
                        if (IsBlocked)
                        {
                            var (result, _) = await relationshipDataProvider.Unblock(CurrentUserSummary);

                            this.Invoke(new Action(() =>
                            {
                                if (result)
                                {
                                    IsBlocked = false;
                                    this.actionButton.Text = "Block";
                                    this.Visible = false;
                                    this.Dispose();
                                }
                            }));
                        }
                        else if (IsFollowing)
                        {
                            var (result,  _) = await relationshipDataProvider.Unfollow(CurrentUserSummary);

                            this.Invoke(new Action(() =>
                            {
                                if (result)
                                {
                                    IsFollowing = false;
                                }

                                this.actionButton.Text = IsFollowing ? "Following" : "Follow";
                            }));
                        }
                        else
                        {
                            var (result, _) = await relationshipDataProvider.Follow(CurrentUserSummary);

                            this.Invoke(new Action(() =>
                            {
                                if (result)
                                {
                                    IsFollowing = true;
                                }

                                this.actionButton.Text = IsFollowing ? "Following" : "Follow";
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show($"Operation failed: {ex.Message}");
                            this.actionButton.Text = IsFollowing ? "Following" : "Follow";
                        }));
                    }
                });

            }
        }

        private void ActionButton_MouseHover(object sender, EventArgs e)
        {
            this.actionButton.ForeColor = Color.FromArgb(144, 144, 144);
        }
        private void ActionButton_MouseLeave(object sender, EventArgs e)
        {
            this.actionButton.ForeColor = Color.White;
        }
    }
}

