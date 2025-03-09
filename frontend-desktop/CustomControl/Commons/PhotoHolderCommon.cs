using CustomControl.Properties;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class PhotoHolderCommon : UserControl
    {
        public event EventHandler<string> OnPhotoRemoved;

        private string _photoPath;

        public string PhotoPath
        {
            get => _photoPath;
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value) || !File.Exists(value))
                    {
                        throw new FileNotFoundException("Invalid file path or file does not exist.");
                    }

                    _photoPath = value;
                    this.pictureBox.Image = Image.FromFile(value);
                }
                catch
                {
                    _photoPath = null;
                    this.pictureBox.Image = Resources.error_image;
                }
            }
        }

        public PhotoHolderCommon()
        {
            InitializeComponent();
            this.buttonClose.Click += ButtonClose_Click;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            OnPhotoRemoved?.Invoke(this, PhotoPath);
            this.Dispose();
        }
    }
}
