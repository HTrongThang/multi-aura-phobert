namespace GUI.Forms
{
    partial class MessagesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessagesForm));
            this.tableLayoutPanelMessages = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelConversations = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.searchBarContainer = new System.Windows.Forms.Panel();
            this.searchBar = new CustomControl.Commons.SearchBarCommon();
            this.tableLayoutPanelConversationHeader = new System.Windows.Forms.TableLayoutPanel();
            this.labelConversationHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMessages = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelMessageSending = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.containerCommon1 = new CustomControl.Commons.ContainerCommon();
            this.inputMessage = new CustomControl.Commons.AutoSizeTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSending = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMoreAction = new System.Windows.Forms.Label();
            this.avatarCommon1 = new CustomControl.Commons.AvatarCommon();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMessageSettings = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMoreActionItems = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.avatarChat = new CustomControl.Commons.AvatarCommon();
            this.labelEdit = new System.Windows.Forms.Label();
            this.labelChatName = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanelMessages.SuspendLayout();
            this.panel1.SuspendLayout();
            this.searchBarContainer.SuspendLayout();
            this.tableLayoutPanelConversationHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMessages.SuspendLayout();
            this.panelMessageSending.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.containerCommon1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarCommon1)).BeginInit();
            this.panelMessageSettings.SuspendLayout();
            this.tableLayoutPanelMoreActionItems.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarChat)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMessages
            // 
            this.tableLayoutPanelMessages.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelMessages.ColumnCount = 3;
            this.tableLayoutPanelMessages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 405F));
            this.tableLayoutPanelMessages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMessages.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelMessages.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanelMessages.Controls.Add(this.panelMessageSettings, 2, 0);
            this.tableLayoutPanelMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMessages.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMessages.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMessages.Name = "tableLayoutPanelMessages";
            this.tableLayoutPanelMessages.RowCount = 1;
            this.tableLayoutPanelMessages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessages.Size = new System.Drawing.Size(1116, 690);
            this.tableLayoutPanelMessages.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelConversations);
            this.panel1.Controls.Add(this.tableLayoutPanel7);
            this.panel1.Controls.Add(this.searchBarContainer);
            this.panel1.Controls.Add(this.tableLayoutPanelConversationHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 690);
            this.panel1.TabIndex = 0;
            // 
            // panelConversations
            // 
            this.panelConversations.AutoScroll = true;
            this.panelConversations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConversations.Location = new System.Drawing.Point(0, 151);
            this.panelConversations.Margin = new System.Windows.Forms.Padding(0);
            this.panelConversations.Name = "panelConversations";
            this.panelConversations.Size = new System.Drawing.Size(405, 539);
            this.panelConversations.TabIndex = 5;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 123);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(405, 28);
            this.tableLayoutPanel7.TabIndex = 4;
            // 
            // searchBarContainer
            // 
            this.searchBarContainer.Controls.Add(this.searchBar);
            this.searchBarContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBarContainer.Location = new System.Drawing.Point(0, 75);
            this.searchBarContainer.Margin = new System.Windows.Forms.Padding(0);
            this.searchBarContainer.Name = "searchBarContainer";
            this.searchBarContainer.Size = new System.Drawing.Size(405, 48);
            this.searchBarContainer.TabIndex = 3;
            // 
            // searchBar
            // 
            this.searchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.searchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBar.Hint = "Search...";
            this.searchBar.Location = new System.Drawing.Point(0, 0);
            this.searchBar.Margin = new System.Windows.Forms.Padding(0);
            this.searchBar.MinimumSize = new System.Drawing.Size(248, 40);
            this.searchBar.Name = "searchBar";
            this.searchBar.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.searchBar.Query = "";
            this.searchBar.Size = new System.Drawing.Size(405, 48);
            this.searchBar.TabIndex = 0;
            // 
            // tableLayoutPanelConversationHeader
            // 
            this.tableLayoutPanelConversationHeader.ColumnCount = 2;
            this.tableLayoutPanelConversationHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConversationHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConversationHeader.Controls.Add(this.labelConversationHeader, 0, 0);
            this.tableLayoutPanelConversationHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelConversationHeader.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelConversationHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelConversationHeader.Name = "tableLayoutPanelConversationHeader";
            this.tableLayoutPanelConversationHeader.RowCount = 1;
            this.tableLayoutPanelConversationHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConversationHeader.Size = new System.Drawing.Size(405, 75);
            this.tableLayoutPanelConversationHeader.TabIndex = 2;
            // 
            // labelConversationHeader
            // 
            this.labelConversationHeader.AutoSize = true;
            this.labelConversationHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelConversationHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelConversationHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConversationHeader.ForeColor = System.Drawing.Color.White;
            this.labelConversationHeader.Location = new System.Drawing.Point(0, 0);
            this.labelConversationHeader.Margin = new System.Windows.Forms.Padding(0);
            this.labelConversationHeader.Name = "labelConversationHeader";
            this.labelConversationHeader.Size = new System.Drawing.Size(202, 75);
            this.labelConversationHeader.TabIndex = 0;
            this.labelConversationHeader.Text = "Messages";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panelMessages);
            this.panel2.Controls.Add(this.panelMessageSending);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(405, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 690);
            this.panel2.TabIndex = 1;
            // 
            // panelMessages
            // 
            this.panelMessages.AutoScroll = true;
            this.panelMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panelMessages.Controls.Add(this.panel4);
            this.panelMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessages.Location = new System.Drawing.Point(0, 75);
            this.panelMessages.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessages.Name = "panelMessages";
            this.panelMessages.Size = new System.Drawing.Size(396, 553);
            this.panelMessages.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(396, 24);
            this.panel4.TabIndex = 1;
            // 
            // panelMessageSending
            // 
            this.panelMessageSending.AutoSize = true;
            this.panelMessageSending.BackColor = System.Drawing.Color.Transparent;
            this.panelMessageSending.Controls.Add(this.tableLayoutPanel2);
            this.panelMessageSending.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMessageSending.Location = new System.Drawing.Point(0, 628);
            this.panelMessageSending.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageSending.MinimumSize = new System.Drawing.Size(531, 54);
            this.panelMessageSending.Name = "panelMessageSending";
            this.panelMessageSending.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panelMessageSending.Size = new System.Drawing.Size(531, 62);
            this.panelMessageSending.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.Controls.Add(this.containerCommon1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(11, 12);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(508, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(509, 38);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // containerCommon1
            // 
            this.containerCommon1.AutoSize = true;
            this.containerCommon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.containerCommon1.Controls.Add(this.inputMessage);
            this.containerCommon1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.containerCommon1.Location = new System.Drawing.Point(0, 0);
            this.containerCommon1.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.containerCommon1.MinimumSize = new System.Drawing.Size(465, 28);
            this.containerCommon1.Name = "containerCommon1";
            this.containerCommon1.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.containerCommon1.Radius = 6;
            this.containerCommon1.Size = new System.Drawing.Size(465, 38);
            this.containerCommon1.TabIndex = 4;
            // 
            // inputMessage
            // 
            this.inputMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.inputMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputMessage.ForeColor = System.Drawing.Color.White;
            this.inputMessage.Hint = "Aa, enter your text";
            this.inputMessage.Location = new System.Drawing.Point(7, 5);
            this.inputMessage.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.inputMessage.MaxLine = 10;
            this.inputMessage.MinimumSize = new System.Drawing.Size(465, 28);
            this.inputMessage.Multiline = true;
            this.inputMessage.Name = "inputMessage";
            this.inputMessage.Size = new System.Drawing.Size(465, 28);
            this.inputMessage.TabIndex = 5;
            this.inputMessage.Text = "Aa, enter your text";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.labelSending, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(473, 8);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.MinimumSize = new System.Drawing.Size(27, 30);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(36, 30);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // labelSending
            // 
            this.labelSending.AutoSize = true;
            this.labelSending.BackColor = System.Drawing.Color.Transparent;
            this.labelSending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSending.Image = global::GUI.Properties.Resources.sending;
            this.labelSending.Location = new System.Drawing.Point(4, 0);
            this.labelSending.Margin = new System.Windows.Forms.Padding(0);
            this.labelSending.MaximumSize = new System.Drawing.Size(27, 30);
            this.labelSending.MinimumSize = new System.Drawing.Size(27, 30);
            this.labelSending.Name = "labelSending";
            this.labelSending.Size = new System.Drawing.Size(27, 30);
            this.labelSending.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.Controls.Add(this.labelMoreAction, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.avatarCommon1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(396, 75);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelMoreAction
            // 
            this.labelMoreAction.AutoSize = true;
            this.labelMoreAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMoreAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoreAction.ForeColor = System.Drawing.Color.White;
            this.labelMoreAction.Image = global::GUI.Properties.Resources.vertical_more24;
            this.labelMoreAction.Location = new System.Drawing.Point(346, 20);
            this.labelMoreAction.Margin = new System.Windows.Forms.Padding(18, 20, 18, 20);
            this.labelMoreAction.Name = "labelMoreAction";
            this.labelMoreAction.Size = new System.Drawing.Size(32, 35);
            this.labelMoreAction.TabIndex = 2;
            this.labelMoreAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // avatarCommon1
            // 
            this.avatarCommon1.CurrentUser = null;
            this.avatarCommon1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatarCommon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avatarCommon1.Image = global::GUI.Properties.Resources._006833d62de3321b980cb2b6a46088a5;
            this.avatarCommon1.Location = new System.Drawing.Point(4, 5);
            this.avatarCommon1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.avatarCommon1.MaximumSize = new System.Drawing.Size(58, 65);
            this.avatarCommon1.MinimumSize = new System.Drawing.Size(58, 65);
            this.avatarCommon1.Name = "avatarCommon1";
            this.avatarCommon1.Size = new System.Drawing.Size(58, 65);
            this.avatarCommon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarCommon1.TabIndex = 0;
            this.avatarCommon1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(68, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(260, 75);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mthuw";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMessageSettings
            // 
            this.panelMessageSettings.Controls.Add(this.tableLayoutPanelMoreActionItems);
            this.panelMessageSettings.Controls.Add(this.tableLayoutPanel5);
            this.panelMessageSettings.Controls.Add(this.tableLayoutPanel4);
            this.panelMessageSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessageSettings.Location = new System.Drawing.Point(801, 0);
            this.panelMessageSettings.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageSettings.MinimumSize = new System.Drawing.Size(4, 0);
            this.panelMessageSettings.Name = "panelMessageSettings";
            this.panelMessageSettings.Size = new System.Drawing.Size(315, 690);
            this.panelMessageSettings.TabIndex = 2;
            // 
            // tableLayoutPanelMoreActionItems
            // 
            this.tableLayoutPanelMoreActionItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.tableLayoutPanelMoreActionItems.ColumnCount = 1;
            this.tableLayoutPanelMoreActionItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMoreActionItems.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanelMoreActionItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMoreActionItems.Location = new System.Drawing.Point(0, 200);
            this.tableLayoutPanelMoreActionItems.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMoreActionItems.Name = "tableLayoutPanelMoreActionItems";
            this.tableLayoutPanelMoreActionItems.RowCount = 3;
            this.tableLayoutPanelMoreActionItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMoreActionItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMoreActionItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelMoreActionItems.Size = new System.Drawing.Size(315, 490);
            this.tableLayoutPanelMoreActionItems.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(24)))), ((int)(((byte)(15)))));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(0, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(315, 50);
            this.label3.TabIndex = 0;
            this.label3.Text = "             Delete conversation";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelChatName, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 75);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(315, 125);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.avatarChat, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.labelEdit, 2, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 12);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(315, 62);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // avatarChat
            // 
            this.avatarChat.CurrentUser = null;
            this.avatarChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatarChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avatarChat.Image = global::GUI.Properties.Resources._006833d62de3321b980cb2b6a46088a5;
            this.avatarChat.Location = new System.Drawing.Point(129, 0);
            this.avatarChat.Margin = new System.Windows.Forms.Padding(0);
            this.avatarChat.MaximumSize = new System.Drawing.Size(56, 62);
            this.avatarChat.MinimumSize = new System.Drawing.Size(56, 62);
            this.avatarChat.Name = "avatarChat";
            this.avatarChat.Size = new System.Drawing.Size(56, 62);
            this.avatarChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarChat.TabIndex = 2;
            this.avatarChat.TabStop = false;
            // 
            // labelEdit
            // 
            this.labelEdit.AutoSize = true;
            this.labelEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelEdit.Image = global::GUI.Properties.Resources.edit16;
            this.labelEdit.Location = new System.Drawing.Point(185, 42);
            this.labelEdit.Margin = new System.Windows.Forms.Padding(0);
            this.labelEdit.MaximumSize = new System.Drawing.Size(18, 20);
            this.labelEdit.Name = "labelEdit";
            this.labelEdit.Size = new System.Drawing.Size(18, 20);
            this.labelEdit.TabIndex = 3;
            // 
            // labelChatName
            // 
            this.labelChatName.AutoSize = true;
            this.labelChatName.BackColor = System.Drawing.Color.Transparent;
            this.labelChatName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelChatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChatName.ForeColor = System.Drawing.Color.White;
            this.labelChatName.Location = new System.Drawing.Point(0, 74);
            this.labelChatName.Margin = new System.Windows.Forms.Padding(0);
            this.labelChatName.Name = "labelChatName";
            this.labelChatName.Size = new System.Drawing.Size(315, 50);
            this.labelChatName.TabIndex = 1;
            this.labelChatName.Text = "Name";
            this.labelChatName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(315, 75);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 75);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chat Infomation";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1116, 690);
            this.Controls.Add(this.tableLayoutPanelMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MessagesForm";
            this.Text = "MessagesForm";
            this.tableLayoutPanelMessages.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.searchBarContainer.ResumeLayout(false);
            this.tableLayoutPanelConversationHeader.ResumeLayout(false);
            this.tableLayoutPanelConversationHeader.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelMessages.ResumeLayout(false);
            this.panelMessageSending.ResumeLayout(false);
            this.panelMessageSending.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.containerCommon1.ResumeLayout(false);
            this.containerCommon1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarCommon1)).EndInit();
            this.panelMessageSettings.ResumeLayout(false);
            this.tableLayoutPanelMoreActionItems.ResumeLayout(false);
            this.tableLayoutPanelMoreActionItems.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarChat)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessages;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelConversationHeader;
        private System.Windows.Forms.Panel searchBarContainer;
        private CustomControl.Commons.SearchBarCommon searchBar;
        private System.Windows.Forms.Label labelConversationHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMessageSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControl.Commons.AvatarCommon avatarCommon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMoreAction;
        private System.Windows.Forms.Panel panelMessageSending;
        private System.Windows.Forms.Panel panelMessages;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CustomControl.Commons.ContainerCommon containerCommon1;
        private CustomControl.Commons.AutoSizeTextBox inputMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelSending;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private CustomControl.Commons.AvatarCommon avatarChat;
        private System.Windows.Forms.Label labelChatName;
        private System.Windows.Forms.Label labelEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMoreActionItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelConversations;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
    }
}