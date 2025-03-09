using BLL.DataProviders;
using CustomControl.Extensions;
using CustomControl.Modals;
using CustomControl.Properties;
using CustomControl.Utils;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class CommentCommon : UserControl
    {
        public event EventHandler ShowModalRequested;

        private List<string> photoPaths = new List<string>();

        private AppDataProvider appDataProvider;
        private PostDataProvider postDataProvider;
        private RelationshipDataProvider relationshipDataProvider;

        private bool isLiked = false;
        private int likeCounter = 0;

        private string replyFor = "";
        private bool isReplyable = false;

        public bool IsReplyable
        {
            get => isReplyable;
            set
            {
                if (isReplyable == value)
                    return;

                isReplyable = value;

                this.labelReply.Click -= ShowModalPostDetails;
                this.labelReply.Click -= OpenPanelCommentInput;

                if (isReplyable)
                {
                    this.labelReply.Click += OpenPanelCommentInput;
                }
                else
                {
                    this.labelReply.Click += ShowModalPostDetails;
                    this.panelInputComment.Visible = false;
                }
            }
        }

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
        public CommentCommon()
        {
            InitializeComponent();
            this.flowLayoutPanelPhotos.Visible = false;
            this.panelInputComment.Visible = false;

            appDataProvider = AppDataProvider.Instance;
            postDataProvider = PostDataProvider.Instance;
            relationshipDataProvider = RelationshipDataProvider.Instance;
            postDataProvider.OnDeleteCommentSuccess += PostDataProvider_OnDeleteCommentSuccess;
            postDataProvider.OnLikeCommentSuccess += PostDataProvider_OnLikeCommentSuccess;
            postDataProvider.OnUnlikeCommentSuccess += PostDataProvider_OnUnlikeCommentSuccess;

            this.MouseClick += CommentCommon_MouseClick;
            this.tableLayoutPanelInfo.MouseClick += CommentCommon_MouseClick;
            this.tableLayoutPanelLikeCounter.MouseClick += CommentCommon_MouseClick;
            this.tableLayoutPanelComment.MouseClick += CommentCommon_MouseClick;
            this.tableLayoutPanel12.MouseClick += CommentCommon_MouseClick;
            this.flowLayoutPanelImages.MouseClick += CommentCommon_MouseClick;
            this.labelFullName.MouseClick += CommentCommon_MouseClick;
            this.labelText.MouseClick += CommentCommon_MouseClick;

            this.labelReply.MouseHover += LabelReply_MouseHover;
            this.labelReply.MouseLeave += LabelReply_MouseLeave;

            this.labelLike.Click += LabelLike_Click;

            this.buttonAddPhoto.Click += ButtonAddPhoto_Click;

            this.labelSending.Click += LabelSending_Click;

            if (isReplyable)
            {
                this.labelReply.Click += OpenPanelCommentInput;
            }
            else
            {
                this.labelReply.Click += ShowModalPostDetails;
                this.panelInputComment.Visible = false;
            }

            this.userAvatar.Click += UserAvatar_Click;
            this.labelFullName.Click += UserAvatar_Click;

            this.labelTextToSpeechClear.Click += LabelTextToSpeechClear_Click;
        }

        private void PostDataProvider_OnUnlikeCommentSuccess(string id)
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

        private void PostDataProvider_OnLikeCommentSuccess(string id)
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

        private void PostDataProvider_OnDeleteCommentSuccess(string id)
        {
            if (currentComment != null && !string.IsNullOrEmpty(currentComment.Id))
            {
                if (id == currentComment.Id)
                {
                    this.Dispose();
                }
            }
        }

        private void CommentCommon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip = null;

                bool isOwner = false;
                if (currentComment != null && currentComment.Author != null && !string.IsNullOrEmpty(currentComment.Author.UserID))
                {
                    isOwner = currentComment.Author.UserID == appDataProvider.User.UserID;
                }

                Form modal = new CommentMoreActionModal
                {
                    CommentId = currentComment.Id,
                    IsOwner = isOwner,
                    StartPosition = FormStartPosition.CenterScreen,
                    ShowInTaskbar = false,
                    TopMost = true
                };

                appDataProvider.ShowModal(this, modal);
            }
        }

        private void OpenPanelCommentInput(object sender, EventArgs e)
        {
            this.panelInputComment.Visible = true;
            //if (currentComment != null && currentComment.Author != null
            //    && !string.IsNullOrEmpty(currentComment.Author.Username))
            //{
            //    this.inputText.Focus();
            //}
            this.inputText.Focus();
        }
        private async void LabelSending_Click(object sender, EventArgs e)
        {
            this.labelSending.Enabled = false;

            if (!ValidateInput())
            {
                this.labelSending.Enabled = true;
                return;
            }

            string text = this.inputText.GetInputText();
            string textToSpeech = this.inputTextToSpeech.GetInputText();

            var result = await postDataProvider.CreateReplyCommentAsync(currentComment.Id, text, textToSpeech, photoPaths);
            if (result != null)
            {
                AddReplyCommentToPanel(result);
                //MessageBox.Show("Reply comment created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
            }
            else
            {
                MessageBox.Show("Failed to create reply comment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.labelSending.Enabled = true;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(this.inputText.Text) || this.inputText.Text == this.inputText.Hint)
                return false;

            if (currentComment == null || string.IsNullOrEmpty(currentComment.Id))
                return false;

            return true;
        }

        private void AddReplyCommentToPanel(Comment result)
        {
            ReplyComment replyComment = new ReplyComment
            {
                IsReplyable = IsReplyable,
                ParentCommentId = currentComment.Id,
                CurrentComment = result,
                Margin = new Padding(0, 0, 0, 0),
                Padding = new Padding(0, 0, 0, 0),
                Dock = DockStyle.Top,
            };

            replyComment.ShowModalRequested += (objSender, args) =>
            {
                ShowModalPostDetails(objSender, args);
            };

            replyComment.OpenInputTextRequested += (objSender, args) =>
            {
                if (result != null && result.Author != null && !string.IsNullOrEmpty(result.Author.Username))
                {
                    replyFor = result.Author.Username;
                }
                OpenPanelCommentInput(objSender, args);
            };

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.panelReplies.Controls.Add(replyComment);
                    panelReplies.Controls.SetChildIndex(replyComment, 0);
                }));
            }
            else
            {
                this.panelReplies.Controls.Add(replyComment);
                panelReplies.Controls.SetChildIndex(replyComment, 0);
            }
        }

        private void ClearData()
        {
            this.inputText.ClearText();

            foreach (Control control in this.flowLayoutPanelPhotos.Controls)
            {
                if (control is PhotoHolderCommon photoHolder)
                {
                    photoHolder.Dispose();
                }
            }
            this.flowLayoutPanelPhotos.Controls.Clear();
            this.flowLayoutPanelPhotos.Visible = false;
            photoPaths.Clear();
        }
        private void ButtonAddPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] selectedFiles = openFileDialog.FileNames;
                    bool hasData = false;
                    foreach (string filePath in selectedFiles)
                    {
                        if (!hasData)
                        {
                            this.flowLayoutPanelPhotos.Visible = true;
                            hasData = true;
                        }
                        AddPhotoToPanel(filePath);
                    }
                    if (!hasData)
                    {
                        this.flowLayoutPanelPhotos.Visible = false;
                    }
                }
            }
        }

        private void AddPhotoToPanel(string filePath)
        {
            try
            {
                PhotoHolderCommon photoHolder = new PhotoHolderCommon
                {
                    PhotoPath = filePath,
                    Width = 120,
                    Height = 120,
                    Margin = new Padding(5)
                };

                photoHolder.OnPhotoRemoved += (s, path) =>
                {
                    photoPaths.Remove(path);
                    if (photoPaths.Count == 0)
                    {
                        this.flowLayoutPanelPhotos.Visible = false;
                    }
                };

                this.flowLayoutPanelPhotos.Controls.Add(photoHolder);
                photoPaths.Add(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding photo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LabelLike_Click(object sender, EventArgs e)
        {
            if (isLiked)
            {
                likeCounter--;
                this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                this.labelLike.Image = Resources.heart;
                var result = await postDataProvider.UnlikeCommentAsync(currentComment.Id);
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
                var result = await postDataProvider.LikeCommentAsync(currentComment.Id);
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
                SetUpReplyComments();
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
                        userAvatar.Image = Properties.Resources.person;
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
                else
                {
                    this.labelFullName.Text = "Unknown";
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
                    this.labelText.Text = currentComment.Text;
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

        private void SetUpReplyComments()
        {
            if (currentComment.Replies != null)
            {
                foreach (var item in currentComment.Replies)
                {
                    ReplyComment replyComment = new ReplyComment
                    {
                        IsReplyable = IsReplyable,
                        ParentCommentId = currentComment.Id,
                        CurrentComment = item,
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(0, 0, 0, 0),
                        Dock = DockStyle.Top,
                    };

                    replyComment.ShowModalRequested += (sender, args) =>
                    {
                        ShowModalPostDetails(sender, args);
                    };

                    replyComment.OpenInputTextRequested += (sender, args) =>
                    {
                        if (item != null && item.Author != null && !string.IsNullOrEmpty(item.Author.Username))
                        {
                            replyFor = item.Author.Username;
                        }
                        OpenPanelCommentInput(sender, args);
                    };

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.panelReplies.Controls.Add(replyComment);
                            panelReplies.Controls.SetChildIndex(replyComment, 0);
                        }));
                    }
                    else
                    {
                        this.panelReplies.Controls.Add(replyComment);
                        panelReplies.Controls.SetChildIndex(replyComment, 0);
                    }
                }
            }
        }

        private void ShowModalPostDetails(object sender, EventArgs e)
        {
            ShowModalRequested?.Invoke(this, EventArgs.Empty);
        }

        private void LabelReply_MouseLeave(object sender, EventArgs e)
        {
            labelReply.ForeColor = Color.FromArgb(222, 222, 222);
        }

        private void LabelReply_MouseHover(object sender, EventArgs e)
        {
            labelReply.ForeColor = Color.White;
        }

        private void LabelTextToSpeechClear_Click(object sender, EventArgs e)
        {
            this.inputTextToSpeech.ClearText();
        }
    }
}
