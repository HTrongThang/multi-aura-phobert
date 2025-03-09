namespace CustomControl.Commons
{
    partial class BriefPost
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
            this.containerPostPhotoReresent = new CustomControl.Commons.ContainerCommon();
            this.labelHasMoreImages = new System.Windows.Forms.Label();
            this.postPhotoRepresent = new System.Windows.Forms.PictureBox();
            this.containerPostPhotoReresent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postPhotoRepresent)).BeginInit();
            this.SuspendLayout();
            // 
            // containerPostPhotoReresent
            // 
            this.containerPostPhotoReresent.Controls.Add(this.labelHasMoreImages);
            this.containerPostPhotoReresent.Controls.Add(this.postPhotoRepresent);
            this.containerPostPhotoReresent.Location = new System.Drawing.Point(10, 10);
            this.containerPostPhotoReresent.Margin = new System.Windows.Forms.Padding(0);
            this.containerPostPhotoReresent.MaximumSize = new System.Drawing.Size(220, 220);
            this.containerPostPhotoReresent.MinimumSize = new System.Drawing.Size(220, 220);
            this.containerPostPhotoReresent.Name = "containerPostPhotoReresent";
            this.containerPostPhotoReresent.Radius = 8;
            this.containerPostPhotoReresent.Size = new System.Drawing.Size(220, 220);
            this.containerPostPhotoReresent.TabIndex = 0;
            // 
            // labelHasMoreImages
            // 
            this.labelHasMoreImages.AutoSize = true;
            this.labelHasMoreImages.ForeColor = System.Drawing.Color.White;
            this.labelHasMoreImages.Image = global::CustomControl.Properties.Resources.layers;
            this.labelHasMoreImages.Location = new System.Drawing.Point(196, 0);
            this.labelHasMoreImages.Margin = new System.Windows.Forms.Padding(0);
            this.labelHasMoreImages.MaximumSize = new System.Drawing.Size(24, 24);
            this.labelHasMoreImages.MinimumSize = new System.Drawing.Size(24, 24);
            this.labelHasMoreImages.Name = "labelHasMoreImages";
            this.labelHasMoreImages.Size = new System.Drawing.Size(24, 24);
            this.labelHasMoreImages.TabIndex = 1;
            // 
            // postPhotoRepresent
            // 
            this.postPhotoRepresent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.postPhotoRepresent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postPhotoRepresent.Image = global::CustomControl.Properties.Resources.error_image;
            this.postPhotoRepresent.Location = new System.Drawing.Point(0, 0);
            this.postPhotoRepresent.Margin = new System.Windows.Forms.Padding(0);
            this.postPhotoRepresent.Name = "postPhotoRepresent";
            this.postPhotoRepresent.Size = new System.Drawing.Size(220, 220);
            this.postPhotoRepresent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.postPhotoRepresent.TabIndex = 0;
            this.postPhotoRepresent.TabStop = false;
            // 
            // BriefPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.containerPostPhotoReresent);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BriefPost";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(240, 240);
            this.containerPostPhotoReresent.ResumeLayout(false);
            this.containerPostPhotoReresent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postPhotoRepresent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ContainerCommon containerPostPhotoReresent;
        private System.Windows.Forms.PictureBox postPhotoRepresent;
        private System.Windows.Forms.Label labelHasMoreImages;
    }
}
