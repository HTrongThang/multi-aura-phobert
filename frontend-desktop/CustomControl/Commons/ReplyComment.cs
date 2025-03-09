using BLL.DataProviders;
using CustomControl.Extensions;
using CustomControl.Modals;
using CustomControl.Properties;
using CustomControl.Utils;
using DTO;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class ReplyComment : UserControl
    {
        public event EventHandler ShowModalRequested;
        public event EventHandler OpenInputTextRequested;

        private AppDataProvider appDataProvider;
        private PostDataProvider postDataProvider;
        private RelationshipDataProvider relationshipDataProvider;

        private bool isLiked = false;
        private int likeCounter = 0;

        private bool isReplyable = false;

        public bool IsReplyable
        {
            get => isReplyable;
            set
            {
                if (isReplyable == value)
                    return;

                isReplyable = value;

                this.labelReply.Click -= LabelReply_Click;
                this.labelReply.Click -= RequestOpenPanelCommentInput;

                if (isReplyable)
                {
                    this.labelReply.Click += RequestOpenPanelCommentInput;
                }
                else
                {
                    this.labelReply.Click += LabelReply_Click;
                }
            }
        }

        public string ParentCommentId { get; set; } = string.Empty;

        private Comment currentComment = null;
        public Comment CurrentComment
        {
            get => currentComment;
            set
            {
                if (currentComment != value)
                {
                    currentComment = value;
                    UpdateUI();
                }
            }
        }
        public ReplyComment()
        {
            InitializeComponent();

            appDataProvider = AppDataProvider.Instance;
            postDataProvider = PostDataProvider.Instance;
            relationshipDataProvider = RelationshipDataProvider.Instance;
            postDataProvider.OnDeleteReplyCommentSuccess += PostDataProvider_OnDeleteReplyCommentSuccess;
            postDataProvider.OnLikeReplyCommentSuccess += PostDataProvider_OnLikeReplyCommentSuccess;
            postDataProvider.OnUnlikeReplyCommentSuccess += PostDataProvider_OnUnlikeReplyCommentSuccess;

            this.MouseClick += ReplyComment_MouseClick;
            this.tableLayoutPanelInfo.MouseClick += ReplyComment_MouseClick;
            this.tableLayoutPanelLikeCounter.MouseClick += ReplyComment_MouseClick;
            this.tableLayoutPanelComment.MouseClick += ReplyComment_MouseClick;
            this.tableLayoutPanel12.MouseClick += ReplyComment_MouseClick;
            this.flowLayoutPanelImages.MouseClick += ReplyComment_MouseClick;
            this.labelFullName.MouseClick += ReplyComment_MouseClick;
            this.labelText.MouseClick += ReplyComment_MouseClick;

            this.labelReply.MouseHover += LabelReply_MouseHover;
            this.labelReply.MouseLeave += LabelReply_MouseLeave;

            this.labelLike.Click += LabelLike_Click;

            if (isReplyable)
            {
                this.labelReply.Click += RequestOpenPanelCommentInput;
            }
            else
            {
                this.labelReply.Click += LabelReply_Click;
            }

            this.userAvatar.Click += UserAvatar_Click;
            this.labelFullName.Click += UserAvatar_Click;
        }

        private void PostDataProvider_OnUnlikeReplyCommentSuccess(string id)
        {
            if (currentComment != null && currentComment.Author != null
                      && !string.IsNullOrEmpty(currentComment.Author.UserID)
                  )
            {
                Task.Run(() =>
                {
                    if (id == currentComment.Author.UserID)
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

        private void PostDataProvider_OnLikeReplyCommentSuccess(string id)
        {
            if (currentComment != null && currentComment.Author != null
                      && !string.IsNullOrEmpty(currentComment.Author.UserID)
                  )
            {
                Task.Run(() =>
                {
                    if (id == currentComment.Author.UserID)
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
                if (currentComment != null && currentComment.Author != null
                    && !string.IsNullOrEmpty(currentComment.Author.Username))
                {
                    var (profile, errorMessage) = await relationshipDataProvider.GetProfileAsync(currentComment.Author.Username);

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

        private void PostDataProvider_OnDeleteReplyCommentSuccess(string id)
        {
            if (currentComment != null && !string.IsNullOrEmpty(currentComment.Id))
            {
                if (id == currentComment.Id)
                {
                    this.Dispose();
                }
            }
        }

        private void ReplyComment_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip = null;

                bool isOwner = false;
                if (currentComment != null && currentComment.Author != null && !string.IsNullOrEmpty(currentComment.Author.UserID))
                {
                    isOwner = currentComment.Author.UserID == appDataProvider.User.UserID;
                }

                Form modal = new ReplyCommentMoreActionModal
                {
                    ReplyId = currentComment.Id,
                    CommentId = ParentCommentId,
                    IsOwner = isOwner,
                    StartPosition = FormStartPosition.CenterScreen,
                    ShowInTaskbar = false,
                    TopMost = true
                };

                appDataProvider.ShowModal(this, modal);
            }
        }

        private async void LabelLike_Click(object sender, EventArgs e)
        {
            if (isLiked)
            {
                likeCounter--;
                this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                this.labelLike.Image = Resources.heart;
                var result = await postDataProvider.UnlikeReplyCommentAsync(ParentCommentId, currentComment.Id);
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
                var result = await postDataProvider.LikeReplyCommentAsync(ParentCommentId, currentComment.Id);
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

        private void UpdateUI()
        {
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            if (currentComment != null)
            {
                SetUpAuthorInfo();
                SetUpCommentDetails();
            }
        }

        private async void SetUpAuthorInfo()
        {
            if (currentComment.Author != null)
            {
                if (!string.IsNullOrEmpty(currentComment.Author.Avatar))
                {
                    try
                    {
                        var imageUrl = currentComment.Author.Avatar;
                        using (HttpClient httpClient = new HttpClient())
                        {
                            var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
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

                if (!string.IsNullOrEmpty(currentComment.Author.FullName))
                {
                    this.labelFullName.Text = currentComment.Author.FullName;
                }
            }
        }

        private void SetUpCommentDetails()
        {
            if (currentComment != null)
            {
                SetUpPhotos();
                if (!string.IsNullOrEmpty(currentComment.Text))
                {
                    this.labelText.Visible = true;
                    if (!string.IsNullOrEmpty(currentComment.ReplyFor))
                    {
                        this.labelText.Text = "@" + currentComment.ReplyFor + " " + currentComment.Text;
                    }
                    else
                    {
                        this.labelText.Text = currentComment.Text;
                    }
                }
                else
                {
                    this.labelText.Visible = false;
                }

                if (currentComment.CreatedAt != null)
                {
                    this.labelTime.Text = currentComment.CreatedAt.ToRelativeTime();
                }

                if (currentComment.LikedBy != null)
                {
                    if (currentComment.LikedBy.Contains(appDataProvider.User.Username))
                    {
                        isLiked = true;
                        this.labelLike.Image = Resources.red_heart16;
                    }
                    else
                    {
                        isLiked = false;
                        this.labelLike.Image = Resources.heart16;
                    }
                    likeCounter = currentComment.LikedBy.Count;
                    this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                }
                else
                {
                    isLiked = false;
                    this.labelLike.Image = Resources.heart16;
                }
                if (!string.IsNullOrEmpty(currentComment.Voice))
                {
                    VoicePlayerCommon voicePlayerCommon = new VoicePlayerCommon
                    {
                        Mp3URL = currentComment.Voice,
                    };

                    this.panelVoicePlayer.Controls.Add(voicePlayerCommon);
                    this.panelVoicePlayer.Visible = true;
                }
                else
                {
                    this.panelVoicePlayer.Visible = false;
                }
            }
        }

        private async void SetUpPhotos()
        {
            if (currentComment.Images != null)
            {
                bool hasData = false;
                //imageUrls = new List<Image>();

                foreach (var item in currentComment.Images)
                {
                    var image = await NetworkLoader.LoadImageFromUrlAsync(item.Url);
                    if (image != null)
                    {
                        //imageUrls.Add(image);

                        PictureBox pictureBox = new PictureBox
                        {
                            Image = image,
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(0, 10, 0, 10),
                            Size = new Size(160, 160),
                            SizeMode = PictureBoxSizeMode.Zoom,
                        };

                        if (this.flowLayoutPanelImages.InvokeRequired)
                        {
                            this.flowLayoutPanelImages.Invoke(new Action(() =>
                            {
                                this.flowLayoutPanelImages.Controls.Add(pictureBox);
                            }));
                        }
                        else
                        {
                            this.flowLayoutPanelImages.Controls.Add(pictureBox);
                        }

                        if (!hasData)
                        {
                            hasData = true;
                        }
                    }
                }
                if (hasData)
                {
                    this.flowLayoutPanelImages.Visible = true;
                }
                else
                {
                    this.flowLayoutPanelImages.Visible = false;
                }
            }
            else
            {
                this.flowLayoutPanelImages.Visible = false;
            }
        }
        private void LabelReply_Click(object sender, EventArgs e)
        {
            ShowModalRequested?.Invoke(this, EventArgs.Empty);
        }

        private void RequestOpenPanelCommentInput(object sender, EventArgs e)
        {
            OpenInputTextRequested?.Invoke(this, EventArgs.Empty);
        }

        private void LabelReply_MouseLeave(object sender, EventArgs e)
        {
            labelReply.ForeColor = Color.FromArgb(222, 222, 222);
        }

        private void LabelReply_MouseHover(object sender, EventArgs e)
        {
            labelReply.ForeColor = Color.White;
        }
    }
}
