using BLL.DataProviders;
using CustomControl.Commons;
using CustomControl.Extensions;
using CustomControl.Properties;
using CustomControl.Utils;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace CustomControl.Modals
{
    public partial class PostDetails : Form
    {
        private AppDataProvider appDataProvider;
        private PostDataProvider postDataProvider;

        private List<string> photoPaths = new List<string>();

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
                    if(currentPost != null && !string.IsNullOrEmpty(currentPost.Id))
                    {
                        postDataProvider.FetchCommentsOfCurrentPost(currentPost.Id);
                    }
                    
                    UpdateUI();
                }
            }
        }
        public PostDetails()
        {
            InitializeComponent();
            this.CloseWindowControlButton.Click += CloseWindowControlButton_Click;
            this.flowLayoutPanelPhotos.Visible = false;

            appDataProvider = AppDataProvider.Instance;

            postDataProvider = PostDataProvider.Instance;
            postDataProvider.CommentsOfCurrentPostDataLoaded += SetUpComments;

            this.labelComment.Click += LabelComment_Click;
            this.labelLike.Click += LabelLike_Click;
            this.panelImages.SizeChanged += PanelImages_SizeChanged;
            this.buttonAddPhoto.Click += ButtonAddPhoto_Click;

            this.labelSending.Click += LabelSending_Click;

            this.labelTextToSpeechClear.Click += LabelTextToSpeechClear_Click;

            if (currentPost != null && !string.IsNullOrEmpty(currentPost.Id))
            {
                postDataProvider.FetchCommentsOfCurrentPost(currentPost.Id);
            }

            UpdateUI();
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
            var result = await postDataProvider.CreateCommentAsync(currentPost.Id, text, textToSpeech, photoPaths);
            if (result != null)
            {
                AddReplyCommentToPanel(result);
                //MessageBox.Show("Comment created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
            }
            else
            {
                MessageBox.Show("Failed to create comment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.labelSending.Enabled = true;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(this.inputText.Text) || this.inputText.Text == this.inputText.Hint)
                return false;

            if (currentPost == null || string.IsNullOrEmpty(currentPost.Id))
                return false;

            return true;
        }

        private void AddReplyCommentToPanel(Comment result)
        {
            CommentCommon commentCommon = new CommentCommon
            {
                IsReplyable = true,
                CurrentComment = result,
                Margin = new Padding(0, 0, 0, 0),
                Padding = new Padding(0, 0, 0, 0),
                Dock = DockStyle.Top,
            };

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.panelComments.Controls.Add(commentCommon);
                    commentCommon.Dock = DockStyle.Top;
                }));
            }
            else
            {
                this.panelComments.Controls.Add(commentCommon);
                commentCommon.Dock = DockStyle.Top;
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
            int newWidth = (int)(0.6 * this.Width);
            this.panelImages.MinimumSize = new Size(newWidth, this.Height);
            this.panelImages.Width = newWidth;

            if (currentPost != null)
            {
                SetUpPhotos();
                SetUpAuthorInfo();
                SetUpComments();

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
            }
            else
            {
                this.panelImages.MinimumSize = new Size(0, this.Height);
                this.panelImages.Width = 0;
                this.nextImage.Visible = false;
                this.preImage.Visible = false;
                this.panelVoicePlayer.Visible = false;
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

        private async void SetUpComments()
        {
            UpdateUI(panelComments, () =>
            {
                panelComments.Controls.Clear();
                currentPost.Comments = postDataProvider.CommentsOfCurrentPost;
                if (currentPost.Comments != null)
                {
                    foreach (var item in currentPost.Comments)
                    {
                        CommentCommon commentCommon = new CommentCommon
                        {
                            IsReplyable = true,
                            CurrentComment = item,
                            Dock = DockStyle.Top,
                            Margin = new Padding(0, 0, 0, 0),
                        };

                        panelComments.Controls.Add(commentCommon);
                    }
                }
            });
        }

        private void LabelComment_Click(object sender, EventArgs e)
        {
            Form modal = new PostDetails
            {
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
        private void CloseWindowControlButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LabelTextToSpeechClear_Click(object sender, EventArgs e)
        {
            this.inputTextToSpeech.ClearText();
        }

        private void PanelImages_SizeChanged(object sender, EventArgs e)
        {
            // Tính toán vị trí theo chiều dọc (giữa panelImages)
            int centerY = panelImages.Height / 2;
            int nextImageLocationX = panelImages.Width - 30;

            // Cập nhật vị trí cho preImage
            preImage.Location = new Point(10, centerY - preImage.Height / 2);

            // Cập nhật vị trí cho nextImage
            nextImage.Location = new Point(nextImageLocationX, centerY - nextImage.Height / 2);
        }
    }
}
