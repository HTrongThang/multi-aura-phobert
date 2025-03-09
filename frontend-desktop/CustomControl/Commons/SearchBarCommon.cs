using CustomControl.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class SearchBarCommon : UserControl
    {
        public event EventHandler OnEnter;
        public string Query
        {
            get => textBoxSearch.Text != Hint? (textBoxSearch.Text ?? "") : "";
            set
            {
                if (textBoxSearch.Text != value)
                {
                    textBoxSearch.Text = value;
                }
            }
        }
        private string hint;
        public string Hint { 
            get => hint;
            set
            {
                hint = value;
                SetUpUI();
            }
        }

        public SearchBarCommon()
        {
            InitializeComponent();
            SetUpUI();
            SetUpActions();
        }

        public void SetUpUI()
        {
            if (Hint == null)
            {
                Hint = "Search...";
            }

            SetUpUISearch();
        }
        private void SetUpActions()
        {
            labelClear.Click += LabelClear_Click;
            textBoxSearch.KeyPress += TextBoxSearch_KeyPress;
        }

        private void TextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                OnEnter?.Invoke(this, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void LabelClear_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != Hint)
            {
                textBoxSearch.Text = string.Empty;
            }
        }

        private void SetUpUISearch()
        {
            textBoxSearch.Text = Hint;
            textBoxSearch.ForeColor = Color.FromArgb(79, 79, 79);
            textBoxSearch.Enter += TextBoxSearch_Enter;
            textBoxSearch.Leave += TextBoxSearch_Leave;

            this.labelSearch.MouseHover += LabelSearchMouseHover;
            this.labelSearch.MouseLeave += LabelSearchMouseLeave;

            this.labelClear.MouseHover += LabelClearMouseHover;
            this.labelClear.MouseLeave += LabelClearMouseLeave;
        }
        private void LabelSearchMouseHover(object sender, EventArgs e)
        {
            ((Label)sender).Image = Resources.search16_white;
        }
        private void LabelSearchMouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).Image = Resources.search;
        }

        private void LabelClearMouseHover(object sender, EventArgs e)
        {
            ((Label)sender).Image = Resources.clear16_white;
        }
        private void LabelClearMouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).Image = Resources.clear16;
        }

        private void TextBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == Hint)
            {
                textBoxSearch.Text = string.Empty;
                textBoxSearch.ForeColor = Color.FromArgb(220, 220, 220);
            }
        }
        private void TextBoxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                textBoxSearch.Text = Hint;
                textBoxSearch.ForeColor = Color.FromArgb(79, 79, 79);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radius = Height;
            using (GraphicsPath path = new GraphicsPath())
            {
                // Bo tròn góc trên bên trái
                path.AddArc(0, 0, radius, radius, 180, 90);

                // Đường thẳng ở cạnh trên từ góc trái đến góc phải
                path.AddLine(radius, 0, Width - radius, 0);

                // Bo tròn góc trên bên phải
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);

                // Đường thẳng ở cạnh phải từ góc trên đến góc dưới
                path.AddLine(Width, radius, Width, Height - radius);

                // Bo tròn góc dưới bên phải
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);

                // Đường thẳng ở cạnh dưới từ góc phải đến góc trái
                path.AddLine(Width - radius, Height, radius, Height);

                // Bo tròn góc dưới bên trái
                path.AddArc(0, Height - radius, radius, radius, 90, 90);

                // Đường thẳng ở cạnh trái từ góc dưới đến góc trên
                path.AddLine(0, Height - radius, 0, radius);

                path.CloseFigure();

                // Thiết lập vùng vẽ để bo góc
                this.Region = new Region(path);
            }
        }
    }
}
