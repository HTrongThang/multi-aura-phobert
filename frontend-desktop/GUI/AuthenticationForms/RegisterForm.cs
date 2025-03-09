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
    public partial class RegisterForm : Form
    {
        private event EventHandler backToLogin;
        private Panel panelStep1;
        private Panel panelStep2;
        private Button buttonNext;
        private Button buttonBack;
        private Button buttonSubmit;
        public RegisterForm(EventHandler backToLogin)
        {
            InitializeComponent();
            this.backToLogin = backToLogin;
            this.labelBackToLogin.Click += LabelBackToLogin_Click;

            InitializePanels();
            SetupEventHandlers();

            // Set initial panel visibility
            panelStep1.Visible = true;
            panelStep2.Visible = false;

        }
        private void InitializePanels()
        {
            // Step 1 Panel
            panelStep1 = new Panel
            {
                Size = new System.Drawing.Size(400, 300),
                Location = new Point(10, 10)
            };
            this.Controls.Add(panelStep1);

            // Add Step 1 Controls
            Label lblFullName = new Label { Text = "Full Name:", Location = new Point(10, 10), ForeColor = Color.White };
            TextBox txtFullName = new TextBox { Location = new Point(120, 10), Width = 200 };
            Label lblUsername = new Label { Text = "Username:", Location = new Point(10, 50), ForeColor = Color.White };
            TextBox txtUsername = new TextBox { Location = new Point(120, 50), Width = 200 };
            Label lblEmail = new Label { Text = "Email:", Location = new Point(10, 90), ForeColor = Color.White };
            TextBox txtEmail = new TextBox { Location = new Point(120, 90), Width = 200 };
            Label lblPassword = new Label { Text = "Password:", Location = new Point(10, 130), ForeColor = Color.White };
            TextBox txtPassword = new TextBox { Location = new Point(120, 130), Width = 200, PasswordChar = '*' };
            Label lblPhone = new Label { Text = "Phone Number:", Location = new Point(10, 170), ForeColor = Color.White };
            TextBox txtPhone = new TextBox { Location = new Point(120, 170), Width = 200 };
            buttonNext = new Button { Text = "Next", Location = new Point(10, 220), ForeColor = Color.White, Width = 310 };

            // Add controls to Step 1 Panel
            panelStep1.Controls.AddRange(new Control[] { lblFullName, txtFullName, lblUsername, txtUsername, lblEmail, txtEmail, lblPassword, txtPassword, lblPhone, txtPhone, buttonNext });

            // Step 2 Panel
            panelStep2 = new Panel
            {
                Size = new System.Drawing.Size(400, 300),
                Location = new Point(10, 10)
            };
            this.Controls.Add(panelStep2);

            // Add Step 2 Controls
            Label lblBirthday = new Label { Text = "Birthday:", Location = new Point(10, 10), ForeColor = Color.White };
            DateTimePicker datePickerBirthday = new DateTimePicker { Location = new Point(120, 10), Width = 200 };
            Label lblNation = new Label { Text = "Nationality:", Location = new Point(10, 50), ForeColor = Color.White };
            TextBox txtNation = new TextBox { Location = new Point(120, 50), Width = 200 };
            Label lblProvince = new Label { Text = "Province:", Location = new Point(10, 90), ForeColor = Color.White };
            TextBox txtProvince = new TextBox { Location = new Point(120, 90), Width = 200 };
            Label lblGender = new Label { Text = "Gender:", Location = new Point(10, 130), ForeColor = Color.White };
            ComboBox comboGender = new ComboBox { Location = new Point(120, 130), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            comboGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            buttonBack = new Button { Text = "Back", Location = new Point(10, 210), ForeColor = Color.White, Width = 150 };
            buttonSubmit = new Button { Text = "Submit", Location = new Point(170, 210), ForeColor = Color.White, Width = 150 };

            // Add controls to Step 2 Panel
            panelStep2.Controls.AddRange(new Control[] { lblBirthday, datePickerBirthday, lblNation, txtNation, lblProvince, txtProvince, lblGender, comboGender, buttonBack, buttonSubmit });
        }
        private void SetupEventHandlers()
        {
            buttonNext.Click += (sender, e) =>
            {
                panelStep1.Visible = false;
                panelStep2.Visible = true;
            };

            buttonBack.Click += (sender, e) =>
            {
                panelStep1.Visible = true;
                panelStep2.Visible = false;
            };

            buttonSubmit.Click += (sender, e) =>
            {
                MessageBox.Show("Registration Complete!");
            };
        }
        private void LabelBackToLogin_Click(object sender, EventArgs e)
        {
            backToLogin?.Invoke(this, EventArgs.Empty);
        }
    }
}
