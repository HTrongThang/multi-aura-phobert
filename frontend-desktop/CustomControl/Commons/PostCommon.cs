using BLL.DataProviders;
using CustomControl.Extensions;
using CustomControl.Modals;
using CustomControl.Properties;
using CustomControl.Utils;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class PostCommon : UserControl
    {
        private AppDataProvider appDataProvider;
        private PostDataProvider postDataProvider;
        private RelationshipDataProvider relationshipDataProvider;

        private bool isLiked = false;
        private int likeCounter = 0;

        private int currentImageIndex;
        private List<Image> imageUrls;

        private Post currentPost = null;
        public Post CurrentPost
        {
            get => currentPost;
            set
            {
                if (currentPost != value)
                {
                    currentPost = value;
                    UpdateUI();
                }
            }
        }

        public PostCommon()
        {
            InitializeComponent();

            appDataProvider = AppDataProvider.Instance;
            postDataProvider = PostDataProvider.Instance;
            relationshipDataProvider = RelationshipDataProvider.Instance;
            postDataProvider.OnDeletePostSuccess += PostDataProvider_OnDeletePostSuccess;
            postDataProvider.OnLikePostSuccess += PostDataProvider_OnLikePostSuccess;
            postDataProvider.OnUnlikePostSuccess += PostDataProvider_OnUnlikePostSuccess; ;

            this.labelComment.Click += ShowModalPostDetails;
            this.labelLike.Click += LabelLike_Click;

            this.panelImages.SizeChanged += PanelImages_SizeChanged;
            UpdateUI();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.actionButton.Click += ActionButton_Click;

            this.userAvatar.Click += UserAvatar_Click;
            this.labelFullName.Click += UserAvatar_Click;

        }

        private void PostDataProvider_OnUnlikePostSuccess(string id)
        {
            if (currentPost != null && currentPost.Author != null
                     && !string.IsNullOrEmpty(currentPost.Author.UserID)
                 )
            {
                Task.Run(() =>
                {
                    if (id == currentPost.Author.UserID)
                    {
                        if (this.IsHandleCreated)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                isLiked = false;
                                UpdateHeart();
                            }));
                        }
                        else
                        {
                            this.HandleCreated += (sender, e) =>
                            {
                                this.BeginInvoke(new Action(() =>
                                {
                                    isLiked = false;
                                    UpdateHeart();
                                }));
                            };
                        }
                    }
                });
            }
        }

        private void PostDataProvider_OnLikePostSuccess(string id)
        {
            if (currentPost != null && currentPost.Author != null
                    && !string.IsNullOrEmpty(currentPost.Author.UserID)
                )
            {
                Task.Run(() =>
                {
                    if (id == currentPost.Author.UserID)
                    {
                        if (this.IsHandleCreated)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                isLiked = true;
                                UpdateHeart();
                            }));
                        }
                        else
                        {
                            this.HandleCreated += (sender, e) =>
                            {
                                this.BeginInvoke(new Action(() =>
                                {
                                    isLiked = true;
                                    UpdateHeart();
                                }));
                            };
                        }
                    }
                });
            }
        }

        private async void UserAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPost != null && currentPost.Author != null 
                    && !string.IsNullOrEmpty(currentPost.Author.Username))
                {
                    var (profile, errorMessage) = await relationshipDataProvider.GetProfileAsync(currentPost.Author.Username);

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
            bool isOwner = false;
            if(currentPost != null && currentPost.Author != null && !string.IsNullOrEmpty(currentPost.Author.UserID))
            {
                isOwner = currentPost.Author.UserID == appDataProvider.User.UserID;
            }
            Form modal = new PostMoreActionsModal
            {
                PostId = currentPost.Id,
                IsOwner = isOwner,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopMost = true
            };

            appDataProvider.ShowModal(this, modal);
        }

        private void PostDataProvider_OnDeletePostSuccess(string id)
        {
            if (currentPost != null && !string.IsNullOrEmpty(currentPost.Id))
            {
                if (id == currentPost.Id)
                {
                    this.Dispose();
                }
            }
        }

        private async void LabelLike_Click(object sender, EventArgs e)
        {
            if (isLiked)
            {
                likeCounter--;
                this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                this.labelLike.Image = Resources.heart;
                var result = await postDataProvider.UnlikePostAsync(currentPost.Id);
                if (result)
                {
                    isLiked = false;
                }
                else
                {
                    likeCounter++;
                }
            }
            else
            {
                likeCounter++;
                this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                this.labelLike.Image = Resources.red_heart;
                var result = await postDataProvider.LikePostAsync(currentPost.Id);
                if (result)
                {
                    isLiked = true;
                }
                else
                {
                    likeCounter--;
                }
            }
            UpdateHeart();
        }

        private void UpdateHeart()
        {
            this.labelTotalLikes.Text = likeCounter.ToShortNumber();
            if (isLiked)
            {
                this.labelLike.Image = Resources.red_heart;
            }
            else
            {
                this.labelLike.Image = Resources.heart;
            }
        }

        private async void UpdateUI()
        {
            if (currentPost != null)
            {
                SetUpPhotos();
                SetUpAuthorInfo();
                SetUpComments();

                if (currentPost.CreatedAt != null)
                {
                    this.labelCreateAt.Text = currentPost.CreatedAt.ToRelativeTime();
                }

                if (!string.IsNullOrEmpty(currentPost.Content))
                {
                    this.labelDescription.Text = currentPost.Content;
                }

                if (currentPost.LikedBy != null)
                {
                    if (currentPost.LikedBy != null && currentPost.LikedBy.Any(user => user.Username == appDataProvider.User.Username))
                    {
                        isLiked = true;
                        this.labelLike.Image = Resources.red_heart;
                    }
                    else
                    {
                        isLiked = false;
                        this.labelLike.Image = Resources.heart;
                    }

                    likeCounter = currentPost.LikedBy?.Count ?? 0;
                    this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                }
                else
                {
                    isLiked = false;
                    this.labelLike.Image = Resources.heart;
                }

                if (!string.IsNullOrEmpty(currentPost.Voice))
                {
                    VoicePlayerCommon voicePlayerCommon = new VoicePlayerCommon
                    {
                        Mp3URL = currentPost.Voice,
                    };

                    this.panelVoicePlayer.Controls.Add(voicePlayerCommon);
                    this.panelVoicePlayer.Visible = true;
                }
                else
                {
                    this.panelVoicePlayer.Visible = false;
                }
            }
            else
            {
                this.panelImages.Visible = false;
                this.preImage.Visible = false;
                this.nextImage.Visible = false;
            }
        }

        private async void SetUpAuthorInfo()
        {
            if (currentPost.Author != null)
            {
                if (appDataProvider.User != null
                    && !string.IsNullOrEmpty(appDataProvider.User.UserID)
                    && !string.IsNullOrEmpty(currentPost.Author.UserID)
                    && appDataProvider.User.UserID == currentPost.Author.UserID
                    && !string.IsNullOrEmpty(appDataProvider.User.Avatar)
                    )
                {
                    try
                    {
                        var imageUrl = appDataProvider.User.Avatar;
                        userAvatar.Image = await NetworkLoader.LoadImageFromUrlAsync(imageUrl);
                    }
                    catch (Exception ex)
                    {
                        userAvatar.Image = Properties.Resources.person;
                    }

                    if (!string.IsNullOrEmpty(appDataProvider.User.FullName))
                    {
                        this.labelFullName.Text = appDataProvider.User.FullName;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentPost.Author.Avatar))
                    {
                        try
                        {
                            var imageUrl = currentPost.Author.Avatar;
                            userAvatar.Image = await NetworkLoader.LoadImageFromUrlAsync(imageUrl);
                        }
                        catch (Exception ex)
                        {
                            userAvatar.Image = Properties.Resources.person;
                        }
                    }
                    else
                    {
                        userAvatar.Image = Properties.Resources.person;
                    }

                    if (!string.IsNullOrEmpty(currentPost.Author.FullName))
                    {
                        this.labelFullName.Text = currentPost.Author.FullName;
                    }
                }
            }
        }

        private async void SetUpPhotos()
        {
            if (currentPost.Images != null)
            {
                int count = 0;
                imageUrls = new List<Image>();

                foreach (var item in currentPost.Images)
                {
                    var image = await NetworkLoader.LoadImageFromUrlAsync(item.Url);
                    if (image != null)
                    {
                        imageUrls.Add(image);
                        count++;
                    }
                }

                if (count != 0)
                {
                    this.panelImages.Visible = true;
                    currentImageIndex = 0;
                    LoadImage(currentImageIndex);
                    if (count > 1)
                    {
                        this.preImage.Visible = true;
                        this.nextImage.Visible = true;
                        this.preImage.MouseHover += PreImage_MouseHover;
                        this.preImage.MouseLeave += PreImage_MouseLeave;
                        this.nextImage.MouseHover += NextImage_MouseHover;
                        this.nextImage.MouseLeave += NextImage_MouseLeave;
                        this.preImage.Click += PreImage_Click;
                        this.nextImage.Click += NextImage_Click;
                    }
                    else
                    {
                        this.preImage.Visible = false;
                        this.nextImage.Visible = false;
                    }
                }
                else
                {
                    this.panelImages.Visible = false;
                    this.preImage.Visible = false;
                    this.nextImage.Visible = false;
                }                
            }
            else
            {
                this.panelImages.Visible = false;
                this.preImage.Visible = false;
                this.nextImage.Visible = false;
            }
        }
        private async void SetUpComments()
        {
            if (currentPost.Comments != null)
            {
                foreach (var item in currentPost.Comments)
                {
                    CommentCommon commentCommon = new CommentCommon
                    {
                        CurrentComment = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    commentCommon.ShowModalRequested += (sender, args) =>
                    {
                        ShowModalPostDetails(sender, args);
                    };

                    if (panelComments.InvokeRequired)
                    {
                        panelComments.Invoke(new Action(() =>
                        {
                            panelComments.Controls.Add(commentCommon);
                        }));
                    }
                    else
                    {
                        panelComments.Controls.Add(commentCommon);
                    }
                }                
            }
        }

        private void ShowModalPostDetails(object sender, EventArgs e)
        {
            Form modal = new PostDetails
            {
                CurrentPost = currentPost,
                Width = appDataProvider.ScreenWidth - 400,
                Height = appDataProvider.ScreenHeight - 100,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopMost = true
            };

            appDataProvider.ShowModal(this, modal);
        }

        private void PreImage_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                LoadImage(currentImageIndex);
            }
            else if (currentImageIndex == 0)
            {
                currentImageIndex = currentPost.Images.Count - 1;
                LoadImage(currentImageIndex);
            }
        }

        private void NextImage_Click(object sender, EventArgs e)
        {
            // Chuyển đến ảnh tiếp theo
            if (currentImageIndex < currentPost.Images.Count - 1)
            {
                currentImageIndex++;
                LoadImage(currentImageIndex);
            }
            else if (currentImageIndex == currentPost.Images.Count - 1)
            {
                currentImageIndex = 0;
                LoadImage(currentImageIndex);
            }            
        }

        private async void LoadImage(int index)
        {
            if (index < 0 || index >= currentPost.Images.Count) return;

            var image = imageUrls[index];
            if (image != null)
            {
                this.currentPhotoBox.Image = image;
            }
        }        

        private void NextImage_MouseLeave(object sender, EventArgs e)
        {
            this.nextImage.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void NextImage_MouseHover(object sender, EventArgs e)
        {
            this.nextImage.BackColor = Color.FromArgb(144, 144, 144);
        }

        private void PreImage_MouseLeave(object sender, EventArgs e)
        {
            this.preImage.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void PreImage_MouseHover(object sender, EventArgs e)
        {
            this.preImage.BackColor = Color.FromArgb(144, 144, 144);
        }

        private void PanelImages_SizeChanged(object sender, EventArgs e)
        {
            // Tính toán vị trí theo chiều dọc (giữa panelImages)
            int centerY = panelImages.Height / 2;

            // Cập nhật vị trí cho preImage
            preImage.Location = new Point(preImage.Location.X, centerY - preImage.Height / 2);

            // Cập nhật vị trí cho nextImage
            nextImage.Location = new Point(nextImage.Location.X, centerY - nextImage.Height / 2);
        }
    }
}
