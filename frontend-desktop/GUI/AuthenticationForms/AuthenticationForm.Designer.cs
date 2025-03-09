namespace GUI.AuthenticationForms
{
    partial class AuthenticationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationForm));
            this.CloseWindowControlButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelWindownControlTaskBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAppName = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.MinimizeWindowControlButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFormName = new System.Windows.Forms.Label();
            this.labelShortDescription = new System.Windows.Forms.Label();
            this.introComponent1 = new CustomControl.AuthenticationComponents.IntroComponent();
            this.languageCombobox1 = new CustomControl.Commons.LanguageCombobox();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelWindownControlTaskBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.CloseWindowControlButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.MinimizeWindowControlButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(692, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(100, 35);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panelWindownControlTaskBar
            // 
            this.panelWindownControlTaskBar.BackColor = System.Drawing.Color.Transparent;
            this.panelWindownControlTaskBar.Controls.Add(this.tableLayoutPanel1);
            this.panelWindownControlTaskBar.Controls.Add(this.tableLayoutPanel2);
            this.panelWindownControlTaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWindownControlTaskBar.Location = new System.Drawing.Point(4, 4);
            this.panelWindownControlTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelWindownControlTaskBar.Name = "panelWindownControlTaskBar";
            this.panelWindownControlTaskBar.Size = new System.Drawing.Size(792, 35);
            this.panelWindownControlTaskBar.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelAppName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(82, 35);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelAppName
            // 
            this.labelAppName.AutoSize = true;
            this.labelAppName.BackColor = System.Drawing.Color.Transparent;
            this.labelAppName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelAppName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelAppName.Font = new System.Drawing.Font("iCiel Cadena", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppName.ForeColor = System.Drawing.Color.White;
            this.labelAppName.Location = new System.Drawing.Point(0, 0);
            this.labelAppName.Margin = new System.Windows.Forms.Padding(0);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelAppName.Size = new System.Drawing.Size(80, 35);
            this.labelAppName.TabIndex = 1;
            this.labelAppName.Text = "Multi Aura";
            this.labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.introComponent1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.languageCombobox1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 39);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(792, 457);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // MinimizeWindowControlButton
            // 
            this.MinimizeWindowControlButton.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeWindowControlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MinimizeWindowControlButton.FlatAppearance.BorderSize = 0;
            this.MinimizeWindowControlButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.MinimizeWindowControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeWindowControlButton.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeWindowControlButton.Image")));
            this.MinimizeWindowControlButton.Location = new System.Drawing.Point(33, 0);
            this.MinimizeWindowControlButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeWindowControlButton.Name = "MinimizeWindowControlButton";
            this.MinimizeWindowControlButton.Size = new System.Drawing.Size(33, 35);
            this.MinimizeWindowControlButton.TabIndex = 4;
            this.MinimizeWindowControlButton.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.panelDesktop, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(320, 28);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.09847F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.90154F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(472, 429);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.Transparent;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 64);
            this.panelDesktop.Margin = new System.Windows.Forms.Padding(0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(472, 365);
            this.panelDesktop.TabIndex = 8;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.labelShortDescription, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.labelFormName, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.96825F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.03175F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(466, 58);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // labelFormName
            // 
            this.labelFormName.AutoSize = true;
            this.labelFormName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormName.ForeColor = System.Drawing.Color.White;
            this.labelFormName.Location = new System.Drawing.Point(0, 0);
            this.labelFormName.Margin = new System.Windows.Forms.Padding(0);
            this.labelFormName.Name = "labelFormName";
            this.labelFormName.Size = new System.Drawing.Size(466, 31);
            this.labelFormName.TabIndex = 3;
            this.labelFormName.Text = "Form name";
            this.labelFormName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelShortDescription
            // 
            this.labelShortDescription.AutoSize = true;
            this.labelShortDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShortDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShortDescription.ForeColor = System.Drawing.Color.White;
            this.labelShortDescription.Location = new System.Drawing.Point(0, 31);
            this.labelShortDescription.Margin = new System.Windows.Forms.Padding(0);
            this.labelShortDescription.Name = "labelShortDescription";
            this.labelShortDescription.Size = new System.Drawing.Size(466, 27);
            this.labelShortDescription.TabIndex = 4;
            this.labelShortDescription.Text = "Short description";
            this.labelShortDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // introComponent1
            // 
            this.introComponent1.BackColor = System.Drawing.Color.Transparent;
            this.introComponent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.introComponent1.Location = new System.Drawing.Point(0, 28);
            this.introComponent1.Margin = new System.Windows.Forms.Padding(0);
            this.introComponent1.Name = "introComponent1";
            this.introComponent1.Size = new System.Drawing.Size(320, 429);
            this.introComponent1.TabIndex = 8;
            // 
            // languageCombobox1
            // 
            this.languageCombobox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.languageCombobox1.Location = new System.Drawing.Point(672, 0);
            this.languageCombobox1.Margin = new System.Windows.Forms.Padding(0);
            this.languageCombobox1.Name = "languageCombobox1";
            this.languageCombobox1.Size = new System.Drawing.Size(120, 28);
            this.languageCombobox1.TabIndex = 10;
            // 
            // AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panelWindownControlTaskBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthenticationForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthenticationForm";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelWindownControlTaskBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CloseWindowControlButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelWindownControlTaskBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private CustomControl.AuthenticationComponents.IntroComponent introComponent1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button MinimizeWindowControlButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelFormName;
        private System.Windows.Forms.Label labelShortDescription;
        private CustomControl.Commons.LanguageCombobox languageCombobox1;
    }
}