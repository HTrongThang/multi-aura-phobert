using BLL.DataProviders;
using GUI.Extensions;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.AuthenticationForms
{
    public partial class AuthenticationForm : Form
    {
        private Button currentButton;
        private Form activeForm;
        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        private AuthDataProvider authDataProvider;
        public AuthenticationForm()
        {
            InitializeComponent();
            this.EnableWindowControlButtons(
                minimizeButton: this.MinimizeWindowControlButton, 
                closeButton: this.CloseWindowControlButton);
            this.FormClosed += AuthenticationForm_FormClosed;
            SetUpNavigators();
            this.languageCombobox1.Visible = false;
            authDataProvider = AuthDataProvider.Instance;

            authDataProvider.UserLoggedIn += AuthDataProvider_UserLoggedIn;
        }

        private void AuthDataProvider_UserLoggedIn()
        {
            this.Close();
        }

        private void AuthenticationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!appDataProvider.HasUser())
            {
                this.Hide();
                WelcomeForm welcomeForm = new WelcomeForm();
                welcomeForm.ShowDialog();
            }
        }
        private void SetUpNavigators()
        {
            this.Load += (sender, e) => OpenChildForm(new LoginForm(OnGoToRegister));
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            if(childForm is LoginForm)
            {
                this.labelFormName.Text = "Login";
                this.labelShortDescription.Text = "Đăng nhập tài khoản của bạn";
            }
            else if (childForm is RegisterForm)
            {
                this.labelFormName.Text = "Register";
                this.labelShortDescription.Text = "Tạo tài khoản của ban";
            }
            activeForm = childForm;
            //childForm.Tag = this.Tag;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void OnGoToRegister(object sender, EventArgs e)
        {
            OpenChildForm(new RegisterForm(OnBackToLogin));
        }

        private void OnBackToLogin(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm(OnGoToRegister));
        }
    }
}
