using DTO;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public class AvatarCommon: PictureBox
    {
        public UserSummary CurrentUser { get; set; }
        public AvatarCommon()
        {
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath grpath = new GraphicsPath();
            grpath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grpath);
            base.OnPaint(pe);
        }
    }
}
