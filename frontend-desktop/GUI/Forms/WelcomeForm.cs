using GUI.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
            this.EnableWindowDrag(panelWindownControlTaskBar);
            this.EnableWindowResize();
            this.EnableWindowControlButtons(
                this.MinimizeWindowControlButton,
                this.MaximizeWindowControlButton,
                this.CloseWindowControlButton
                );
            this.FormClosed += (sender, e) => Application.Exit();
        }
    }
}
