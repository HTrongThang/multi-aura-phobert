namespace GUI.Forms
{
    partial class ProfileForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSettings = new System.Windows.Forms.Label();
            this.userAvatar = new CustomControl.Commons.AvatarCommon();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFullName = new System.Windows.Forms.Label();
            this.containerCommonEditProfile = new CustomControl.Commons.ContainerCommon();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFriendCounter = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFollowingCounter = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFollowerCounter = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPostCounter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelProfileTaskBar = new System.Windows.Forms.TableLayoutPanel();
            this.labelMore = new System.Windows.Forms.Label();
            this.labelFriends = new System.Windows.Forms.Label();
            this.labelMedias = new System.Windows.Forms.Label();
            this.labelPosts = new System.Windows.Forms.Label();
            this.searchBarContainer = new System.Windows.Forms.Panel();
            this.NotFoundContainer = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMore = new System.Windows.Forms.Panel();
            this.panelBlockedList = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelFriends = new System.Windows.Forms.Panel();
            this.panelPosts = new System.Windows.Forms.Panel();
            this.panelMedias = new System.Windows.Forms.FlowLayoutPanel();
            this.LoadingContainer = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.containerCommonEditProfile.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanelProfileTaskBar.SuspendLayout();
            this.NotFoundContainer.SuspendLayout();
            this.panelMore.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.LoadingContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSettings, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.userAvatar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(60, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 150);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(907, 190);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = global::GUI.Properties.Resources.setting;
            this.buttonSettings.Location = new System.Drawing.Point(834, 20);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSettings.MaximumSize = new System.Drawing.Size(36, 32);
            this.buttonSettings.MinimumSize = new System.Drawing.Size(36, 32);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(36, 32);
            this.buttonSettings.TabIndex = 0;
            // 
            // userAvatar
            // 
            this.userAvatar.CurrentUser = null;
            this.userAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userAvatar.Image = global::GUI.Properties.Resources.profile;
            this.userAvatar.Location = new System.Drawing.Point(20, 20);
            this.userAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.userAvatar.MaximumSize = new System.Drawing.Size(118, 96);
            this.userAvatar.MinimumSize = new System.Drawing.Size(118, 96);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.Size = new System.Drawing.Size(118, 96);
            this.userAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userAvatar.TabIndex = 0;
            this.userAvatar.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labelUsername, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(190, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(644, 150);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(60, 40);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(584, 40);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Unknown";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.06338F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.93662F));
            this.tableLayoutPanel3.Controls.Add(this.labelFullName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.containerCommonEditProfile, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(60, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(584, 40);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.BackColor = System.Drawing.Color.Transparent;
            this.labelFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.ForeColor = System.Drawing.Color.White;
            this.labelFullName.Location = new System.Drawing.Point(0, 0);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(426, 40);
            this.labelFullName.TabIndex = 2;
            this.labelFullName.Text = "Unknown";
            this.labelFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // containerCommonEditProfile
            // 
            this.containerCommonEditProfile.BackColor = System.Drawing.Color.DimGray;
            this.containerCommonEditProfile.Controls.Add(this.buttonEditProfile);
            this.containerCommonEditProfile.Location = new System.Drawing.Point(429, 2);
            this.containerCommonEditProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.containerCommonEditProfile.Name = "containerCommonEditProfile";
            this.containerCommonEditProfile.Radius = 4;
            this.containerCommonEditProfile.Size = new System.Drawing.Size(146, 35);
            this.containerCommonEditProfile.TabIndex = 3;
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditProfile.FlatAppearance.BorderSize = 0;
            this.buttonEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditProfile.ForeColor = System.Drawing.Color.White;
            this.buttonEditProfile.Location = new System.Drawing.Point(0, 0);
            this.buttonEditProfile.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(146, 35);
            this.buttonEditProfile.TabIndex = 0;
            this.buttonEditProfile.Text = "Edit";
            this.buttonEditProfile.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel7);
            this.panel1.Controls.Add(this.tableLayoutPanel6);
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(60, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 40);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.labelFriendCounter, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(325, 0);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(98, 40);
            this.tableLayoutPanel7.TabIndex = 8;
            // 
            // labelFriendCounter
            // 
            this.labelFriendCounter.AutoSize = true;
            this.labelFriendCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelFriendCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFriendCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFriendCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendCounter.ForeColor = System.Drawing.Color.White;
            this.labelFriendCounter.Location = new System.Drawing.Point(0, 0);
            this.labelFriendCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelFriendCounter.Name = "labelFriendCounter";
            this.labelFriendCounter.Size = new System.Drawing.Size(78, 40);
            this.labelFriendCounter.TabIndex = 4;
            this.labelFriendCounter.Text = "0 Friends";
            this.labelFriendCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.labelFollowingCounter, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(202, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(123, 40);
            this.tableLayoutPanel6.TabIndex = 7;
            // 
            // labelFollowingCounter
            // 
            this.labelFollowingCounter.AutoSize = true;
            this.labelFollowingCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelFollowingCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFollowingCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFollowingCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFollowingCounter.ForeColor = System.Drawing.Color.White;
            this.labelFollowingCounter.Location = new System.Drawing.Point(0, 0);
            this.labelFollowingCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelFollowingCounter.Name = "labelFollowingCounter";
            this.labelFollowingCounter.Size = new System.Drawing.Size(103, 40);
            this.labelFollowingCounter.TabIndex = 4;
            this.labelFollowingCounter.Text = "0 Followings";
            this.labelFollowingCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.labelFollowerCounter, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(86, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(116, 40);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // labelFollowerCounter
            // 
            this.labelFollowerCounter.AutoSize = true;
            this.labelFollowerCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelFollowerCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFollowerCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFollowerCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFollowerCounter.ForeColor = System.Drawing.Color.White;
            this.labelFollowerCounter.Location = new System.Drawing.Point(0, 0);
            this.labelFollowerCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelFollowerCounter.Name = "labelFollowerCounter";
            this.labelFollowerCounter.Size = new System.Drawing.Size(96, 40);
            this.labelFollowerCounter.TabIndex = 4;
            this.labelFollowerCounter.Text = "0 Followers";
            this.labelFollowerCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.labelPostCounter, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(86, 40);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // labelPostCounter
            // 
            this.labelPostCounter.AutoSize = true;
            this.labelPostCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelPostCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPostCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPostCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostCounter.ForeColor = System.Drawing.Color.White;
            this.labelPostCounter.Location = new System.Drawing.Point(0, 0);
            this.labelPostCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelPostCounter.Name = "labelPostCounter";
            this.labelPostCounter.Size = new System.Drawing.Size(66, 40);
            this.labelPostCounter.TabIndex = 4;
            this.labelPostCounter.Text = "0 Posts";
            this.labelPostCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.tableLayoutPanelProfileTaskBar);
            this.panel2.Controls.Add(this.searchBarContainer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(60, 190);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.panel2.Size = new System.Drawing.Size(907, 76);
            this.panel2.TabIndex = 8;
            // 
            // tableLayoutPanelProfileTaskBar
            // 
            this.tableLayoutPanelProfileTaskBar.ColumnCount = 4;
            this.tableLayoutPanelProfileTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelProfileTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelProfileTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelProfileTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelProfileTaskBar.Controls.Add(this.labelMore, 3, 0);
            this.tableLayoutPanelProfileTaskBar.Controls.Add(this.labelFriends, 2, 0);
            this.tableLayoutPanelProfileTaskBar.Controls.Add(this.labelMedias, 1, 0);
            this.tableLayoutPanelProfileTaskBar.Controls.Add(this.labelPosts, 0, 0);
            this.tableLayoutPanelProfileTaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelProfileTaskBar.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanelProfileTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelProfileTaskBar.Name = "tableLayoutPanelProfileTaskBar";
            this.tableLayoutPanelProfileTaskBar.RowCount = 1;
            this.tableLayoutPanelProfileTaskBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProfileTaskBar.Size = new System.Drawing.Size(867, 37);
            this.tableLayoutPanelProfileTaskBar.TabIndex = 24;
            // 
            // labelMore
            // 
            this.labelMore.AutoSize = true;
            this.labelMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMore.ForeColor = System.Drawing.Color.White;
            this.labelMore.Image = global::GUI.Properties.Resources.vertical_more24;
            this.labelMore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelMore.Location = new System.Drawing.Point(648, 0);
            this.labelMore.Margin = new System.Windows.Forms.Padding(0);
            this.labelMore.Name = "labelMore";
            this.labelMore.Size = new System.Drawing.Size(219, 37);
            this.labelMore.TabIndex = 5;
            this.labelMore.Text = "More";
            this.labelMore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFriends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriends.ForeColor = System.Drawing.Color.White;
            this.labelFriends.Location = new System.Drawing.Point(432, 0);
            this.labelFriends.Margin = new System.Windows.Forms.Padding(0);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Size = new System.Drawing.Size(216, 37);
            this.labelFriends.TabIndex = 2;
            this.labelFriends.Text = "Friends";
            this.labelFriends.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMedias
            // 
            this.labelMedias.AutoSize = true;
            this.labelMedias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMedias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMedias.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMedias.ForeColor = System.Drawing.Color.White;
            this.labelMedias.Location = new System.Drawing.Point(216, 0);
            this.labelMedias.Margin = new System.Windows.Forms.Padding(0);
            this.labelMedias.Name = "labelMedias";
            this.labelMedias.Size = new System.Drawing.Size(216, 37);
            this.labelMedias.TabIndex = 1;
            this.labelMedias.Text = "Medias";
            this.labelMedias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPosts
            // 
            this.labelPosts.AutoSize = true;
            this.labelPosts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosts.ForeColor = System.Drawing.Color.White;
            this.labelPosts.Location = new System.Drawing.Point(0, 0);
            this.labelPosts.Margin = new System.Windows.Forms.Padding(0);
            this.labelPosts.Name = "labelPosts";
            this.labelPosts.Size = new System.Drawing.Size(216, 37);
            this.labelPosts.TabIndex = 0;
            this.labelPosts.Text = "Posts";
            this.labelPosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchBarContainer
            // 
            this.searchBarContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBarContainer.Location = new System.Drawing.Point(0, 0);
            this.searchBarContainer.Margin = new System.Windows.Forms.Padding(0);
            this.searchBarContainer.Name = "searchBarContainer";
            this.searchBarContainer.Size = new System.Drawing.Size(867, 39);
            this.searchBarContainer.TabIndex = 23;
            // 
            // NotFoundContainer
            // 
            this.NotFoundContainer.ColumnCount = 1;
            this.NotFoundContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.NotFoundContainer.Controls.Add(this.label1, 0, 0);
            this.NotFoundContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.NotFoundContainer.Location = new System.Drawing.Point(60, 266);
            this.NotFoundContainer.Margin = new System.Windows.Forms.Padding(0);
            this.NotFoundContainer.Name = "NotFoundContainer";
            this.NotFoundContainer.RowCount = 1;
            this.NotFoundContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.NotFoundContainer.Size = new System.Drawing.Size(907, 27);
            this.NotFoundContainer.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(907, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "Not found";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMore
            // 
            this.panelMore.AutoSize = true;
            this.panelMore.BackColor = System.Drawing.Color.Transparent;
            this.panelMore.Controls.Add(this.panelBlockedList);
            this.panelMore.Controls.Add(this.tableLayoutPanel8);
            this.panelMore.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMore.Location = new System.Drawing.Point(60, 437);
            this.panelMore.Margin = new System.Windows.Forms.Padding(0);
            this.panelMore.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelMore.Name = "panelMore";
            this.panelMore.Size = new System.Drawing.Size(907, 54);
            this.panelMore.TabIndex = 38;
            // 
            // panelBlockedList
            // 
            this.panelBlockedList.AutoSize = true;
            this.panelBlockedList.BackColor = System.Drawing.Color.Transparent;
            this.panelBlockedList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBlockedList.Location = new System.Drawing.Point(0, 16);
            this.panelBlockedList.Margin = new System.Windows.Forms.Padding(0);
            this.panelBlockedList.MinimumSize = new System.Drawing.Size(0, 38);
            this.panelBlockedList.Name = "panelBlockedList";
            this.panelBlockedList.Size = new System.Drawing.Size(907, 38);
            this.panelBlockedList.TabIndex = 43;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(907, 16);
            this.tableLayoutPanel8.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Blocked list";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFriends
            // 
            this.panelFriends.AutoSize = true;
            this.panelFriends.BackColor = System.Drawing.Color.Transparent;
            this.panelFriends.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFriends.Location = new System.Drawing.Point(60, 389);
            this.panelFriends.Margin = new System.Windows.Forms.Padding(0);
            this.panelFriends.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelFriends.Name = "panelFriends";
            this.panelFriends.Size = new System.Drawing.Size(907, 48);
            this.panelFriends.TabIndex = 37;
            // 
            // panelPosts
            // 
            this.panelPosts.AutoSize = true;
            this.panelPosts.BackColor = System.Drawing.Color.Transparent;
            this.panelPosts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPosts.Location = new System.Drawing.Point(60, 341);
            this.panelPosts.Margin = new System.Windows.Forms.Padding(0);
            this.panelPosts.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelPosts.Name = "panelPosts";
            this.panelPosts.Size = new System.Drawing.Size(907, 48);
            this.panelPosts.TabIndex = 36;
            // 
            // panelMedias
            // 
            this.panelMedias.AutoSize = true;
            this.panelMedias.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMedias.Location = new System.Drawing.Point(60, 293);
            this.panelMedias.Margin = new System.Windows.Forms.Padding(0);
            this.panelMedias.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelMedias.Name = "panelMedias";
            this.panelMedias.Padding = new System.Windows.Forms.Padding(0, 16, 0, 16);
            this.panelMedias.Size = new System.Drawing.Size(907, 48);
            this.panelMedias.TabIndex = 35;
            // 
            // LoadingContainer
            // 
            this.LoadingContainer.ColumnCount = 1;
            this.LoadingContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LoadingContainer.Controls.Add(this.label2, 0, 0);
            this.LoadingContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoadingContainer.Location = new System.Drawing.Point(60, 491);
            this.LoadingContainer.Margin = new System.Windows.Forms.Padding(0);
            this.LoadingContainer.Name = "LoadingContainer";
            this.LoadingContainer.RowCount = 1;
            this.LoadingContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LoadingContainer.Size = new System.Drawing.Size(907, 22);
            this.LoadingContainer.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(907, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Loading...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1027, 636);
            this.Controls.Add(this.LoadingContainer);
            this.Controls.Add(this.panelMore);
            this.Controls.Add(this.panelFriends);
            this.Controls.Add(this.panelPosts);
            this.Controls.Add(this.panelMedias);
            this.Controls.Add(this.NotFoundContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProfileForm";
            this.Padding = new System.Windows.Forms.Padding(60, 0, 60, 0);
            this.Text = "ProfileForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.containerCommonEditProfile.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanelProfileTaskBar.ResumeLayout(false);
            this.tableLayoutPanelProfileTaskBar.PerformLayout();
            this.NotFoundContainer.ResumeLayout(false);
            this.NotFoundContainer.PerformLayout();
            this.panelMore.ResumeLayout(false);
            this.panelMore.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.LoadingContainer.ResumeLayout(false);
            this.LoadingContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControl.Commons.AvatarCommon userAvatar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label buttonSettings;
        private CustomControl.Commons.ContainerCommon containerCommonEditProfile;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label labelFriendCounter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label labelFollowingCounter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelFollowerCounter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelPostCounter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProfileTaskBar;
        private System.Windows.Forms.Label labelFriends;
        private System.Windows.Forms.Label labelMedias;
        private System.Windows.Forms.Label labelPosts;
        private System.Windows.Forms.Panel searchBarContainer;
        private System.Windows.Forms.Label labelMore;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.TableLayoutPanel NotFoundContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMore;
        private System.Windows.Forms.Panel panelFriends;
        private System.Windows.Forms.Panel panelPosts;
        private System.Windows.Forms.FlowLayoutPanel panelMedias;
        private System.Windows.Forms.TableLayoutPanel LoadingContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelBlockedList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label3;
    }
}