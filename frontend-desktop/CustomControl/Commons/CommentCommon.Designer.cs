namespace CustomControl.Commons
{
    partial class CommentCommon
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
            this.tableLayoutPanelComment = new System.Windows.Forms.TableLayoutPanel();
            this.userAvatar = new CustomControl.Commons.AvatarCommon();
            this.tableLayoutPanelInfo = new System.Windows.Forms.TableLayoutPanel();
            this.labelText = new System.Windows.Forms.Label();
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.panelActionTaskBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanelLikeCounter = new System.Windows.Forms.TableLayoutPanel();
            this.labelTotalLikes = new System.Windows.Forms.Label();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.labelLike = new System.Windows.Forms.Label();
            this.labelReply = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.panelVoicePlayer = new System.Windows.Forms.Panel();
            this.panelReplies = new System.Windows.Forms.Panel();
            this.panelInputComment = new System.Windows.Forms.Panel();
            this.flowLayoutPanelPhotos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.inputTextToSpeech = new CustomControl.Commons.AutoSizeTextBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTextToSpeechClear = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddPhoto = new System.Windows.Forms.Label();
            this.containerCommon1 = new CustomControl.Commons.ContainerCommon();
            this.inputText = new CustomControl.Commons.AutoSizeTextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSending = new System.Windows.Forms.Label();
            this.tableLayoutPanelComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.tableLayoutPanelInfo.SuspendLayout();
            this.panelActionTaskBar.SuspendLayout();
            this.tableLayoutPanelLikeCounter.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.panelInputComment.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.containerCommon1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelComment
            // 
            this.tableLayoutPanelComment.AutoSize = true;
            this.tableLayoutPanelComment.ColumnCount = 2;
            this.tableLayoutPanelComment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelComment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelComment.Controls.Add(this.userAvatar, 0, 0);
            this.tableLayoutPanelComment.Controls.Add(this.tableLayoutPanelInfo, 1, 0);
            this.tableLayoutPanelComment.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanelComment.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelComment.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelComment.Name = "tableLayoutPanelComment";
            this.tableLayoutPanelComment.RowCount = 1;
            this.tableLayoutPanelComment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelComment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanelComment.Size = new System.Drawing.Size(517, 142);
            this.tableLayoutPanelComment.TabIndex = 15;
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
            // tableLayoutPanelInfo
            // 
            this.tableLayoutPanelInfo.AutoSize = true;
            this.tableLayoutPanelInfo.ColumnCount = 1;
            this.tableLayoutPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInfo.Controls.Add(this.labelText, 0, 1);
            this.tableLayoutPanelInfo.Controls.Add(this.flowLayoutPanelImages, 0, 3);
            this.tableLayoutPanelInfo.Controls.Add(this.panelActionTaskBar, 0, 4);
            this.tableLayoutPanelInfo.Controls.Add(this.labelFullName, 0, 0);
            this.tableLayoutPanelInfo.Controls.Add(this.panelVoicePlayer, 0, 2);
            this.tableLayoutPanelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInfo.Location = new System.Drawing.Point(40, 0);
            this.tableLayoutPanelInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelInfo.Name = "tableLayoutPanelInfo";
            this.tableLayoutPanelInfo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tableLayoutPanelInfo.RowCount = 5;
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelInfo.Size = new System.Drawing.Size(477, 142);
            this.tableLayoutPanelInfo.TabIndex = 2;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.ForeColor = System.Drawing.Color.White;
            this.labelText.Location = new System.Drawing.Point(10, 22);
            this.labelText.Margin = new System.Windows.Forms.Padding(0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(457, 16);
            this.labelText.TabIndex = 15;
            this.labelText.Text = "Text";
            // 
            // flowLayoutPanelImages
            // 
            this.flowLayoutPanelImages.AutoScroll = true;
            this.flowLayoutPanelImages.AutoSize = true;
            this.flowLayoutPanelImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(10, 78);
            this.flowLayoutPanelImages.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Padding = new System.Windows.Forms.Padding(0, 4, 0, 20);
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(457, 24);
            this.flowLayoutPanelImages.TabIndex = 13;
            this.flowLayoutPanelImages.WrapContents = false;
            // 
            // panelActionTaskBar
            // 
            this.panelActionTaskBar.Controls.Add(this.tableLayoutPanelLikeCounter);
            this.panelActionTaskBar.Controls.Add(this.tableLayoutPanel12);
            this.panelActionTaskBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActionTaskBar.Location = new System.Drawing.Point(10, 102);
            this.panelActionTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelActionTaskBar.Name = "panelActionTaskBar";
            this.panelActionTaskBar.Size = new System.Drawing.Size(457, 40);
            this.panelActionTaskBar.TabIndex = 11;
            // 
            // tableLayoutPanelLikeCounter
            // 
            this.tableLayoutPanelLikeCounter.ColumnCount = 2;
            this.tableLayoutPanelLikeCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLikeCounter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelLikeCounter.Controls.Add(this.labelTotalLikes, 1, 0);
            this.tableLayoutPanelLikeCounter.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelLikeCounter.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanelLikeCounter.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLikeCounter.Name = "tableLayoutPanelLikeCounter";
            this.tableLayoutPanelLikeCounter.RowCount = 1;
            this.tableLayoutPanelLikeCounter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLikeCounter.Size = new System.Drawing.Size(457, 24);
            this.tableLayoutPanelLikeCounter.TabIndex = 1;
            // 
            // labelTotalLikes
            // 
            this.labelTotalLikes.AutoSize = true;
            this.labelTotalLikes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalLikes.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalLikes.ForeColor = System.Drawing.Color.White;
            this.labelTotalLikes.Location = new System.Drawing.Point(409, 0);
            this.labelTotalLikes.Margin = new System.Windows.Forms.Padding(0);
            this.labelTotalLikes.MinimumSize = new System.Drawing.Size(48, 0);
            this.labelTotalLikes.Name = "labelTotalLikes";
            this.labelTotalLikes.Size = new System.Drawing.Size(48, 24);
            this.labelTotalLikes.TabIndex = 1;
            this.labelTotalLikes.Text = "0";
            this.labelTotalLikes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel12.ColumnCount = 5;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel12.Controls.Add(this.labelLike, 4, 0);
            this.tableLayoutPanel12.Controls.Add(this.labelReply, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.labelTime, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(457, 22);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // labelLike
            // 
            this.labelLike.AutoSize = true;
            this.labelLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLike.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLike.ForeColor = System.Drawing.Color.White;
            this.labelLike.Image = global::CustomControl.Properties.Resources.heart16;
            this.labelLike.Location = new System.Drawing.Point(409, 0);
            this.labelLike.Margin = new System.Windows.Forms.Padding(0);
            this.labelLike.MinimumSize = new System.Drawing.Size(48, 0);
            this.labelLike.Name = "labelLike";
            this.labelLike.Size = new System.Drawing.Size(48, 22);
            this.labelLike.TabIndex = 4;
            this.labelLike.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelReply
            // 
            this.labelReply.AutoSize = true;
            this.labelReply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelReply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelReply.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.labelReply.Location = new System.Drawing.Point(48, 0);
            this.labelReply.Margin = new System.Windows.Forms.Padding(0);
            this.labelReply.Name = "labelReply";
            this.labelReply.Size = new System.Drawing.Size(48, 22);
            this.labelReply.TabIndex = 1;
            this.labelReply.Text = "Reply";
            this.labelReply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(0, 0);
            this.labelTime.Margin = new System.Windows.Forms.Padding(0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(48, 22);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "•1w";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoEllipsis = true;
            this.labelFullName.AutoSize = true;
            this.labelFullName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFullName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.ForeColor = System.Drawing.Color.White;
            this.labelFullName.Location = new System.Drawing.Point(10, 0);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(74, 22);
            this.labelFullName.TabIndex = 0;
            this.labelFullName.Text = "Full name";
            this.labelFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelVoicePlayer
            // 
            this.panelVoicePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVoicePlayer.Location = new System.Drawing.Point(10, 38);
            this.panelVoicePlayer.Margin = new System.Windows.Forms.Padding(0);
            this.panelVoicePlayer.MinimumSize = new System.Drawing.Size(0, 40);
            this.panelVoicePlayer.Name = "panelVoicePlayer";
            this.panelVoicePlayer.Size = new System.Drawing.Size(457, 40);
            this.panelVoicePlayer.TabIndex = 16;
            // 
            // panelReplies
            // 
            this.panelReplies.AutoSize = true;
            this.panelReplies.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelReplies.Location = new System.Drawing.Point(0, 142);
            this.panelReplies.Margin = new System.Windows.Forms.Padding(0);
            this.panelReplies.MinimumSize = new System.Drawing.Size(0, 10);
            this.panelReplies.Name = "panelReplies";
            this.panelReplies.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.panelReplies.Size = new System.Drawing.Size(517, 10);
            this.panelReplies.TabIndex = 16;
            // 
            // panelInputComment
            // 
            this.panelInputComment.AutoSize = true;
            this.panelInputComment.BackColor = System.Drawing.Color.Transparent;
            this.panelInputComment.Controls.Add(this.flowLayoutPanelPhotos);
            this.panelInputComment.Controls.Add(this.panel3);
            this.panelInputComment.Controls.Add(this.tableLayoutPanel1);
            this.panelInputComment.Controls.Add(this.tableLayoutPanel5);
            this.panelInputComment.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInputComment.Location = new System.Drawing.Point(0, 152);
            this.panelInputComment.Margin = new System.Windows.Forms.Padding(0);
            this.panelInputComment.Name = "panelInputComment";
            this.panelInputComment.Padding = new System.Windows.Forms.Padding(48, 10, 10, 10);
            this.panelInputComment.Size = new System.Drawing.Size(517, 268);
            this.panelInputComment.TabIndex = 29;
            // 
            // flowLayoutPanelPhotos
            // 
            this.flowLayoutPanelPhotos.AutoScroll = true;
            this.flowLayoutPanelPhotos.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelPhotos.Location = new System.Drawing.Point(48, 118);
            this.flowLayoutPanelPhotos.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelPhotos.MaximumSize = new System.Drawing.Size(0, 140);
            this.flowLayoutPanelPhotos.MinimumSize = new System.Drawing.Size(0, 140);
            this.flowLayoutPanelPhotos.Name = "flowLayoutPanelPhotos";
            this.flowLayoutPanelPhotos.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelPhotos.Size = new System.Drawing.Size(459, 140);
            this.flowLayoutPanelPhotos.TabIndex = 109;
            this.flowLayoutPanelPhotos.WrapContents = false;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.tableLayoutPanel10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(48, 74);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(459, 44);
            this.panel3.TabIndex = 108;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel10.Controls.Add(this.inputTextToSpeech, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel11, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(439, 24);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // inputTextToSpeech
            // 
            this.inputTextToSpeech.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.inputTextToSpeech.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputTextToSpeech.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputTextToSpeech.Font = new System.Drawing.Font("Montserrat Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextToSpeech.ForeColor = System.Drawing.Color.White;
            this.inputTextToSpeech.Hint = "Aa, enter your text";
            this.inputTextToSpeech.Location = new System.Drawing.Point(0, 2);
            this.inputTextToSpeech.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.inputTextToSpeech.MaxLength = 180;
            this.inputTextToSpeech.MaxLine = 6;
            this.inputTextToSpeech.Multiline = true;
            this.inputTextToSpeech.Name = "inputTextToSpeech";
            this.inputTextToSpeech.Size = new System.Drawing.Size(401, 22);
            this.inputTextToSpeech.TabIndex = 6;
            this.inputTextToSpeech.Text = "Aa, enter your text";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.labelTextToSpeechClear, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(407, 0);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel11.MinimumSize = new System.Drawing.Size(24, 24);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(32, 24);
            this.tableLayoutPanel11.TabIndex = 5;
            // 
            // labelTextToSpeechClear
            // 
            this.labelTextToSpeechClear.AutoSize = true;
            this.labelTextToSpeechClear.BackColor = System.Drawing.Color.Transparent;
            this.labelTextToSpeechClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTextToSpeechClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTextToSpeechClear.Image = global::CustomControl.Properties.Resources.clear24;
            this.labelTextToSpeechClear.Location = new System.Drawing.Point(4, 0);
            this.labelTextToSpeechClear.Margin = new System.Windows.Forms.Padding(0);
            this.labelTextToSpeechClear.MaximumSize = new System.Drawing.Size(24, 24);
            this.labelTextToSpeechClear.MinimumSize = new System.Drawing.Size(24, 24);
            this.labelTextToSpeechClear.Name = "labelTextToSpeechClear";
            this.labelTextToSpeechClear.Size = new System.Drawing.Size(24, 24);
            this.labelTextToSpeechClear.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(48, 40);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 34);
            this.tableLayoutPanel1.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Montserrat SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(410, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Wanna some fun? Let\'s make a sound by type some word";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel9, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.containerCommon1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(48, 10);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(459, 30);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.buttonAddPhoto, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(395, 6);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.MinimumSize = new System.Drawing.Size(24, 24);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(32, 24);
            this.tableLayoutPanel9.TabIndex = 6;
            // 
            // buttonAddPhoto
            // 
            this.buttonAddPhoto.AutoSize = true;
            this.buttonAddPhoto.BackColor = System.Drawing.Color.Transparent;
            this.buttonAddPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddPhoto.Image = global::CustomControl.Properties.Resources.image;
            this.buttonAddPhoto.Location = new System.Drawing.Point(4, 0);
            this.buttonAddPhoto.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddPhoto.MaximumSize = new System.Drawing.Size(24, 24);
            this.buttonAddPhoto.MinimumSize = new System.Drawing.Size(24, 24);
            this.buttonAddPhoto.Name = "buttonAddPhoto";
            this.buttonAddPhoto.Size = new System.Drawing.Size(24, 24);
            this.buttonAddPhoto.TabIndex = 4;
            // 
            // containerCommon1
            // 
            this.containerCommon1.AutoSize = true;
            this.containerCommon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.containerCommon1.Controls.Add(this.inputText);
            this.containerCommon1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.containerCommon1.Location = new System.Drawing.Point(0, 0);
            this.containerCommon1.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.containerCommon1.Name = "containerCommon1";
            this.containerCommon1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.containerCommon1.Radius = 6;
            this.containerCommon1.Size = new System.Drawing.Size(383, 30);
            this.containerCommon1.TabIndex = 4;
            // 
            // inputText
            // 
            this.inputText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.inputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputText.Font = new System.Drawing.Font("Montserrat Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputText.ForeColor = System.Drawing.Color.White;
            this.inputText.Hint = "Aa, enter your text";
            this.inputText.Location = new System.Drawing.Point(6, 4);
            this.inputText.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.inputText.MaxLine = 4;
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(371, 22);
            this.inputText.TabIndex = 5;
            this.inputText.Text = "Aa, enter your text";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.labelSending, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(427, 6);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.MinimumSize = new System.Drawing.Size(24, 24);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(32, 24);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // labelSending
            // 
            this.labelSending.AutoSize = true;
            this.labelSending.BackColor = System.Drawing.Color.Transparent;
            this.labelSending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSending.Image = global::CustomControl.Properties.Resources.sending;
            this.labelSending.Location = new System.Drawing.Point(4, 0);
            this.labelSending.Margin = new System.Windows.Forms.Padding(0);
            this.labelSending.MaximumSize = new System.Drawing.Size(24, 24);
            this.labelSending.MinimumSize = new System.Drawing.Size(24, 24);
            this.labelSending.Name = "labelSending";
            this.labelSending.Size = new System.Drawing.Size(24, 24);
            this.labelSending.TabIndex = 4;
            // 
            // CommentCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelInputComment);
            this.Controls.Add(this.panelReplies);
            this.Controls.Add(this.tableLayoutPanelComment);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(0, 60);
            this.Name = "CommentCommon";
            this.Size = new System.Drawing.Size(517, 449);
            this.tableLayoutPanelComment.ResumeLayout(false);
            this.tableLayoutPanelComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.tableLayoutPanelInfo.ResumeLayout(false);
            this.tableLayoutPanelInfo.PerformLayout();
            this.panelActionTaskBar.ResumeLayout(false);
            this.tableLayoutPanelLikeCounter.ResumeLayout(false);
            this.tableLayoutPanelLikeCounter.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.panelInputComment.ResumeLayout(false);
            this.panelInputComment.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.containerCommon1.ResumeLayout(false);
            this.containerCommon1.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelComment;
        private AvatarCommon userAvatar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInfo;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        private System.Windows.Forms.Panel panelActionTaskBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLikeCounter;
        private System.Windows.Forms.Label labelTotalLikes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label labelLike;
        private System.Windows.Forms.Label labelReply;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Panel panelReplies;
        private System.Windows.Forms.Panel panelInputComment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label buttonAddPhoto;
        private ContainerCommon containerCommon1;
        private AutoSizeTextBox inputText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label labelSending;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPhotos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private AutoSizeTextBox inputTextToSpeech;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label labelTextToSpeechClear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelVoicePlayer;
    }
}
