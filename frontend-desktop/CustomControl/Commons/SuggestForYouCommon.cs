using BLL.DataProviders;
using CustomControl.Modals;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class SuggestForYouCommon : UserControl
    {
        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        private List<UserSummary> userSummaries = null;
        public List<UserSummary> UserSummaries
        {
            get => userSummaries;
            set
            {
                if (userSummaries != value)  // Kiểm tra xem giá trị có thay đổi không
                {
                    userSummaries = value;
                    UpdateUI();
                }
            }
        }
        public SuggestForYouCommon()
        {
            InitializeComponent();

            this.labelSeeAll.MouseHover += LabelSeeAll_MouseHover;
            this.labelSeeAll.MouseLeave += LabelSeeAll_MouseLeave;
            this.labelSeeAll.Click += LabelSeeAll_Click;
        }

        private void LabelSeeAll_Click(object sender, EventArgs e)
        {
            Form modal = new SeeAllSuggestedUsersModal
            {
                Width = appDataProvider.ScreenWidth - 100,
                Height = appDataProvider.ScreenHeight - 100,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopMost = true
            };

            appDataProvider.ShowModal(this, modal);
        }

        private void UpdateUI(/*object sender, EventArgs e*/)
        {
            panelSuggestedForYou.Controls.Clear();
            if (UserSummaries != null)
            {
                bool hasData = false;
                this.NotFoundContainer.Visible = false;
                foreach (var item in UserSummaries)
                {
                    UserSummaryCommon userSummary = new UserSummaryCommon
                    {
                        CurrentUserSummary = item,
                        IsFollowing = false,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(10, 4, 10, 4),
                    };

                    if (panelSuggestedForYou.InvokeRequired)
                    {
                        panelSuggestedForYou.Invoke(new Action(() =>
                        {
                            panelSuggestedForYou.Controls.Add(userSummary);
                        }));
                    }
                    else
                    {
                        panelSuggestedForYou.Controls.Add(userSummary);
                    }
                    if (!hasData)
                    {
                        hasData = true;
                    }
                }
                if (!hasData)
                {
                    this.NotFoundContainer.Visible = true;
                }
            }
            else
            {
                this.NotFoundContainer.Visible = true;
            }
        }

        private void LabelSeeAll_MouseHover(object sender, EventArgs e)
        {
            this.labelSeeAll.ForeColor = Color.FromArgb(144, 144, 144);
        }
        private void LabelSeeAll_MouseLeave(object sender, EventArgs e)
        {
            this.labelSeeAll.ForeColor = Color.White;
        }
    }
}
