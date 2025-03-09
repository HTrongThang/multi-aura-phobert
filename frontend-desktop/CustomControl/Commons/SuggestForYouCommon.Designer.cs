namespace CustomControl.Commons
{
    partial class SuggestForYouCommon
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
            this.labelSeeAll = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSuggestedForYou = new System.Windows.Forms.Panel();
            this.NotFoundContainer = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelSuggestedForYou.SuspendLayout();
            this.NotFoundContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.Controls.Add(this.labelSeeAll, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 31);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelSeeAll
            // 
            this.labelSeeAll.AutoEllipsis = true;
            this.labelSeeAll.AutoSize = true;
            this.labelSeeAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSeeAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSeeAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeeAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.labelSeeAll.Location = new System.Drawing.Point(326, 10);
            this.labelSeeAll.Margin = new System.Windows.Forms.Padding(20, 10, 20, 0);
            this.labelSeeAll.Name = "labelSeeAll";
            this.labelSeeAll.Size = new System.Drawing.Size(62, 21);
            this.labelSeeAll.TabIndex = 5;
            this.labelSeeAll.Text = "See all";
            this.labelSeeAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Suggested for you";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panelSuggestedForYou
            // 
            this.panelSuggestedForYou.Controls.Add(this.NotFoundContainer);
            this.panelSuggestedForYou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSuggestedForYou.Location = new System.Drawing.Point(0, 31);
            this.panelSuggestedForYou.Margin = new System.Windows.Forms.Padding(0);
            this.panelSuggestedForYou.Name = "panelSuggestedForYou";
            this.panelSuggestedForYou.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panelSuggestedForYou.Size = new System.Drawing.Size(408, 368);
            this.panelSuggestedForYou.TabIndex = 1;
            // 
            // NotFoundContainer
            // 
            this.NotFoundContainer.ColumnCount = 1;
            this.NotFoundContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.NotFoundContainer.Controls.Add(this.label1, 0, 0);
            this.NotFoundContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.NotFoundContainer.Location = new System.Drawing.Point(0, 10);
            this.NotFoundContainer.Margin = new System.Windows.Forms.Padding(0);
            this.NotFoundContainer.Name = "NotFoundContainer";
            this.NotFoundContainer.RowCount = 1;
            this.NotFoundContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.NotFoundContainer.Size = new System.Drawing.Size(408, 34);
            this.NotFoundContainer.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 34);
            this.label1.TabIndex = 7;
            this.label1.Text = "No suggested friend found";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SuggestForYouCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelSuggestedForYou);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SuggestForYouCommon";
            this.Size = new System.Drawing.Size(408, 399);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelSuggestedForYou.ResumeLayout(false);
            this.NotFoundContainer.ResumeLayout(false);
            this.NotFoundContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSeeAll;
        private System.Windows.Forms.Panel panelSuggestedForYou;
        private System.Windows.Forms.TableLayoutPanel NotFoundContainer;
        private System.Windows.Forms.Label label1;
    }
}
