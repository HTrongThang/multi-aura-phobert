namespace GUI.Forms
{
    partial class ExploreForm
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
            this.panelResults = new System.Windows.Forms.Panel();
            this.panelPeopleWithQuery = new System.Windows.Forms.Panel();
            this.panelPeopleNoQuery = new System.Windows.Forms.Panel();
            this.panelNewsPostsWithQuery = new System.Windows.Forms.Panel();
            this.panelNewsNoQueryPosts = new System.Windows.Forms.Panel();
            this.panelTrendingPostsWithQuery = new System.Windows.Forms.Panel();
            this.panelTrendingNoQueryPosts = new System.Windows.Forms.Panel();
            this.panelForYouPosts = new System.Windows.Forms.Panel();
            this.panelForYouNoQueryPosts = new System.Windows.Forms.Panel();
            this.panelPostsNoQuery = new System.Windows.Forms.Panel();
            this.panelPostsWithQuery = new System.Windows.Forms.Panel();
            this.NotFoundContainer = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanelSearchTaskBar = new System.Windows.Forms.TableLayoutPanel();
            this.labelPosts = new System.Windows.Forms.Label();
            this.labelPeople = new System.Windows.Forms.Label();
            this.labelNews = new System.Windows.Forms.Label();
            this.labelTrending = new System.Windows.Forms.Label();
            this.labelForYou = new System.Windows.Forms.Label();
            this.searchBarContainer = new System.Windows.Forms.Panel();
            this.searchBarCommon = new CustomControl.Commons.SearchBarCommon();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LoadingContainer = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSuggests.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelResults.SuspendLayout();
            this.NotFoundContainer.SuspendLayout();
            this.tableLayoutPanelSearchTaskBar.SuspendLayout();
            this.searchBarContainer.SuspendLayout();
            this.LoadingContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuggests
            // 
            this.panelSuggests.BackColor = System.Drawing.Color.Transparent;
            this.panelSuggests.Controls.Add(this.suggestForYouCommon1);
            this.panelSuggests.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSuggests.Location = new System.Drawing.Point(637, 0);
            this.panelSuggests.Margin = new System.Windows.Forms.Padding(0);
            this.panelSuggests.Name = "panelSuggests";
            this.panelSuggests.Padding = new System.Windows.Forms.Padding(0, 64, 0, 0);
            this.panelSuggests.Size = new System.Drawing.Size(284, 580);
            this.panelSuggests.TabIndex = 4;
            // 
            // suggestForYouCommon1
            // 
            this.suggestForYouCommon1.BackColor = System.Drawing.Color.Transparent;
            this.suggestForYouCommon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suggestForYouCommon1.Location = new System.Drawing.Point(0, 64);
            this.suggestForYouCommon1.Margin = new System.Windows.Forms.Padding(0);
            this.suggestForYouCommon1.Name = "suggestForYouCommon1";
            this.suggestForYouCommon1.Size = new System.Drawing.Size(284, 516);
            this.suggestForYouCommon1.TabIndex = 0;
            this.suggestForYouCommon1.UserSummaries = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panelResults);
            this.panel1.Controls.Add(this.tableLayoutPanelSearchTaskBar);
            this.panel1.Controls.Add(this.searchBarContainer);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.panel1.Size = new System.Drawing.Size(637, 580);
            this.panel1.TabIndex = 7;
            // 
            // panelResults
            // 
            this.panelResults.AutoScroll = true;
            this.panelResults.Controls.Add(this.LoadingContainer);
            this.panelResults.Controls.Add(this.panelPeopleWithQuery);
            this.panelResults.Controls.Add(this.panelPeopleNoQuery);
            this.panelResults.Controls.Add(this.panelNewsPostsWithQuery);
            this.panelResults.Controls.Add(this.panelNewsNoQueryPosts);
            this.panelResults.Controls.Add(this.panelTrendingPostsWithQuery);
            this.panelResults.Controls.Add(this.panelTrendingNoQueryPosts);
            this.panelResults.Controls.Add(this.panelForYouPosts);
            this.panelResults.Controls.Add(this.panelForYouNoQueryPosts);
            this.panelResults.Controls.Add(this.panelPostsNoQuery);
            this.panelResults.Controls.Add(this.panelPostsWithQuery);
            this.panelResults.Controls.Add(this.NotFoundContainer);
            this.panelResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResults.Location = new System.Drawing.Point(0, 76);
            this.panelResults.Margin = new System.Windows.Forms.Padding(0);
            this.panelResults.Name = "panelResults";
            this.panelResults.Padding = new System.Windows.Forms.Padding(20, 20, 40, 20);
            this.panelResults.Size = new System.Drawing.Size(597, 504);
            this.panelResults.TabIndex = 25;
            // 
            // panelPeopleWithQuery
            // 
            this.panelPeopleWithQuery.AutoSize = true;
            this.panelPeopleWithQuery.BackColor = System.Drawing.Color.Transparent;
            this.panelPeopleWithQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPeopleWithQuery.Location = new System.Drawing.Point(20, 479);
            this.panelPeopleWithQuery.Margin = new System.Windows.Forms.Padding(0);
            this.panelPeopleWithQuery.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelPeopleWithQuery.Name = "panelPeopleWithQuery";
            this.panelPeopleWithQuery.Size = new System.Drawing.Size(516, 48);
            this.panelPeopleWithQuery.TabIndex = 31;
            // 
            // panelPeopleNoQuery
            // 
            this.panelPeopleNoQuery.AutoSize = true;
            this.panelPeopleNoQuery.BackColor = System.Drawing.Color.Transparent;
            this.panelPeopleNoQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPeopleNoQuery.Location = new System.Drawing.Point(20, 431);
            this.panelPeopleNoQuery.Margin = new System.Windows.Forms.Padding(0);
            this.panelPeopleNoQuery.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelPeopleNoQuery.Name = "panelPeopleNoQuery";
            this.panelPeopleNoQuery.Size = new System.Drawing.Size(516, 48);
            this.panelPeopleNoQuery.TabIndex = 30;
            // 
            // panelNewsPostsWithQuery
            // 
            this.panelNewsPostsWithQuery.AutoSize = true;
            this.panelNewsPostsWithQuery.BackColor = System.Drawing.Color.Transparent;
            this.panelNewsPostsWithQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNewsPostsWithQuery.Location = new System.Drawing.Point(20, 383);
            this.panelNewsPostsWithQuery.Margin = new System.Windows.Forms.Padding(0);
            this.panelNewsPostsWithQuery.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelNewsPostsWithQuery.Name = "panelNewsPostsWithQuery";
            this.panelNewsPostsWithQuery.Size = new System.Drawing.Size(516, 48);
            this.panelNewsPostsWithQuery.TabIndex = 27;
            // 
            // panelNewsNoQueryPosts
            // 
            this.panelNewsNoQueryPosts.AutoSize = true;
            this.panelNewsNoQueryPosts.BackColor = System.Drawing.Color.Transparent;
            this.panelNewsNoQueryPosts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNewsNoQueryPosts.Location = new System.Drawing.Point(20, 335);
            this.panelNewsNoQueryPosts.Margin = new System.Windows.Forms.Padding(0);
            this.panelNewsNoQueryPosts.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelNewsNoQueryPosts.Name = "panelNewsNoQueryPosts";
            this.panelNewsNoQueryPosts.Size = new System.Drawing.Size(516, 48);
            this.panelNewsNoQueryPosts.TabIndex = 26;
            // 
            // panelTrendingPostsWithQuery
            // 
            this.panelTrendingPostsWithQuery.AutoSize = true;
            this.panelTrendingPostsWithQuery.BackColor = System.Drawing.Color.Transparent;
            this.panelTrendingPostsWithQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTrendingPostsWithQuery.Location = new System.Drawing.Point(20, 287);
            this.panelTrendingPostsWithQuery.Margin = new System.Windows.Forms.Padding(0);
            this.panelTrendingPostsWithQuery.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelTrendingPostsWithQuery.Name = "panelTrendingPostsWithQuery";
            this.panelTrendingPostsWithQuery.Size = new System.Drawing.Size(516, 48);
            this.panelTrendingPostsWithQuery.TabIndex = 25;
            // 
            // panelTrendingNoQueryPosts
            // 
            this.panelTrendingNoQueryPosts.AutoSize = true;
            this.panelTrendingNoQueryPosts.BackColor = System.Drawing.Color.Transparent;
            this.panelTrendingNoQueryPosts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTrendingNoQueryPosts.Location = new System.Drawing.Point(20, 239);
            this.panelTrendingNoQueryPosts.Margin = new System.Windows.Forms.Padding(0);
            this.panelTrendingNoQueryPosts.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelTrendingNoQueryPosts.Name = "panelTrendingNoQueryPosts";
            this.panelTrendingNoQueryPosts.Size = new System.Drawing.Size(516, 48);
            this.panelTrendingNoQueryPosts.TabIndex = 24;
            // 
            // panelForYouPosts
            // 
            this.panelForYouPosts.AutoSize = true;
            this.panelForYouPosts.BackColor = System.Drawing.Color.Transparent;
            this.panelForYouPosts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForYouPosts.Location = new System.Drawing.Point(20, 191);
            this.panelForYouPosts.Margin = new System.Windows.Forms.Padding(0);
            this.panelForYouPosts.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelForYouPosts.Name = "panelForYouPosts";
            this.panelForYouPosts.Size = new System.Drawing.Size(516, 48);
            this.panelForYouPosts.TabIndex = 23;
            // 
            // panelForYouNoQueryPosts
            // 
            this.panelForYouNoQueryPosts.AutoSize = true;
            this.panelForYouNoQueryPosts.BackColor = System.Drawing.Color.Transparent;
            this.panelForYouNoQueryPosts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForYouNoQueryPosts.Location = new System.Drawing.Point(20, 143);
            this.panelForYouNoQueryPosts.Margin = new System.Windows.Forms.Padding(0);
            this.panelForYouNoQueryPosts.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelForYouNoQueryPosts.Name = "panelForYouNoQueryPosts";
            this.panelForYouNoQueryPosts.Size = new System.Drawing.Size(516, 48);
            this.panelForYouNoQueryPosts.TabIndex = 22;
            // 
            // panelPostsNoQuery
            // 
            this.panelPostsNoQuery.AutoSize = true;
            this.panelPostsNoQuery.BackColor = System.Drawing.Color.Transparent;
            this.panelPostsNoQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPostsNoQuery.Location = new System.Drawing.Point(20, 95);
            this.panelPostsNoQuery.Margin = new System.Windows.Forms.Padding(0);
            this.panelPostsNoQuery.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelPostsNoQuery.Name = "panelPostsNoQuery";
            this.panelPostsNoQuery.Size = new System.Drawing.Size(516, 48);
            this.panelPostsNoQuery.TabIndex = 28;
            // 
            // panelPostsWithQuery
            // 
            this.panelPostsWithQuery.AutoSize = true;
            this.panelPostsWithQuery.BackColor = System.Drawing.Color.Transparent;
            this.panelPostsWithQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPostsWithQuery.Location = new System.Drawing.Point(20, 47);
            this.panelPostsWithQuery.Margin = new System.Windows.Forms.Padding(0);
            this.panelPostsWithQuery.MinimumSize = new System.Drawing.Size(0, 48);
            this.panelPostsWithQuery.Name = "panelPostsWithQuery";
            this.panelPostsWithQuery.Size = new System.Drawing.Size(516, 48);
            this.panelPostsWithQuery.TabIndex = 29;
            // 
            // NotFoundContainer
            // 
            this.NotFoundContainer.ColumnCount = 1;
            this.NotFoundContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.NotFoundContainer.Controls.Add(this.label1, 0, 0);
            this.NotFoundContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.NotFoundContainer.Location = new System.Drawing.Point(20, 20);
            this.NotFoundContainer.Margin = new System.Windows.Forms.Padding(0);
            this.NotFoundContainer.Name = "NotFoundContainer";
            this.NotFoundContainer.RowCount = 1;
            this.NotFoundContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.NotFoundContainer.Size = new System.Drawing.Size(516, 27);
            this.NotFoundContainer.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "Not found";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelSearchTaskBar
            // 
            this.tableLayoutPanelSearchTaskBar.ColumnCount = 5;
            this.tableLayoutPanelSearchTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSearchTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSearchTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSearchTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSearchTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSearchTaskBar.Controls.Add(this.labelPosts, 4, 0);
            this.tableLayoutPanelSearchTaskBar.Controls.Add(this.labelPeople, 3, 0);
            this.tableLayoutPanelSearchTaskBar.Controls.Add(this.labelNews, 2, 0);
            this.tableLayoutPanelSearchTaskBar.Controls.Add(this.labelTrending, 1, 0);
            this.tableLayoutPanelSearchTaskBar.Controls.Add(this.labelForYou, 0, 0);
            this.tableLayoutPanelSearchTaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelSearchTaskBar.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanelSearchTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelSearchTaskBar.Name = "tableLayoutPanelSearchTaskBar";
            this.tableLayoutPanelSearchTaskBar.RowCount = 1;
            this.tableLayoutPanelSearchTaskBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSearchTaskBar.Size = new System.Drawing.Size(597, 37);
            this.tableLayoutPanelSearchTaskBar.TabIndex = 24;
            // 
            // labelPosts
            // 
            this.labelPosts.AutoSize = true;
            this.labelPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosts.Location = new System.Drawing.Point(476, 0);
            this.labelPosts.Margin = new System.Windows.Forms.Padding(0);
            this.labelPosts.Name = "labelPosts";
            this.labelPosts.Size = new System.Drawing.Size(121, 37);
            this.labelPosts.TabIndex = 4;
            this.labelPosts.Text = "Posts";
            this.labelPosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPeople
            // 
            this.labelPeople.AutoSize = true;
            this.labelPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeople.Location = new System.Drawing.Point(357, 0);
            this.labelPeople.Margin = new System.Windows.Forms.Padding(0);
            this.labelPeople.Name = "labelPeople";
            this.labelPeople.Size = new System.Drawing.Size(119, 37);
            this.labelPeople.TabIndex = 3;
            this.labelPeople.Text = "People";
            this.labelPeople.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNews
            // 
            this.labelNews.AutoSize = true;
            this.labelNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNews.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNews.Location = new System.Drawing.Point(238, 0);
            this.labelNews.Margin = new System.Windows.Forms.Padding(0);
            this.labelNews.Name = "labelNews";
            this.labelNews.Size = new System.Drawing.Size(119, 37);
            this.labelNews.TabIndex = 2;
            this.labelNews.Text = "News";
            this.labelNews.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTrending
            // 
            this.labelTrending.AutoSize = true;
            this.labelTrending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTrending.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrending.Location = new System.Drawing.Point(119, 0);
            this.labelTrending.Margin = new System.Windows.Forms.Padding(0);
            this.labelTrending.Name = "labelTrending";
            this.labelTrending.Size = new System.Drawing.Size(119, 37);
            this.labelTrending.TabIndex = 1;
            this.labelTrending.Text = "Trending";
            this.labelTrending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelForYou
            // 
            this.labelForYou.AutoSize = true;
            this.labelForYou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelForYou.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForYou.Location = new System.Drawing.Point(0, 0);
            this.labelForYou.Margin = new System.Windows.Forms.Padding(0);
            this.labelForYou.Name = "labelForYou";
            this.labelForYou.Size = new System.Drawing.Size(119, 37);
            this.labelForYou.TabIndex = 0;
            this.labelForYou.Text = "For you";
            this.labelForYou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchBarContainer
            // 
            this.searchBarContainer.Controls.Add(this.searchBarCommon);
            this.searchBarContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBarContainer.Location = new System.Drawing.Point(0, 0);
            this.searchBarContainer.Margin = new System.Windows.Forms.Padding(0);
            this.searchBarContainer.Name = "searchBarContainer";
            this.searchBarContainer.Size = new System.Drawing.Size(597, 39);
            this.searchBarContainer.TabIndex = 23;
            // 
            // searchBarCommon
            // 
            this.searchBarCommon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.searchBarCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBarCommon.Hint = "Search...";
            this.searchBarCommon.Location = new System.Drawing.Point(0, 0);
            this.searchBarCommon.Margin = new System.Windows.Forms.Padding(0);
            this.searchBarCommon.MinimumSize = new System.Drawing.Size(320, 32);
            this.searchBarCommon.Name = "searchBarCommon";
            this.searchBarCommon.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.searchBarCommon.Query = "";
            this.searchBarCommon.Size = new System.Drawing.Size(597, 39);
            this.searchBarCommon.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 80);
            this.panel3.TabIndex = 22;
            // 
            // LoadingContainer
            // 
            this.LoadingContainer.ColumnCount = 1;
            this.LoadingContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LoadingContainer.Controls.Add(this.label2, 0, 0);
            this.LoadingContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoadingContainer.Location = new System.Drawing.Point(20, 527);
            this.LoadingContainer.Margin = new System.Windows.Forms.Padding(0);
            this.LoadingContainer.Name = "LoadingContainer";
            this.LoadingContainer.RowCount = 1;
            this.LoadingContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LoadingContainer.Size = new System.Drawing.Size(516, 27);
            this.LoadingContainer.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(516, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Loading...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExploreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(921, 580);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSuggests);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExploreForm";
            this.Text = "ExploreForm";
            this.panelSuggests.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelResults.ResumeLayout(false);
            this.panelResults.PerformLayout();
            this.NotFoundContainer.ResumeLayout(false);
            this.NotFoundContainer.PerformLayout();
            this.tableLayoutPanelSearchTaskBar.ResumeLayout(false);
            this.tableLayoutPanelSearchTaskBar.PerformLayout();
            this.searchBarContainer.ResumeLayout(false);
            this.LoadingContainer.ResumeLayout(false);
            this.LoadingContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSuggests;
        private CustomControl.Commons.SuggestForYouCommon suggestForYouCommon1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelResults;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSearchTaskBar;
        private System.Windows.Forms.Label labelPosts;
        private System.Windows.Forms.Label labelPeople;
        private System.Windows.Forms.Label labelNews;
        private System.Windows.Forms.Label labelTrending;
        private System.Windows.Forms.Label labelForYou;
        private System.Windows.Forms.Panel searchBarContainer;
        private CustomControl.Commons.SearchBarCommon searchBarCommon;
        private System.Windows.Forms.TableLayoutPanel NotFoundContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPeopleWithQuery;
        private System.Windows.Forms.Panel panelPeopleNoQuery;
        private System.Windows.Forms.Panel panelNewsPostsWithQuery;
        private System.Windows.Forms.Panel panelNewsNoQueryPosts;
        private System.Windows.Forms.Panel panelTrendingPostsWithQuery;
        private System.Windows.Forms.Panel panelTrendingNoQueryPosts;
        private System.Windows.Forms.Panel panelForYouPosts;
        private System.Windows.Forms.Panel panelForYouNoQueryPosts;
        private System.Windows.Forms.Panel panelPostsNoQuery;
        private System.Windows.Forms.Panel panelPostsWithQuery;
        private System.Windows.Forms.TableLayoutPanel LoadingContainer;
        private System.Windows.Forms.Label label2;
    }
}