using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageLib;
using System.IO;

namespace MainApp
{
    public partial class MainForm : Form
    {
        private Bitmap _targetImage;
        private String _targetPath;
        private ByteImage _targetByteImage;

        public MainForm()
        {
            InitializeComponent();
        }


        #region Form Handler
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
        private void btnResetImage_Click(object sender, EventArgs e)
        {
            ReloadImage();
        }
        private void btnToGrayScale_Click(object sender, EventArgs e)
        {
            _targetByteImage = ToGrayScale(_targetByteImage);
            _targetImage = ByteImage.convertByteImageToBitmap(_targetByteImage);
            pbImage.Image = _targetImage;
        }
        #endregion

        #region Form Action

        /// <summary>
        /// Load Image from Computer
        /// </summary>
        public void LoadImage()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _targetPath = ofd.FileName;
                    ReloadImage();
                }
            }
        }

        public void ReloadImage()
        {
            if (!string.IsNullOrEmpty(_targetPath) && File.Exists(_targetPath))
            {
                _targetImage = new Bitmap(_targetPath);
                _targetByteImage = ByteImage.convertBitmapToByteImage(_targetImage);
                pbImage.Image = _targetImage;
            }
            else
            {
                MessageBox.Show("Current Target path is empty, please load image first");
            }
        }

        public ByteImage ToGrayScale(ByteImage image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    image.byteImage[x, y].R = image.byteImage[x, y].G = image.byteImage[x, y].B =
                        (byte)(0.2126 * image.getR(x, y) + 0.7152 * image.getG(x, y) + 0.0722 * image.getB(x, y));
                        //(byte)((image.getR(x, y) + image.getG(x, y) + image.getB(x, y))/3);
                }
            }
            return image;
        }
        #endregion
    }
}
