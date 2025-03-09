namespace GUI.Forms
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.MaximizeWindowControlButton = new System.Windows.Forms.Button();
            this.CloseWindowControlButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.MinimizeWindowControlButton = new System.Windows.Forms.Button();
            this.panelWindownControlTaskBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAppName = new System.Windows.Forms.Label();
            this.panelDesktop.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelWindownControlTaskBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.Transparent;
            this.panelDesktop.Controls.Add(this.label1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 35);
            this.panelDesktop.Margin = new System.Windows.Forms.Padding(0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1400, 765);
            this.panelDesktop.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(560, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Welcome to Multi Aura";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tableLayoutPanel2.Controls.Add(this.MaximizeWindowControlButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.MinimizeWindowControlButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CloseWindowControlButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1300, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(100, 35);
            this.tableLayoutPanel2.TabIndex = 0;
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
            // panelWindownControlTaskBar
            // 
            this.panelWindownControlTaskBar.BackColor = System.Drawing.Color.Transparent;
            this.panelWindownControlTaskBar.Controls.Add(this.tableLayoutPanel1);
            this.panelWindownControlTaskBar.Controls.Add(this.tableLayoutPanel2);
            this.panelWindownControlTaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWindownControlTaskBar.Location = new System.Drawing.Point(0, 0);
            this.panelWindownControlTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelWindownControlTaskBar.Name = "panelWindownControlTaskBar";
            this.panelWindownControlTaskBar.Size = new System.Drawing.Size(1400, 35);
            this.panelWindownControlTaskBar.TabIndex = 7;
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
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelWindownControlTaskBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1400, 800);
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeForm";
            this.panelDesktop.ResumeLayout(false);
            this.panelDesktop.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelWindownControlTaskBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button MaximizeWindowControlButton;
        private System.Windows.Forms.Button CloseWindowControlButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button MinimizeWindowControlButton;
        private System.Windows.Forms.Panel panelWindownControlTaskBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.Label label1;
    }
}