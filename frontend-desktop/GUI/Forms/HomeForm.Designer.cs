namespace GUI.Forms
{
    partial class HomeForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSuggests = new System.Windows.Forms.Panel();
            this.suggestForYouCommon1 = new CustomControl.Commons.SuggestForYouCommon();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelPosts = new System.Windows.Forms.Panel();
            this.NotFoundContainer = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.flowLayoutPanelFriends = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSuggests.SuspendLayout();
            this.panel1.SuspendLayout();
            this.NotFoundContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuggests
            // 
            this.panelSuggests.BackColor = System.Drawing.Color.Transparent;
            this.panelSuggests.Controls.Add(this.suggestForYouCommon1);
            this.panelSuggests.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSuggests.Location = new System.Drawing.Point(603, 0);
            this.panelSuggests.Margin = new System.Windows.Forms.Padding(0);
            this.panelSuggests.Name = "panelSuggests";
            this.panelSuggests.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this.panelSuggests.Size = new System.Drawing.Size(320, 511);
            this.panelSuggests.TabIndex = 2;
            // 
            // suggestForYouCommon1
            // 
            this.suggestForYouCommon1.BackColor = System.Drawing.Color.Transparent;
            this.suggestForYouCommon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suggestForYouCommon1.Location = new System.Drawing.Point(0, 80);
            this.suggestForYouCommon1.Margin = new System.Windows.Forms.Padding(0);
            this.suggestForYouCommon1.Name = "suggestForYouCommon1";
            this.suggestForYouCommon1.Size = new System.Drawing.Size(320, 431);
            this.suggestForYouCommon1.TabIndex = 0;
            this.suggestForYouCommon1.UserSummaries = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panelPosts);
            this.panel1.Controls.Add(this.NotFoundContainer);
            this.panel1.Controls.Add(this.panelProfile);
            this.panel1.Controls.Add(this.flowLayoutPanelFriends);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.panel1.Size = new System.Drawing.Size(603, 511);
            this.panel1.TabIndex = 3;
            // 
            // panelPosts
            // 
            this.panelPosts.AutoScroll = true;
            this.panelPosts.BackColor = System.Drawing.Color.Transparent;
            this.panelPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPosts.Location = new System.Drawing.Point(0, 222);
            this.panelPosts.Margin = new System.Windows.Forms.Padding(0);
            this.panelPosts.Name = "panelPosts";
            this.panelPosts.Padding = new System.Windows.Forms.Padding(20, 20, 40, 20);
            this.panelPosts.Size = new System.Drawing.Size(563, 289);
            this.panelPosts.TabIndex = 13;
            // 
            // NotFoundContainer
            // 
            this.NotFoundContainer.ColumnCount = 1;
            this.NotFoundContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.NotFoundContainer.Controls.Add(this.label1, 0, 0);
            this.NotFoundContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.NotFoundContainer.Location = new System.Drawing.Point(0, 188);
            this.NotFoundContainer.Margin = new System.Windows.Forms.Padding(0);
            this.NotFoundContainer.Name = "NotFoundContainer";
            this.NotFoundContainer.RowCount = 1;
            this.NotFoundContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.NotFoundContainer.Size = new System.Drawing.Size(563, 34);
            this.NotFoundContainer.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 34);
            this.label1.TabIndex = 7;
            this.label1.Text = "Not found";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelProfile
            // 
            this.panelProfile.BackColor = System.Drawing.Color.Transparent;
            this.panelProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProfile.Location = new System.Drawing.Point(0, 88);
            this.panelProfile.Margin = new System.Windows.Forms.Padding(0);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(563, 100);
            this.panelProfile.TabIndex = 1;
            // 
            // flowLayoutPanelFriends
            // 
            this.flowLayoutPanelFriends.AutoScroll = true;
            this.flowLayoutPanelFriends.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelFriends.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelFriends.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelFriends.Name = "flowLayoutPanelFriends";
            this.flowLayoutPanelFriends.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.flowLayoutPanelFriends.Size = new System.Drawing.Size(563, 88);
            this.flowLayoutPanelFriends.TabIndex = 0;
            this.flowLayoutPanelFriends.WrapContents = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(923, 511);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSuggests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.panelSuggests.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.NotFoundContainer.ResumeLayout(false);
            this.NotFoundContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuggests;
        private CustomControl.Commons.SuggestForYouCommon suggestForYouCommon1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFriends;
        private CustomControl.Commons.PostCommon postCommon2;
        private CustomControl.Commons.PostCommon postCommon1;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Panel panelPosts;
        private System.Windows.Forms.TableLayoutPanel NotFoundContainer;
        private System.Windows.Forms.Label label1;
    }
}