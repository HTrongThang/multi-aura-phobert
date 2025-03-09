using BLL.DataProviders;
using System;
using System.Windows.Forms;

namespace CustomControl.Modals
{
    public partial class PostMoreActionsModal : Form
    {
        private readonly PostDataProvider postDataProvider;

        public string PostId { get; set; } = string.Empty;

        private bool isOwner = false;
        public bool IsOwner
        {
            get => isOwner;
            set
            {
                isOwner = value;
                this.buttonDelete.Visible = isOwner;
            }
        }

        public PostMoreActionsModal()
        {
            InitializeComponent();
            postDataProvider = PostDataProvider.Instance;

            this.buttonDelete.Click += ButtonDelete_Click;
        }

        private async void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (IsOwner && !string.IsNullOrEmpty(PostId))
            {
                DialogResult confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this post?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    this.buttonDelete.Enabled = false;

                    try
                    {
                        bool result = await postDataProvider.DeletePostAsync(PostId);

                        if (result)
                        {
                            MessageBox.Show("Post deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete post. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.buttonDelete.Enabled = true;
                    }
                }
            }
        }
    }
}
