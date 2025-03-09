using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public class ContainerCommon : Panel
    {
        // Thuộc tính Radius để tùy chỉnh độ bo góc
        private int _radius = 20;
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                this.Invalidate(); // Vẽ lại khi thay đổi bán kính
            }
        }

        public ContainerCommon()
        {
            // Thiết lập DoubleBuffered để giảm nhấp nháy
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Radius > 0)
            {
                // Tạo GraphicsPath với bo góc
                using (GraphicsPath path = new GraphicsPath())
                {
                    int diameter = Radius * 2;

                    // Bo góc trên bên trái
                    path.AddArc(0, 0, diameter, diameter, 180, 90);

                    // Đường thẳng cạnh trên
                    path.AddLine(Radius, 0, this.Width - Radius, 0);

                    // Bo góc trên bên phải
                    path.AddArc(this.Width - diameter, 0, diameter, diameter, 270, 90);

                    // Đường thẳng cạnh phải
                    path.AddLine(this.Width, Radius, this.Width, this.Height - Radius);

                    // Bo góc dưới bên phải
                    path.AddArc(this.Width - diameter, this.Height - diameter, diameter, diameter, 0, 90);

                    // Đường thẳng cạnh dưới
                    path.AddLine(this.Width - Radius, this.Height, Radius, this.Height);

                    // Bo góc dưới bên trái
                    path.AddArc(0, this.Height - diameter, diameter, diameter, 90, 90);

                    // Đường thẳng cạnh trái
                    path.AddLine(0, this.Height - Radius, 0, Radius);

                    path.CloseFigure();

                    // Thiết lập vùng hiển thị với bo góc
                    this.Region = new Region(path);

                    // Tô màu nền cho Panel
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Brush brush = new SolidBrush(this.BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }
            }            
        }
    }
}
