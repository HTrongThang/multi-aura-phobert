using System;
using System.Windows.Forms;
using BLL.DataProviders;
namespace GUI.AuthenticationForms
{
    public partial class LoginForm : Form
    {
        private event EventHandler goToRegister;
        private AuthDataProvider authDataProvider;

        public LoginForm(EventHandler GoToRegister)
        {
            InitializeComponent();
            this.goToRegister = GoToRegister;
            this.labelGoToRegister.Click += LabelGoToRegister_Click;
            authDataProvider = AuthDataProvider.Instance; 
        }

        private void LabelGoToRegister_Click(object sender, EventArgs e)
        {
            goToRegister?.Invoke(this, EventArgs.Empty);
        }


        private async void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            if (authDataProvider == null)
            {
                MessageBox.Show("AuthDataProvider is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (authDataProvider == null)
                {
                    MessageBox.Show("AuthDataProvider is null.", "Error");
                    return;
                }


                await authDataProvider.LoginAsync(username, password);
                if (authDataProvider.CurrentUser != null)
                {
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
