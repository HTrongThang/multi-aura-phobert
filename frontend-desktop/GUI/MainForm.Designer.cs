namespace GUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.panelSideBarItems = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAvatar = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAppName = new System.Windows.Forms.Label();
            this.panelWindownControlTaskBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.MaximizeWindowControlButton = new System.Windows.Forms.Button();
            this.MinimizeWindowControlButton = new System.Windows.Forms.Button();
            this.CloseWindowControlButton = new System.Windows.Forms.Button();
            this.taskBarLogOut = new System.Windows.Forms.Button();
            this.userAvatar = new CustomControl.Commons.AvatarCommon();
            this.taskBarCreatePost = new System.Windows.Forms.Button();
            this.taskBarProfile = new System.Windows.Forms.Button();
            this.taskBarNotifications = new System.Windows.Forms.Button();
            this.taskBarMessages = new System.Windows.Forms.Button();
            this.taskBarExplore = new System.Windows.Forms.Button();
            this.taskBarHome = new System.Windows.Forms.Button();
            this.panelSideBar.SuspendLayout();
            this.panelSideBarItems.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelAvatar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelWindownControlTaskBar.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.Color.Transparent;
            this.panelSideBar.Controls.Add(this.panelSideBarItems);
            this.panelSideBar.Controls.Add(this.panel3);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Location = new System.Drawing.Point(4, 4);
            this.panelSideBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(220, 792);
            this.panelSideBar.TabIndex = 0;
            // 
            // panelSideBarItems
            // 
            this.panelSideBarItems.BackColor = System.Drawing.Color.Transparent;
            this.panelSideBarItems.Controls.Add(this.taskBarLogOut);
            this.panelSideBarItems.Controls.Add(this.panel1);
            this.panelSideBarItems.Controls.Add(this.taskBarProfile);
            this.panelSideBarItems.Controls.Add(this.taskBarNotifications);
            this.panelSideBarItems.Controls.Add(this.taskBarMessages);
            this.panelSideBarItems.Controls.Add(this.taskBarExplore);
            this.panelSideBarItems.Controls.Add(this.taskBarHome);
            this.panelSideBarItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSideBarItems.Location = new System.Drawing.Point(0, 58);
            this.panelSideBarItems.Margin = new System.Windows.Forms.Padding(0);
            this.panelSideBarItems.Name = "panelSideBarItems";
            this.panelSideBarItems.Size = new System.Drawing.Size(220, 734);
            this.panelSideBarItems.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelAvatar);
            this.panel1.Controls.Add(this.taskBarCreatePost);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 674);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 60);
            this.panel1.TabIndex = 8;
            // 
            // panelAvatar
            // 
            this.panelAvatar.Controls.Add(this.userAvatar);
            this.panelAvatar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAvatar.Location = new System.Drawing.Point(0, 0);
            this.panelAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.panelAvatar.MaximumSize = new System.Drawing.Size(60, 60);
            this.panelAvatar.MinimumSize = new System.Drawing.Size(60, 60);
            this.panelAvatar.Name = "panelAvatar";
            this.panelAvatar.Padding = new System.Windows.Forms.Padding(10);
            this.panelAvatar.Size = new System.Drawing.Size(60, 60);
            this.panelAvatar.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 58);
            this.panel3.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelAppName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelAppName
            // 
            this.labelAppName.AutoSize = true;
            this.labelAppName.BackColor = System.Drawing.Color.Transparent;
            this.labelAppName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAppName.Font = new System.Drawing.Font("iCiel Cadena", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppName.ForeColor = System.Drawing.Color.White;
            this.labelAppName.Location = new System.Drawing.Point(0, 0);
            this.labelAppName.Margin = new System.Windows.Forms.Padding(0);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelAppName.Size = new System.Drawing.Size(220, 58);
            this.labelAppName.TabIndex = 1;
            this.labelAppName.Text = "Multi Aura";
            this.labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelWindownControlTaskBar
            // 
            this.panelWindownControlTaskBar.BackColor = System.Drawing.Color.Transparent;
            this.panelWindownControlTaskBar.Controls.Add(this.tableLayoutPanel2);
            this.panelWindownControlTaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWindownControlTaskBar.Location = new System.Drawing.Point(224, 4);
            this.panelWindownControlTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelWindownControlTaskBar.Name = "panelWindownControlTaskBar";
            this.panelWindownControlTaskBar.Size = new System.Drawing.Size(1232, 35);
            this.panelWindownControlTaskBar.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.MaximizeWindowControlButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.MinimizeWindowControlButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CloseWindowControlButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1132, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(100, 35);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.Transparent;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(224, 39);
            this.panelDesktop.Margin = new System.Windows.Forms.Padding(0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1232, 757);
            this.panelDesktop.TabIndex = 2;
            // 
            // MaximizeWindowControlButton
            // 
            this.MaximizeWindowControlButton.BackColor = System.Drawing.Color.Transparent;
            this.MaximizeWindowControlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaximizeWindowControlButton.FlatAppearance.BorderSize = 0;
            this.MaximizeWindowControlButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.MaximizeWindowControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeWindowControlButton.Image = ((System.Drawing.Image)(resources.GetObject("MaximizeWindowControlButton.Image")));
            this.MaximizeWindowControlButton.Location = new System.Drawing.Point(33, 0);
            this.MaximizeWindowControlButton.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeWindowControlButton.Name = "MaximizeWindowControlButton";
            this.MaximizeWindowControlButton.Size = new System.Drawing.Size(33, 35);
            this.MaximizeWindowControlButton.TabIndex = 4;
            this.MaximizeWindowControlButton.UseVisualStyleBackColor = false;
            // 
            // MinimizeWindowControlButton
            // 
            this.MinimizeWindowControlButton.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeWindowControlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MinimizeWindowControlButton.FlatAppearance.BorderSize = 0;
            this.MinimizeWindowControlButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.MinimizeWindowControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeWindowControlButton.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeWindowControlButton.Image")));
            this.MinimizeWindowControlButton.Location = new System.Drawing.Point(0, 0);
            this.MinimizeWindowControlButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeWindowControlButton.Name = "MinimizeWindowControlButton";
            this.MinimizeWindowControlButton.Size = new System.Drawing.Size(33, 35);
            this.MinimizeWindowControlButton.TabIndex = 3;
            this.MinimizeWindowControlButton.UseVisualStyleBackColor = false;
            // 
            // CloseWindowControlButton
            // 
            this.CloseWindowControlButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseWindowControlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CloseWindowControlButton.FlatAppearance.BorderSize = 0;
            this.CloseWindowControlButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.CloseWindowControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseWindowControlButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseWindowControlButton.Image")));
            this.CloseWindowControlButton.Location = new System.Drawing.Point(66, 0);
            this.CloseWindowControlButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseWindowControlButton.Name = "CloseWindowControlButton";
            this.CloseWindowControlButton.Size = new System.Drawing.Size(34, 35);
            this.CloseWindowControlButton.TabIndex = 2;
            this.CloseWindowControlButton.UseVisualStyleBackColor = false;
            // 
            // taskBarLogOut
            // 
            this.taskBarLogOut.BackColor = System.Drawing.Color.Transparent;
            this.taskBarLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskBarLogOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.taskBarLogOut.FlatAppearance.BorderSize = 0;
            this.taskBarLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.taskBarLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskBarLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskBarLogOut.ForeColor = System.Drawing.Color.White;
            this.taskBarLogOut.Image = global::GUI.Properties.Resources.log_out;
            this.taskBarLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarLogOut.Location = new System.Drawing.Point(0, 637);
            this.taskBarLogOut.Margin = new System.Windows.Forms.Padding(0);
            this.taskBarLogOut.Name = "taskBarLogOut";
            this.taskBarLogOut.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.taskBarLogOut.Size = new System.Drawing.Size(220, 37);
            this.taskBarLogOut.TabIndex = 9;
            this.taskBarLogOut.Text = "        Log Out";
            this.taskBarLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarLogOut.UseVisualStyleBackColor = false;
            // 
            // userAvatar
            // 
            this.userAvatar.CurrentUser = null;
            this.userAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userAvatar.Image = global::GUI.Properties.Resources.person;
            this.userAvatar.Location = new System.Drawing.Point(10, 10);
            this.userAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.Size = new System.Drawing.Size(40, 40);
            this.userAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userAvatar.TabIndex = 10;
            this.userAvatar.TabStop = false;
            // 
            // taskBarCreatePost
            // 
            this.taskBarCreatePost.BackColor = System.Drawing.Color.Transparent;
            this.taskBarCreatePost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskBarCreatePost.Dock = System.Windows.Forms.DockStyle.Right;
            this.taskBarCreatePost.FlatAppearance.BorderSize = 0;
            this.taskBarCreatePost.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.taskBarCreatePost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskBarCreatePost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskBarCreatePost.ForeColor = System.Drawing.Color.White;
            this.taskBarCreatePost.Image = ((System.Drawing.Image)(resources.GetObject("taskBarCreatePost.Image")));
            this.taskBarCreatePost.Location = new System.Drawing.Point(160, 0);
            this.taskBarCreatePost.Margin = new System.Windows.Forms.Padding(0);
            this.taskBarCreatePost.Name = "taskBarCreatePost";
            this.taskBarCreatePost.Size = new System.Drawing.Size(60, 60);
            this.taskBarCreatePost.TabIndex = 8;
            this.taskBarCreatePost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarCreatePost.UseVisualStyleBackColor = false;
            // 
            // taskBarProfile
            // 
            this.taskBarProfile.BackColor = System.Drawing.Color.Transparent;
            this.taskBarProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskBarProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.taskBarProfile.FlatAppearance.BorderSize = 0;
            this.taskBarProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.taskBarProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskBarProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskBarProfile.ForeColor = System.Drawing.Color.White;
            this.taskBarProfile.Image = ((System.Drawing.Image)(resources.GetObject("taskBarProfile.Image")));
            this.taskBarProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarProfile.Location = new System.Drawing.Point(0, 240);
            this.taskBarProfile.Margin = new System.Windows.Forms.Padding(0);
            this.taskBarProfile.Name = "taskBarProfile";
            this.taskBarProfile.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.taskBarProfile.Size = new System.Drawing.Size(220, 60);
            this.taskBarProfile.TabIndex = 6;
            this.taskBarProfile.Text = "        Profile";
            this.taskBarProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarProfile.UseVisualStyleBackColor = false;
            // 
            // taskBarNotifications
            // 
            this.taskBarNotifications.BackColor = System.Drawing.Color.Transparent;
            this.taskBarNotifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskBarNotifications.Dock = System.Windows.Forms.DockStyle.Top;
            this.taskBarNotifications.FlatAppearance.BorderSize = 0;
            this.taskBarNotifications.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.taskBarNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskBarNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskBarNotifications.ForeColor = System.Drawing.Color.White;
            this.taskBarNotifications.Image = ((System.Drawing.Image)(resources.GetObject("taskBarNotifications.Image")));
            this.taskBarNotifications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarNotifications.Location = new System.Drawing.Point(0, 180);
            this.taskBarNotifications.Margin = new System.Windows.Forms.Padding(0);
            this.taskBarNotifications.Name = "taskBarNotifications";
            this.taskBarNotifications.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.taskBarNotifications.Size = new System.Drawing.Size(220, 60);
            this.taskBarNotifications.TabIndex = 5;
            this.taskBarNotifications.Text = "        Notifications";
            this.taskBarNotifications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarNotifications.UseVisualStyleBackColor = false;
            // 
            // taskBarMessages
            // 
            this.taskBarMessages.BackColor = System.Drawing.Color.Transparent;
            this.taskBarMessages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskBarMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.taskBarMessages.FlatAppearance.BorderSize = 0;
            this.taskBarMessages.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.taskBarMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskBarMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskBarMessages.ForeColor = System.Drawing.Color.White;
            this.taskBarMessages.Image = ((System.Drawing.Image)(resources.GetObject("taskBarMessages.Image")));
            this.taskBarMessages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarMessages.Location = new System.Drawing.Point(0, 120);
            this.taskBarMessages.Margin = new System.Windows.Forms.Padding(0);
            this.taskBarMessages.Name = "taskBarMessages";
            this.taskBarMessages.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.taskBarMessages.Size = new System.Drawing.Size(220, 60);
            this.taskBarMessages.TabIndex = 4;
            this.taskBarMessages.Text = "        Messages";
            this.taskBarMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarMessages.UseVisualStyleBackColor = false;
            // 
            // taskBarExplore
            // 
            this.taskBarExplore.BackColor = System.Drawing.Color.Transparent;
            this.taskBarExplore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskBarExplore.Dock = System.Windows.Forms.DockStyle.Top;
            this.taskBarExplore.FlatAppearance.BorderSize = 0;
            this.taskBarExplore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.taskBarExplore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskBarExplore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskBarExplore.ForeColor = System.Drawing.Color.White;
            this.taskBarExplore.Image = ((System.Drawing.Image)(resources.GetObject("taskBarExplore.Image")));
            this.taskBarExplore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarExplore.Location = new System.Drawing.Point(0, 60);
            this.taskBarExplore.Margin = new System.Windows.Forms.Padding(0);
            this.taskBarExplore.Name = "taskBarExplore";
            this.taskBarExplore.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.taskBarExplore.Size = new System.Drawing.Size(220, 60);
            this.taskBarExplore.TabIndex = 3;
            this.taskBarExplore.Text = "        Explore";
            this.taskBarExplore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarExplore.UseVisualStyleBackColor = false;
            // 
            // taskBarHome
            // 
            this.taskBarHome.BackColor = System.Drawing.Color.Transparent;
            this.taskBarHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskBarHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.taskBarHome.FlatAppearance.BorderSize = 0;
            this.taskBarHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.taskBarHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskBarHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskBarHome.ForeColor = System.Drawing.Color.White;
            this.taskBarHome.Image = ((System.Drawing.Image)(resources.GetObject("taskBarHome.Image")));
            this.taskBarHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarHome.Location = new System.Drawing.Point(0, 0);
            this.taskBarHome.Margin = new System.Windows.Forms.Padding(0);
            this.taskBarHome.Name = "taskBarHome";
            this.taskBarHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.taskBarHome.Size = new System.Drawing.Size(220, 60);
            this.taskBarHome.TabIndex = 2;
            this.taskBarHome.Text = "        Home";
            this.taskBarHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskBarHome.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1460, 800);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelWindownControlTaskBar);
            this.Controls.Add(this.panelSideBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panelSideBar.ResumeLayout(false);
            this.panelSideBarItems.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelAvatar.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelWindownControlTaskBar.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Panel panelWindownControlTaskBar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button taskBarHome;
        private System.Windows.Forms.Panel panelSideBarItems;
        private System.Windows.Forms.Button taskBarNotifications;
        private System.Windows.Forms.Button taskBarMessages;
        private System.Windows.Forms.Button taskBarExplore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button CloseWindowControlButton;
        private System.Windows.Forms.Button MaximizeWindowControlButton;
        private System.Windows.Forms.Button MinimizeWindowControlButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button taskBarCreatePost;
        private System.Windows.Forms.Panel panelAvatar;
        private CustomControl.Commons.AvatarCommon userAvatar;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button taskBarProfile;
        private System.Windows.Forms.Button taskBarLogOut;
    }
}