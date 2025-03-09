using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public class AutoSizeTextBox : TextBox
    {
        private int originalHeight;
        private const int lineHeight = 16;
        private const int defaultMaxLine = 10;
        private bool isHintVisible = true;

        public bool IsHintVisible
        { 
            set { 
                isHintVisible = value;
            } 
        }
        public int MaxLine { get; set; } = defaultMaxLine;
        public string Hint { get; set; }

        public AutoSizeTextBox()
        {
            this.Multiline = true;
            this.WordWrap = true;
            originalHeight = this.Height;
            this.BorderStyle = BorderStyle.None;
            this.ScrollBars = ScrollBars.None;
            if(Hint == null)
            {
                this.Hint = "Aa, enter your text";
            }

            // Đặt sự kiện cho Hint
            this.GotFocus += RemoveHint;
            this.LostFocus += ShowHint;

            // Hiển thị Hint ban đầu nếu có
            ShowHint(null, null);
        }

        public string GetInputText()
        {
            if (isHintVisible || string.IsNullOrEmpty(this.Text))
            {
                return string.Empty;
            }

            return this.Text;
        }

        public void ClearText()
        {
            this.Text = string.Empty;
            ShowHint(null, null);
        }
        private void ShowHint(object sender, EventArgs e)
        {
            // Nếu TextBox trống và chưa có văn bản người dùng nhập vào
            if (string.IsNullOrEmpty(this.Text))
            {
                isHintVisible = true;
                this.Text = Hint;
            }
        }

        private void RemoveHint(object sender, EventArgs e)
        {
            if (isHintVisible)
            {
                isHintVisible = false;
                this.Text = string.Empty;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (!isHintVisible)
            {
                AdjustHeight();
            }
        }

        private void AdjustHeight()
        {
            // Đếm số dòng hiện tại
            int lineCount = this.GetLineFromCharIndex(this.Text.Length) + 1;

            if (lineCount <= MaxLine)
            {
                // Nếu số dòng không vượt quá MaxLine, thay đổi chiều cao của TextBox
                int newHeight = originalHeight + (lineCount - 1) * lineHeight;
                this.Height = newHeight;

                // Không hiển thị thanh cuộn
                this.ScrollBars = ScrollBars.None;
            }
            else
            {
                // Nếu số dòng vượt quá MaxLine, bật thanh cuộn và giữ chiều cao cố định
                this.ScrollBars = ScrollBars.Vertical;
                this.Height = originalHeight + (MaxLine - 1) * lineHeight;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            // Hiển thị lại Hint khi người dùng rời TextBox mà không nhập gì
            if (string.IsNullOrEmpty(this.Text))
            {
                ShowHint(null, null);
            }
        }
    }
}
