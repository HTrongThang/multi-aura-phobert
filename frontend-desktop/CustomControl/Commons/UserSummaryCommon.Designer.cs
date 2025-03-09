namespace CustomControl.Commons
{
    partial class UserSummaryCommon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.actionButton = new System.Windows.Forms.Label();
            this.userAvatar = new CustomControl.Commons.AvatarCommon();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.actionButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.userAvatar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(393, 44);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // actionButton
            // 
            this.actionButton.AutoEllipsis = true;
            this.actionButton.AutoSize = true;
            this.actionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.actionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionButton.ForeColor = System.Drawing.Color.White;
            this.actionButton.Location = new System.Drawing.Point(323, 14);
            this.actionButton.Margin = new System.Windows.Forms.Padding(0, 14, 0, 14);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(70, 16);
            this.actionButton.TabIndex = 3;
            this.actionButton.Text = "Following";
            this.actionButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userAvatar
            // 
            this.userAvatar.CurrentUser = null;
            this.userAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userAvatar.Image = global::CustomControl.Properties.Resources.person;
            this.userAvatar.Location = new System.Drawing.Point(0, 0);
            this.userAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.userAvatar.MaximumSize = new System.Drawing.Size(40, 40);
            this.userAvatar.MinimumSize = new System.Drawing.Size(40, 40);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.Size = new System.Drawing.Size(40, 40);
            this.userAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userAvatar.TabIndex = 1;
            this.userAvatar.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelUsername, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelFullName, 0, 0);
            this.tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(40, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(283, 44);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoEllipsis = true;
            this.labelUsername.AutoSize = true;
            this.labelUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelUsername.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(10, 22);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(98, 22);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Username123@";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoEllipsis = true;
            this.labelFullName.AutoSize = true;
            this.labelFullName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFullName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.ForeColor = System.Drawing.Color.White;
            this.labelFullName.Location = new System.Drawing.Point(10, 0);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(119, 22);
            this.labelFullName.TabIndex = 0;
            this.labelFullName.Text = "Nguyễn Minh Thư";
            this.labelFullName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // UserSummaryCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserSummaryCommon";
            this.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.Size = new System.Drawing.Size(413, 52);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AvatarCommon userAvatar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label actionButton;
    }
}
