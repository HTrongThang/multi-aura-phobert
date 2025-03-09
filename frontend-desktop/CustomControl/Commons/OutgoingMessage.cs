using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class OutgoingMessage : UserControl
    {
        private string message;
        private string time;

        public string Message
        {
            get => message;
            set
            {
                if (message != value)  // Kiểm tra xem giá trị có thay đổi không
                {
                    message = value;
                    UpdateUI();
                }
            }
        }

        public string Time
        {
            get => time;
            set
            {
                if (time != value)  // Kiểm tra xem giá trị có thay đổi không
                {
                    time = value;
                    UpdateUI();
                }
            }
        }

        public OutgoingMessage()
        {
            InitializeComponent();
            //this.MaximumSize = new Size(354, 8800);
            //this.containerCommonMessage.MaximumSize = new Size(354, 8800);

            // Khởi tạo giá trị mặc định
            message = string.Empty;
            time = string.Empty;
            // Cập nhật giao diện với giá trị khởi tạo
            UpdateUI();
        }

        public OutgoingMessage(string message, string time)
        {
            InitializeComponent();
            //this.MaximumSize = new Size(354, 8900);
            //this.containerCommonMessage.MaximumSize = new Size(354, 8800);

            this.message = message;
            this.time = time;
            UpdateUI();
        }

        private void UpdateUI()
        {
            // Đảm bảo kiểm tra null trước khi cập nhật UI
            this.labelMessage.Text = message ?? string.Empty;
            //this.textBoxMessage.Text = message ?? string.Empty;
            this.labelTime.Text = time ?? string.Empty;
        }

        // Vô hiệu hóa focus khi click vào control
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Parent?.Focus(); // Chuyển focus sang control cha
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.Parent?.Focus(); // Chuyển focus sang control cha khi click vào
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.Parent?.Focus(); // Ngăn chặn focus
        }

        protected override void OnLostFocus(EventArgs e)
        {
            // Không làm gì khi mất focus
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
            base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            e.Handled = true;
            base.OnKeyUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            // Không làm gì khi chuột hover
        }

        protected override void OnMouseHover(EventArgs e)
        {
            // Không làm gì khi chuột hover
        }
    }
}
