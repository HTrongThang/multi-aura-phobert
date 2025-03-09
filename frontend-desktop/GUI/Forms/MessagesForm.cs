using CustomControl.Commons;
using GUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class MessagesForm : Form
    {
        public MessagesForm()
        {
            InitializeComponent();
            this.inputMessage.KeyDown += InputMessage_KeyDown;
            this.labelSending.Click += LabelSending_Click;
            this.labelMoreAction.Click += LabelMoreAction_Click;
            this.labelEdit.Click += LabelEdit_Click;
            this.labelEdit.MouseHover += LabelEdit_MouseHover;
            this.labelEdit.MouseLeave += LabelEdit_MouseLeave;
            RegisterHoverEventsForTableLayoutPanelItems();
            LoadSampleConversations();
            //AddOutgoingMessage("hahaha");
        }        

        private void LoadSampleConversations()
        {
            //for (int i = 18; i > 0; i--)
            //{
            //    ConversationCommon conversationCommon = new ConversationCommon();
            //    conversationCommon.ConversationName = "Mthuw " + i;
            //    conversationCommon.LastestMessage = "Lastest message Lastest message Lastest message";
            //    conversationCommon.LastestTime = "•1w";
            //    conversationCommon.Dock = DockStyle.Top;

            //    conversationCommon.Click += ConversationCommon_Click;
            //    RegisterClickEventForChildControls(conversationCommon);

            //    panelConversations.Controls.Add(conversationCommon);
            //}

            // Xóa các phần tử cũ (nếu có) trong panel
            panelConversations.Controls.Clear();

            // Danh sách các mẫu `ConversationCommon` khác nhau
            List<ConversationCommon> sampleConversations = new List<ConversationCommon>();
            string[] names = { "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hannah", "Ivan", "Jack" };
            string[] lastMessages =
            {
        "Hi there, how are you?",
        "Did you get my email?",
        "Let's meet up tomorrow.",
        "Check out this new feature!",
        "I'll call you later.",
        "Thank you for the update.",
        "What's your plan for the weekend?",
        "Can you send me the report?",
        "Long time no see!",
        "Are you available for a quick chat?"
    };
            string[] times = { "•1m", "•5m", "•10m", "•30m", "•1h", "•2h", "•1d", "•2d", "•3d", "•1w" };

            // Tạo 10 `ConversationCommon` mẫu
            for (int i = times.Length - 1; i > 0; i--)
            {
                ConversationCommon conversationCommon = new ConversationCommon
                {
                    ConversationName = names[i], // Tên khác nhau
                    LastestMessage = lastMessages[i], // Tin nhắn khác nhau
                    LastestTime = times[i], // Thời gian khác nhau
                    Dock = DockStyle.Top
                };

                // Đăng ký sự kiện Click
                conversationCommon.Click += ConversationCommon_Click;
                RegisterClickEventForChildControls(conversationCommon);

                // Thêm vào danh sách mẫu
                sampleConversations.Add(conversationCommon);

                // Thêm vào panel để hiển thị
                panelConversations.Controls.Add(conversationCommon);
            }
        }

        private void LoadData(int lastDelay)
        {
            // Mảng các tin nhắn có độ dài khác nhau
            string[] messages = new string[]
            {
        "Hello!",
        "How are you doing today?",
        "This is a short message.",
        "Here is a longer message for testing purposes. Let's see how it fits in the UI.",
        "Quick question, are you available for a call?",
        "Testing, testing, 1, 2, 3!",
        "The quick brown fox jumps over the lazy dog.",
        "hahahaha thank",
        "you are welcome",
        "i love u",
        "i love u too",
        "Rx.NET makes handling asynchronous streams of data very simple!"
            };
            Observable.Range(0, messages.Length)
        .ObserveOn(SynchronizationContext.Current)
        .Subscribe(index =>
        {
            // Lấy tin nhắn theo chỉ số và thêm vào UI
            string message = messages[index];
            if (index % 2 == 0)
            {
                AddIncomingMessage(message);
            }
            else
            {
                AddOutgoingMessage(message);
            }
        },
        onCompleted: ScrollToBottom);

            // Sử dụng Rx.NET để tạo một stream với mỗi 1 giây sẽ emit ra một giá trị
            Observable.Interval(TimeSpan.FromSeconds(lastDelay))
                .Take(/*messages.Length*/1) // Lấy ra đúng số lượng tin nhắn
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(index =>
                {
                    // Lấy tin nhắn theo chỉ số và thêm vào UI
                    string message = messages[index];
                    if (index % 2 == 0)
                    {
                        AddIncomingMessage(message);
                    }
                    else
                    {
                        AddOutgoingMessage(message);
                    }
                },
                onCompleted: ScrollToBottom); // Cuộn xuống dưới cùng sau khi hoàn tất            
        }

        private void AddOutgoingMessage(string message)
        {
            // Thêm tin nhắn gửi đi
            OutgoingMessage outgoingMessage = new OutgoingMessage
            {
                Message = message,
                Time = DateTime.Now.ToString("HH:mm"),
                Dock = DockStyle.Bottom
            };

            panelMessages.Controls.Add(outgoingMessage);
            //panelMessages.Controls.SetChildIndex(outgoingMessage, 0); // Đưa lên trên cùng

            // Mô phỏng tin nhắn nhận lại
            //AddIncomingMessage($"Phản hồi: {message}");
            ScrollToBottom();
        }

        private void AddIncomingMessage(string message)
        {
            IncomingMessage incomingMessage = new IncomingMessage
            {
                Message = message,
                Time = DateTime.Now.ToString("HH:mm"),
                Dock = DockStyle.Bottom
            };

            panelMessages.Controls.Add(incomingMessage);
            //panelMessages.Controls.SetChildIndex(incomingMessage, 0); // Đưa lên trên cùng

            // Cuộn xuống dưới cùng
            ScrollToBottom();
        }

        private void ConversationSearch(string query)
        {

        }

        private void RegisterClickEventForChildControls(Control control)
        {
            foreach (Control child in control.Controls)
            {
                child.Click += (s, e) => ConversationCommon_Click(control, e);
                RegisterClickEventForChildControls(child);
            }
        }

        private void ConversationCommon_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelConversations.Controls)
            {
                if (control is ConversationCommon conversation)
                {
                    conversation.IsSelected = false;
                }
            }

            Control currentControl = sender as Control;

            while (currentControl != null && currentControl != panelConversations)
            {
                if (currentControl is ConversationCommon conversationCommon)
                {
                    conversationCommon.IsSelected = true;
                    LoadData(1);
                    break;
                }

                currentControl = currentControl.Parent;
            }
        }

        private void ScrollToBottom()
        {
            if (panelMessages.Controls.Count > 0)
            {
                panelMessages.VerticalScroll.Value = panelMessages.VerticalScroll.Maximum;
                panelMessages.PerformLayout();
                panelMessages.Invalidate();
                panelMessages.Update();
            }
        }
        private void ScrollToFirst()
        {
            if (panelMessages.Controls.Count > 0)
            {
                // Đảm bảo cuộn lên trên cùng
                panelMessages.VerticalScroll.Value = 0;
                panelMessages.PerformLayout();
                panelMessages.Invalidate();
                panelMessages.Update();
            }
        }
        
        private void RegisterHoverEventsForTableLayoutPanelItems()
        {
            foreach (Control control in tableLayoutPanelMoreActionItems.Controls)
            {
                // Kiểm tra nếu control là Label
                if (control is Label label)
                {
                    label.MouseHover += Label_MouseHover;
                    label.MouseLeave += Label_MouseLeave;
                }
            }
        }

        private void Label_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.BackColor = Color.FromArgb(48, 48, 48);
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.BackColor = Color.Transparent;
            }
        }

        private void LabelEdit_MouseLeave(object sender, EventArgs e)
        {
            this.labelEdit.Image = Resources.edit16;
            this.labelEdit.PerformLayout();
        }

        private void LabelEdit_MouseHover(object sender, EventArgs e)
        {
            this.labelEdit.Image = Resources.edit16_hover;
            this.labelEdit.PerformLayout();
        }

        private void LabelEdit_Click(object sender, EventArgs e)
        {

        }

        private void LabelMoreAction_Click(object sender, EventArgs e)
        {
            if (panelMessageSettings.Width == 4)
            {
                panelMessageSettings.Width = 280;
            }
            else
            {
                panelMessageSettings.Width = 4;
            }
            PerformLayout();
        }

        private void LabelSending_Click(object sender, EventArgs e)
        {
            inputMessage.Clear();
        }

        private void InputMessage_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu phím nhấn là Enter
            if (e.KeyCode == Keys.Enter)
            {
                if (inputMessage.Text != null)
                {
                    if (inputMessage.Text != "" && inputMessage.Text != inputMessage.Hint)
                    {
                        // Lấy nội dung tin nhắn từ inputMessage
                        string messageText = inputMessage.Text.Trim();

                        // Gọi phương thức thêm tin nhắn mới
                        AddOutgoingMessage(messageText);

                        // Xoá hết văn bản trong inputMessage
                        inputMessage.Clear();

                        // Ngăn chặn âm báo tiếng "ding"
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        e.Handled = true; // Ngăn chặn âm báo tiếng "ding"
                    }
                }
                else
                {
                    e.Handled = true; // Ngăn chặn âm báo tiếng "ding"
                }
            }
        }
    }
}
