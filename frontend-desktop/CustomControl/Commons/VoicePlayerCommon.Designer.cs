namespace CustomControl.Commons
{
    partial class VoicePlayerCommon
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
            this.labelTimer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonVoicePlayer = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonVoicePlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelTimer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(78, 10);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(38, 40);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimer.ForeColor = System.Drawing.Color.White;
            this.labelTimer.Location = new System.Drawing.Point(0, 0);
            this.labelTimer.Margin = new System.Windows.Forms.Padding(0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labelTimer.Size = new System.Drawing.Size(38, 40);
            this.labelTimer.TabIndex = 16;
            this.labelTimer.Text = "00:30";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.buttonVoicePlayer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(72, 40);
            this.panel1.TabIndex = 20;
            // 
            // buttonVoicePlayer
            // 
            this.buttonVoicePlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVoicePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonVoicePlayer.Image = global::CustomControl.Properties.Resources.audio_wave;
            this.buttonVoicePlayer.Location = new System.Drawing.Point(0, 0);
            this.buttonVoicePlayer.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoicePlayer.MaximumSize = new System.Drawing.Size(60, 40);
            this.buttonVoicePlayer.MinimumSize = new System.Drawing.Size(60, 40);
            this.buttonVoicePlayer.Name = "buttonVoicePlayer";
            this.buttonVoicePlayer.Size = new System.Drawing.Size(60, 40);
            this.buttonVoicePlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonVoicePlayer.TabIndex = 19;
            this.buttonVoicePlayer.TabStop = false;
            // 
            // VoicePlayerCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "VoicePlayerCommon";
            this.Padding = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.Size = new System.Drawing.Size(122, 60);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonVoicePlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox buttonVoicePlayer;
    }
}
