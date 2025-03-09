using BLL.DataProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Modals
{
    public partial class ReplyCommentMoreActionModal : Form
    {
        private readonly PostDataProvider postDataProvider;

        public string CommentId { get; set; } = string.Empty;
        public string ReplyId { get; set; } = string.Empty;

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

        public ReplyCommentMoreActionModal()
        {
            InitializeComponent();
            postDataProvider = PostDataProvider.Instance;

            this.buttonDelete.Click += ButtonDelete_Click;
        }

        private async void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (IsOwner && !string.IsNullOrEmpty(CommentId) && !string.IsNullOrEmpty(ReplyId))
            {
                DialogResult confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this comment?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    this.buttonDelete.Enabled = false;

                    try
                    {
                        bool result = await postDataProvider.DeleteReplyCommentAsync(CommentId, ReplyId);

                        if (result)
                        {
                            MessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
