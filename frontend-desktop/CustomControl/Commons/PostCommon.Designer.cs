namespace CustomControl.Commons
{
    partial class PostCommon
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.actionButton = new System.Windows.Forms.Label();
            this.userAvatar = new CustomControl.Commons.AvatarCommon();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCreateAt = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.tableLayoutPanelDescription = new System.Windows.Forms.TableLayoutPanel();
            this.panelVoicePlayer = new System.Windows.Forms.Panel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.panelComments = new System.Windows.Forms.Panel();
            this.panelPostTaskBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelShare = new System.Windows.Forms.Label();
            this.labelComment = new System.Windows.Forms.Label();
            this.labelLike = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTotalLikes = new System.Windows.Forms.Label();
            this.panelImages = new System.Windows.Forms.Panel();
            this.nextImage = new CustomControl.Commons.AvatarCommon();
            this.preImage = new CustomControl.Commons.AvatarCommon();
            this.currentPhotoBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanelDescription.SuspendLayout();
            this.panelPostTaskBar.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panelImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nextImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentPhotoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.panel1.Size = new System.Drawing.Size(520, 52);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.actionButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.userAvatar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 44);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // actionButton
            // 
            this.actionButton.AutoEllipsis = true;
            this.actionButton.AutoSize = true;
            this.actionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.actionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionButton.ForeColor = System.Drawing.Color.White;
            this.actionButton.Image = global::CustomControl.Properties.Resources.more;
            this.actionButton.Location = new System.Drawing.Point(460, 14);
            this.actionButton.Margin = new System.Windows.Forms.Padding(20, 14, 4, 14);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(46, 16);
            this.actionButton.TabIndex = 3;
            this.actionButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userAvatar
            // 
            this.userAvatar.CurrentUser = null;
            this.userAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userAvatar.Image = global::CustomControl.Properties.Resources.person;
            this.userAvatar.Location = new System.Drawing.Point(0, 0);
            this.userAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.userAvatar.MaximumSize = new System.Drawing.Size(40, 40);
            this.userAvatar.MinimumSize = new System.Drawing.Size(40, 40);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.Size = new System.Drawing.Size(40, 40);
            this.userAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userAvatar.TabIndex = 1;
            this.userAvatar.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelCreateAt, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelFullName, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(40, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(400, 44);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // labelCreateAt
            // 
            this.labelCreateAt.AutoEllipsis = true;
            this.labelCreateAt.AutoSize = true;
            this.labelCreateAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCreateAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreateAt.ForeColor = System.Drawing.Color.White;
            this.labelCreateAt.Location = new System.Drawing.Point(10, 22);
            this.labelCreateAt.Margin = new System.Windows.Forms.Padding(0);
            this.labelCreateAt.Name = "labelCreateAt";
            this.labelCreateAt.Size = new System.Drawing.Size(390, 22);
            this.labelCreateAt.TabIndex = 1;
            this.labelCreateAt.Text = "•30s";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoEllipsis = true;
            this.labelFullName.AutoSize = true;
            this.labelFullName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.ForeColor = System.Drawing.Color.White;
            this.labelFullName.Location = new System.Drawing.Point(10, 0);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(390, 22);
            this.labelFullName.TabIndex = 0;
            this.labelFullName.Text = "Full name";
            this.labelFullName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanelDescription
            // 
            this.tableLayoutPanelDescription.AutoSize = true;
            this.tableLayoutPanelDescription.ColumnCount = 1;
            this.tableLayoutPanelDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDescription.Controls.Add(this.panelVoicePlayer, 0, 1);
            this.tableLayoutPanelDescription.Controls.Add(this.labelDescription, 0, 0);
            this.tableLayoutPanelDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelDescription.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanelDescription.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelDescription.MinimumSize = new System.Drawing.Size(0, 40);
            this.tableLayoutPanelDescription.Name = "tableLayoutPanelDescription";
            this.tableLayoutPanelDescription.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tableLayoutPanelDescription.RowCount = 2;
            this.tableLayoutPanelDescription.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDescription.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDescription.Size = new System.Drawing.Size(520, 61);
            this.tableLayoutPanelDescription.TabIndex = 1;
            // 
            // panelVoicePlayer
            // 
            this.panelVoicePlayer.AutoSize = true;
            this.panelVoicePlayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVoicePlayer.Location = new System.Drawing.Point(10, 21);
            this.panelVoicePlayer.Margin = new System.Windows.Forms.Padding(0);
            this.panelVoicePlayer.MinimumSize = new System.Drawing.Size(0, 40);
            this.panelVoicePlayer.Name = "panelVoicePlayer";
            this.panelVoicePlayer.Size = new System.Drawing.Size(510, 40);
            this.panelVoicePlayer.TabIndex = 23;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDescription.Font = new System.Drawing.Font("Montserrat Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.ForeColor = System.Drawing.Color.White;
            this.labelDescription.Location = new System.Drawing.Point(10, 0);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(510, 21);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Description";
            // 
            // panelComments
            // 
            this.panelComments.AutoSize = true;
            this.panelComments.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelComments.Location = new System.Drawing.Point(0, 738);
            this.panelComments.Margin = new System.Windows.Forms.Padding(0);
            this.panelComments.MinimumSize = new System.Drawing.Size(0, 40);
            this.panelComments.Name = "panelComments";
            this.panelComments.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.panelComments.Size = new System.Drawing.Size(520, 40);
            this.panelComments.TabIndex = 25;
            // 
            // panelPostTaskBar
            // 
            this.panelPostTaskBar.Controls.Add(this.tableLayoutPanel5);
            this.panelPostTaskBar.Controls.Add(this.tableLayoutPanel4);
            this.panelPostTaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPostTaskBar.Location = new System.Drawing.Point(0, 678);
            this.panelPostTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelPostTaskBar.Name = "panelPostTaskBar";
            this.panelPostTaskBar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelPostTaskBar.Size = new System.Drawing.Size(520, 60);
            this.panelPostTaskBar.TabIndex = 24;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel5.Controls.Add(this.labelShare, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelComment, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelLike, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 10);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(520, 32);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // labelShare
            // 
            this.labelShare.AutoSize = true;
            this.labelShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelShare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShare.Image = global::CustomControl.Properties.Resources.share;
            this.labelShare.Location = new System.Drawing.Point(106, 0);
            this.labelShare.Margin = new System.Windows.Forms.Padding(0);
            this.labelShare.Name = "labelShare";
            this.labelShare.Size = new System.Drawing.Size(48, 32);
            this.labelShare.TabIndex = 2;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelComment.Image = global::CustomControl.Properties.Resources.comment;
            this.labelComment.Location = new System.Drawing.Point(58, 0);
            this.labelComment.Margin = new System.Windows.Forms.Padding(0);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(48, 32);
            this.labelComment.TabIndex = 1;
            // 
            // labelLike
            // 
            this.labelLike.AutoSize = true;
            this.labelLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLike.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLike.Image = global::CustomControl.Properties.Resources.heart;
            this.labelLike.Location = new System.Drawing.Point(10, 0);
            this.labelLike.Margin = new System.Windows.Forms.Padding(0);
            this.labelLike.Name = "labelLike";
            this.labelLike.Size = new System.Drawing.Size(48, 32);
            this.labelLike.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.labelTotalLikes, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 10);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(520, 50);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // labelTotalLikes
            // 
            this.labelTotalLikes.AutoSize = true;
            this.labelTotalLikes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalLikes.ForeColor = System.Drawing.Color.White;
            this.labelTotalLikes.Location = new System.Drawing.Point(10, 0);
            this.labelTotalLikes.Margin = new System.Windows.Forms.Padding(0);
            this.labelTotalLikes.MaximumSize = new System.Drawing.Size(48, 18);
            this.labelTotalLikes.MinimumSize = new System.Drawing.Size(48, 0);
            this.labelTotalLikes.Name = "labelTotalLikes";
            this.labelTotalLikes.Size = new System.Drawing.Size(48, 18);
            this.labelTotalLikes.TabIndex = 0;
            this.labelTotalLikes.Text = "0";
            this.labelTotalLikes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelImages
            // 
            this.panelImages.Controls.Add(this.nextImage);
            this.panelImages.Controls.Add(this.preImage);
            this.panelImages.Controls.Add(this.currentPhotoBox);
            this.panelImages.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelImages.Location = new System.Drawing.Point(0, 113);
            this.panelImages.Margin = new System.Windows.Forms.Padding(0);
            this.panelImages.MinimumSize = new System.Drawing.Size(520, 440);
            this.panelImages.Name = "panelImages";
            this.panelImages.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.panelImages.Size = new System.Drawing.Size(520, 565);
            this.panelImages.TabIndex = 23;
            // 
            // nextImage
            // 
            this.nextImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nextImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.nextImage.CurrentUser = null;
            this.nextImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextImage.Image = global::CustomControl.Properties.Resources.chevron_right;
            this.nextImage.Location = new System.Drawing.Point(462, 261);
            this.nextImage.Margin = new System.Windows.Forms.Padding(0);
            this.nextImage.MaximumSize = new System.Drawing.Size(24, 24);
            this.nextImage.MinimumSize = new System.Drawing.Size(24, 24);
            this.nextImage.Name = "nextImage";
            this.nextImage.Size = new System.Drawing.Size(24, 24);
            this.nextImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.nextImage.TabIndex = 2;
            this.nextImage.TabStop = false;
            // 
            // preImage
            // 
            this.preImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.preImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.preImage.CurrentUser = null;
            this.preImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.preImage.Image = global::CustomControl.Properties.Resources.chevron_left;
            this.preImage.Location = new System.Drawing.Point(34, 261);
            this.preImage.Margin = new System.Windows.Forms.Padding(0);
            this.preImage.MaximumSize = new System.Drawing.Size(24, 24);
            this.preImage.MinimumSize = new System.Drawing.Size(24, 24);
            this.preImage.Name = "preImage";
            this.preImage.Size = new System.Drawing.Size(24, 24);
            this.preImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.preImage.TabIndex = 1;
            this.preImage.TabStop = false;
            // 
            // currentPhotoBox
            // 
            this.currentPhotoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPhotoBox.Location = new System.Drawing.Point(20, 0);
            this.currentPhotoBox.Margin = new System.Windows.Forms.Padding(0);
            this.currentPhotoBox.Name = "currentPhotoBox";
            this.currentPhotoBox.Size = new System.Drawing.Size(480, 562);
            this.currentPhotoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.currentPhotoBox.TabIndex = 0;
            this.currentPhotoBox.TabStop = false;
            // 
            // PostCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelComments);
            this.Controls.Add(this.panelPostTaskBar);
            this.Controls.Add(this.panelImages);
            this.Controls.Add(this.tableLayoutPanelDescription);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(520, 40);
            this.Name = "PostCommon";
            this.Size = new System.Drawing.Size(520, 797);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanelDescription.ResumeLayout(false);
            this.tableLayoutPanelDescription.PerformLayout();
            this.panelPostTaskBar.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panelImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nextImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentPhotoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label actionButton;
        private AvatarCommon userAvatar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelCreateAt;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Panel panelComments;
        private System.Windows.Forms.Panel panelPostTaskBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelShare;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Label labelLike;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelTotalLikes;
        private System.Windows.Forms.Panel panelImages;
        private AvatarCommon nextImage;
        private AvatarCommon preImage;
        private System.Windows.Forms.PictureBox currentPhotoBox;
        private System.Windows.Forms.Panel panelVoicePlayer;
    }
}
