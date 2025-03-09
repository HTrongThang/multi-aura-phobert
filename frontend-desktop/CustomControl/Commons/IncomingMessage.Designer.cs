namespace CustomControl.Commons
{
    partial class IncomingMessage
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
            this.containerCommonMessage = new CustomControl.Commons.ContainerCommon();
            this.labelMessage = new System.Windows.Forms.Label();
            this.avatarUser = new CustomControl.Commons.AvatarCommon();
            this.labelTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.containerCommonMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarUser)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.containerCommonMessage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.avatarUser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTime, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(132, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // containerCommonMessage
            // 
            this.containerCommonMessage.AutoSize = true;
            this.containerCommonMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.containerCommonMessage.Controls.Add(this.labelMessage);
            this.containerCommonMessage.Location = new System.Drawing.Point(60, 0);
            this.containerCommonMessage.Margin = new System.Windows.Forms.Padding(0);
            this.containerCommonMessage.MinimumSize = new System.Drawing.Size(32, 32);
            this.containerCommonMessage.Name = "containerCommonMessage";
            this.containerCommonMessage.Padding = new System.Windows.Forms.Padding(12, 6, 12, 8);
            this.containerCommonMessage.Radius = 8;
            this.containerCommonMessage.Size = new System.Drawing.Size(72, 37);
            this.containerCommonMessage.TabIndex = 14;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.BackColor = System.Drawing.Color.Transparent;
            this.labelMessage.Font = new System.Drawing.Font("Montserrat Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(8, 8);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(0);
            this.labelMessage.MaximumSize = new System.Drawing.Size(354, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(52, 21);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "label1";
            // 
            // avatarUser
            // 
            this.avatarUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.avatarUser.Image = global::CustomControl.Properties.Resources._2773d8b41134ee880c2f2ba46fe02303;
            this.avatarUser.Location = new System.Drawing.Point(10, 0);
            this.avatarUser.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.avatarUser.Name = "avatarUser";
            this.avatarUser.Size = new System.Drawing.Size(40, 40);
            this.avatarUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarUser.TabIndex = 10;
            this.avatarUser.TabStop = false;
            // 
            // labelTime
            // 
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.labelTime.Location = new System.Drawing.Point(60, 40);
            this.labelTime.Margin = new System.Windows.Forms.Padding(0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.labelTime.Size = new System.Drawing.Size(72, 20);
            this.labelTime.TabIndex = 13;
            this.labelTime.Text = "19:00";
            // 
            // IncomingMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(64, 68);
            this.Name = "IncomingMessage";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(142, 70);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.containerCommonMessage.ResumeLayout(false);
            this.containerCommonMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AvatarCommon avatarUser;
        private ContainerCommon containerCommonMessage;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelMessage;
    }
}
