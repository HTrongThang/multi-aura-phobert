namespace CustomControl.Commons
{
    partial class ConversationCommon
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelLastestTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelLastestMessage = new System.Windows.Forms.Label();
            this.labelConversationName = new System.Windows.Forms.Label();
            this.containerCommon1 = new CustomControl.Commons.ContainerCommon();
            this.conversationPhoto = new CustomControl.Commons.AvatarCommon();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.containerCommon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conversationPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelLastestTime, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(66, 6);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(228, 60);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelLastestTime
            // 
            this.labelLastestTime.AutoSize = true;
            this.labelLastestTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLastestTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLastestTime.Location = new System.Drawing.Point(198, 0);
            this.labelLastestTime.Margin = new System.Windows.Forms.Padding(0);
            this.labelLastestTime.Name = "labelLastestTime";
            this.labelLastestTime.Size = new System.Drawing.Size(30, 60);
            this.labelLastestTime.TabIndex = 0;
            this.labelLastestTime.Text = "•1w";
            this.labelLastestTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelLastestMessage, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelConversationName, 0, 0);
            this.tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(198, 60);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelLastestMessage
            // 
            this.labelLastestMessage.AutoEllipsis = true;
            this.labelLastestMessage.AutoSize = true;
            this.labelLastestMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLastestMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLastestMessage.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastestMessage.Location = new System.Drawing.Point(4, 30);
            this.labelLastestMessage.Margin = new System.Windows.Forms.Padding(0);
            this.labelLastestMessage.Name = "labelLastestMessage";
            this.labelLastestMessage.Size = new System.Drawing.Size(194, 30);
            this.labelLastestMessage.TabIndex = 2;
            this.labelLastestMessage.Text = "Lastest message";
            // 
            // labelConversationName
            // 
            this.labelConversationName.AutoEllipsis = true;
            this.labelConversationName.AutoSize = true;
            this.labelConversationName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelConversationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelConversationName.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConversationName.Location = new System.Drawing.Point(4, 0);
            this.labelConversationName.Margin = new System.Windows.Forms.Padding(0);
            this.labelConversationName.Name = "labelConversationName";
            this.labelConversationName.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labelConversationName.Size = new System.Drawing.Size(194, 30);
            this.labelConversationName.TabIndex = 1;
            this.labelConversationName.Text = "Name";
            // 
            // containerCommon1
            // 
            this.containerCommon1.Controls.Add(this.conversationPhoto);
            this.containerCommon1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.containerCommon1.Dock = System.Windows.Forms.DockStyle.Left;
            this.containerCommon1.Location = new System.Drawing.Point(6, 6);
            this.containerCommon1.Margin = new System.Windows.Forms.Padding(0);
            this.containerCommon1.Name = "containerCommon1";
            this.containerCommon1.Radius = 0;
            this.containerCommon1.Size = new System.Drawing.Size(60, 60);
            this.containerCommon1.TabIndex = 0;
            // 
            // conversationPhoto
            // 
            this.conversationPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.conversationPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conversationPhoto.Image = global::CustomControl.Properties.Resources._2773d8b41134ee880c2f2ba46fe02303;
            this.conversationPhoto.Location = new System.Drawing.Point(0, 0);
            this.conversationPhoto.Margin = new System.Windows.Forms.Padding(0);
            this.conversationPhoto.Name = "conversationPhoto";
            this.conversationPhoto.Size = new System.Drawing.Size(60, 60);
            this.conversationPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.conversationPhoto.TabIndex = 0;
            this.conversationPhoto.TabStop = false;
            // 
            // ConversationCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.containerCommon1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(0, 72);
            this.Name = "ConversationCommon";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(300, 72);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.containerCommon1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.conversationPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ContainerCommon containerCommon1;
        private AvatarCommon conversationPhoto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelLastestTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelConversationName;
        private System.Windows.Forms.Label labelLastestMessage;
    }
}
