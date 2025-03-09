namespace CustomControl.Commons
{
    partial class OutgoingMessage
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTime = new System.Windows.Forms.Label();
            this.containerCommonMessage = new CustomControl.Commons.ContainerCommon();
            this.labelMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.containerCommonMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.labelTime, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.containerCommonMessage, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(114, 10);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(76, 59);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // labelTime
            // 
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.labelTime.Location = new System.Drawing.Point(0, 39);
            this.labelTime.Margin = new System.Windows.Forms.Padding(0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.labelTime.Size = new System.Drawing.Size(76, 20);
            this.labelTime.TabIndex = 14;
            this.labelTime.Text = "19:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // containerCommonMessage
            // 
            this.containerCommonMessage.AutoSize = true;
            this.containerCommonMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(137)))), ((int)(((byte)(235)))));
            this.containerCommonMessage.Controls.Add(this.labelMessage);
            this.containerCommonMessage.Location = new System.Drawing.Point(0, 0);
            this.containerCommonMessage.Margin = new System.Windows.Forms.Padding(0);
            this.containerCommonMessage.MinimumSize = new System.Drawing.Size(68, 34);
            this.containerCommonMessage.Name = "containerCommonMessage";
            this.containerCommonMessage.Padding = new System.Windows.Forms.Padding(12, 6, 12, 8);
            this.containerCommonMessage.Radius = 8;
            this.containerCommonMessage.Size = new System.Drawing.Size(76, 39);
            this.containerCommonMessage.TabIndex = 11;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.BackColor = System.Drawing.Color.Transparent;
            this.labelMessage.Font = new System.Drawing.Font("Montserrat Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(12, 10);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(0);
            this.labelMessage.MaximumSize = new System.Drawing.Size(354, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(52, 21);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "label1";
            // 
            // OutgoingMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(64, 72);
            this.Name = "OutgoingMessage";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(200, 79);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.containerCommonMessage.ResumeLayout(false);
            this.containerCommonMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ContainerCommon containerCommonMessage;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelMessage;
    }
}
