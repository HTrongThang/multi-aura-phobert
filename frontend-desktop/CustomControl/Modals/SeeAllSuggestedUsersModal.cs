using BLL.DataProviders;
using CustomControl.Commons;
using DTO;
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
    public partial class SeeAllSuggestedUsersModal : Form
    {
        private RelationshipDataProvider relationshipDataProvider = RelationshipDataProvider.Instance;

        private List<UserSummary> suggestedUsers;
        public SeeAllSuggestedUsersModal()
        {
            InitializeComponent();
            this.CloseWindowControlButton.Click += CloseWindowControlButton_Click;

            InitializeData();
        }

        private async void InitializeData()
        {
            try
            {
                var (list, lastestErrorMesage) = await relationshipDataProvider.FetchSuggestedUsers(1, 20);

                if (list == null || !list.Any())
                {
                    ShowNotFound();
                    return;
                }

                HideNotFound();

                foreach (var item in list)
                {
                    AddUserSummaryToPanel(item, panelSuggestedForYou);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}");
            }
        }

        private void AddUserSummaryToPanel(UserSummary item, Panel panel)
        {
            UserSummaryCommon userSummary = new UserSummaryCommon
            {
                CurrentUserSummary = item,
                IsFollowing = false,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 0),
                Padding = new Padding(10, 4, 10, 4),
            };

            if (panel.InvokeRequired)
            {
                panel.Invoke(new Action(() => panel.Controls.Add(userSummary)));
            }
            else
            {
                panel.Controls.Add(userSummary);
            }
        }

        private void ShowNotFound()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.NotFoundContainer.Visible = true));
            }
            else
            {
                this.NotFoundContainer.Visible = true;
            }
        }

        private void HideNotFound()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.NotFoundContainer.Visible = false));
            }
            else
            {
                this.NotFoundContainer.Visible = false;
            }
        }

        private void CloseWindowControlButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
