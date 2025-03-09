using BLL.DataProviders;
using CustomControl.Commons;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomControl.Modals
{
    public partial class PostCreationModal : Form
    {
        private PostDataProvider postDataProvider;

        private List<string> photoPaths = new List<string>();
        public PostCreationModal()
        {
            InitializeComponent();
            postDataProvider = PostDataProvider.Instance;

            this.CloseWindowControlButton.Click += CloseWindowControlButton_Click;
            this.labelClear.Click += LabelClear_Click;
            this.labelTextToSpeechClear.Click += LabelTextToSpeechClear_Click;
            this.buttonAddPhoto.Click += ButtonAddPhoto_Click;
            this.buttonPost.Click += ButtonPost_Click;
        }

        private void LabelTextToSpeechClear_Click(object sender, EventArgs e)
        {
            this.inputTextToSpeech.ClearText();
        }

        private async void ButtonPost_Click(object sender, EventArgs e)
        {
            this.buttonPost.Enabled = false;
            string text = this.inputText.GetInputText();
            string textToSpeech = this.inputTextToSpeech.GetInputText();
            if (!string.IsNullOrEmpty(text))
            {
                var result = await postDataProvider.CreatePostAsync(text, textToSpeech, photoPaths);
                if (result)
                {
                    //MessageBox.Show("Post created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create post. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.buttonPost.Enabled = true;
        }

        private void ClearData()
        {
            this.inputText.ClearText();
            this.inputTextToSpeech.ClearText();

            foreach (Control control in this.flowLayoutPanelPhotos.Controls)
            {
                if (control is PhotoHolderCommon photoHolder)
                {
                    photoHolder.Dispose();
                }
            }
            this.flowLayoutPanelPhotos.Controls.Clear();

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

                    foreach (string filePath in selectedFiles)
                    {
                        AddPhotoToPanel(filePath);
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
                    Width = 140,
                    Height = 140,
                    Margin = new Padding(5)
                };

                photoHolder.OnPhotoRemoved += (s, path) =>
                {
                    photoPaths.Remove(path);
                };

                this.flowLayoutPanelPhotos.Controls.Add(photoHolder);
                photoPaths.Add(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding photo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LabelClear_Click(object sender, EventArgs e)
        {
            this.inputText.ClearText();
        }

        private void CloseWindowControlButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
