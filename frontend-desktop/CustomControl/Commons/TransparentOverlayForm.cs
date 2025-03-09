using System.Drawing;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public class TransparentOverlayForm : Form
    {
        public TransparentOverlayForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;
            this.Opacity = 0.5; // Đặt độ trong suốt
            this.ShowInTaskbar = false;
            this.TopMost = true; // Đặt lên trên cùng
        }
    }
}
