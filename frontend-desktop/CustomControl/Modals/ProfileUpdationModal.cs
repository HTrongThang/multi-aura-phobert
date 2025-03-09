using BLL.DataProviders;
using BLL.Repository;
using CustomControl.Commons;
using CustomControl.Properties;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControl.Modals
{
    public partial class ProfileUpdationModal : Form
    {
        private string photoPath = string.Empty;
        private User currentUser = null;

        private Timer usernameInputTimer;
        private const int DelayMilliseconds = 500;
        private bool isValidUsername = false;

        public User CurrentUser
        {
            get => currentUser;
            set
            {
                if (currentUser != value)
                {
                    currentUser = value;
                    if (currentUser != null
                        && !string.IsNullOrEmpty(currentUser.Username)
                        && !string.IsNullOrEmpty(currentUser.FullName)
                        )
                    {
                        this.inputTextName.Text = currentUser.FullName;
                        this.inputTextUsername.Text = currentUser.Username;
                    }
                }
            }
        }

        public ProfileUpdationModal()
        {
            InitializeComponent();
            this.CloseWindowControlButton.Click += CloseWindowControlButton_Click;
            this.inputTextName.IsHintVisible = false;
            this.inputTextUsername.IsHintVisible = false;
            this.userAvatar.Click += UserAvatar_Click;

            usernameInputTimer = new Timer();
            usernameInputTimer.Interval = DelayMilliseconds;
            usernameInputTimer.Tick += UsernameInputTimer_Tick;

            this.inputTextUsername.TextChanged += InputTextUsername_TextChanged;
            this.buttonUpdate.Click += ButtonUpdate_Click;
        }

        private void CloseWindowControlButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string newUsername = this.inputTextUsername.GetInputText().Trim();
            string newName = this.inputTextName.GetInputText().Trim();

            if (currentUser == null)
            {
                MessageBox.Show("No user loaded for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var changes = new Dictionary<string, object>();

            if (!string.Equals(newUsername, currentUser.Username, StringComparison.OrdinalIgnoreCase))
            {
                if (!isValidUsername)
                {
                    MessageBox.Show("The username is not valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                changes["username"] = newUsername;
            }

            if (!string.Equals(newName, currentUser.FullName, StringComparison.OrdinalIgnoreCase))
            {
                changes["fullname"] = newName;
            }

            if (changes.Count == 0 && photoPath == string.Empty)
            {
                MessageBox.Show("No changes detected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UpdateUser(changes);
        }

        private async void UpdateUser(Dictionary<string, object> changes)
        {
            try
            {
                var (result, message) = await AuthDataProvider.Instance.UpdateProfileAsync(photoPath, changes);

                if (!result)
                {
                    MessageBox.Show($"Failed to update profile: {message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    photoPath = openFileDialog.FileName;

                    LoadPhoto(photoPath);
                }
            }
        }

        private void LoadPhoto(string filePath)
        {
            try
            {
                if (this.userAvatar.Image != null)
                {
                    this.userAvatar.Image.Dispose();
                    this.userAvatar.Image = null;
                }

                this.userAvatar.Image = Image.FromFile(filePath);
                this.userAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading photo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InputTextUsername_TextChanged(object sender, EventArgs e)
        {
            usernameInputTimer.Stop();
            usernameInputTimer.Start();
        }

        private void UsernameInputTimer_Tick(object sender, EventArgs e)
        {
            usernameInputTimer.Stop();
            string username = this.inputTextUsername.Text.Trim();

            if (!string.IsNullOrEmpty(username))
            {
                GetUsernameDetails(username);
            }
        }

        private async void GetUsernameDetails(string username)
        {
            try
            {
                var (userDetails, errorMessage) = await RelationshipDataProvider.Instance.GetProfileAsync(username);

                if (userDetails != null)
                {
                    this.labelUsernameCheck.Image = Resources.invalid;
                    isValidUsername = false;
                }
                else
                {
                    this.labelUsernameCheck.Image = Resources.check;
                    isValidUsername = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching username details: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
