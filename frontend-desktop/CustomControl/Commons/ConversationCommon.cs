using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class ConversationCommon : UserControl
    {
        private string conversationName;
        private string lastestMessage;
        private string lastestTime;
        private bool isSelected;

        public string ConversationName
        {
            get => conversationName;
            set
            {
                if (conversationName != value)
                {
                    conversationName = value;
                    UpdateUI();
                }
            }
        }

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    UpdateBackColor();
                }
            }
        }

        public string LastestMessage
        {
            get => lastestMessage;
            set
            {
                if (lastestMessage != value)
                {
                    lastestMessage = value;
                    UpdateUI();
                }
            }
        }

        public string LastestTime
        {
            get => lastestTime;
            set
            {
                if (lastestTime != value)
                {
                    lastestTime = value;
                    UpdateUI();
                }
            }
        }

        public ConversationCommon()
        {
            InitializeComponent();
            conversationName = string.Empty;
            lastestMessage = string.Empty;
            lastestTime = string.Empty;

            // Đăng ký sự kiện MouseHover và MouseLeave cho chính ConversationCommon
            this.MouseHover += ConversationCommon_MouseHover;
            this.MouseLeave += ConversationCommon_MouseLeave;

            // Đăng ký sự kiện cho tất cả các control con
            RegisterMouseEventsForAllControls(this);

            UpdateUI();
        }

        // Phương thức đăng ký sự kiện MouseHover và MouseLeave cho tất cả control con
        private void RegisterMouseEventsForAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Gán sự kiện MouseHover và MouseLeave cho control con
                control.MouseHover += (s, e) => ConversationCommon_MouseHover(this, e);
                control.MouseLeave += (s, e) => ConversationCommon_MouseLeave(this, e);

                // Đệ quy cho các control con khác (nếu có)
                if (control.HasChildren)
                {
                    RegisterMouseEventsForAllControls(control);
                }
            }
        }

        private void ConversationCommon_MouseLeave(object sender, EventArgs e)
        {
            if (!isSelected)
            {
                this.BackColor = Color.Transparent;
            }
        }

        private void ConversationCommon_MouseHover(object sender, EventArgs e)
        {
            if (!isSelected)
            {
                this.BackColor = Color.FromArgb(24, 24, 24);
            }
        }

        private void UpdateUI()
        {
            this.labelConversationName.Text = conversationName ?? string.Empty;
            this.labelLastestMessage.Text = lastestMessage ?? string.Empty;
            this.labelLastestTime.Text = lastestTime ?? string.Empty;
        }

        private void UpdateBackColor()
        {
            if (isSelected)
            {
                this.BackColor = Color.FromArgb(24, 24, 24);
            }
            else
            {
                this.BackColor = Color.Transparent;
                isSelected = false;
            }
        }
    }
}
