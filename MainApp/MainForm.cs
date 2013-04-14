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
        private void btnBW_Click(object sender, EventArgs e)
        {
            _targetByteImage = ToBlackAndWhite(_targetByteImage);
            _targetImage = ByteImage.convertByteImageToBitmap(_targetByteImage);
            pbImage.Image = _targetImage;
            Diameter dm = GetDiameterHeight(_targetByteImage);
            lblHeightDiameter.Text = dm.Height.ToString();
            lblWidthDiameter.Text = dm.Width.ToString();
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
            if (image == null)
                return null;
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
        public ByteImage ToBlackAndWhite(ByteImage image)
        {
            if (image == null)
                return null;
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    image.byteImage[x, y].R = image.byteImage[x, y].G = image.byteImage[x, y].B =
                        (byte)((0.2126 * image.getR(x, y) + 0.7152 * image.getG(x, y) + 0.0722 * image.getB(x, y)) > 234 ? 255 : 0);
                    //(byte)((image.getR(x, y) + image.getG(x, y) + image.getB(x, y))/3);
                }
            }
            return image;
        }

        private Diameter GetDiameterHeight(ByteImage image)
        {
            int from=-1, to=-1;
            int diameter = 0;
            int position = 0;
            int maxHeightDiameter = int.MinValue;
            int maxWidthDiameter = int.MinValue;
            for (int i = 0; i < image.Width; i++)
            {
                from = -1;
                to = -1;
                for (int j = 0; j < image.Height; j++)
                {
                    if (image.getB(i, j) == 0)
                    {
                        from = j;
                        break;
                    }
                }
                if (from != -1)
                {
                    for (int j = image.Height-1; j >0 ; j--)
                    {
                        if (image.getB(i, j) == 0)
                        {
                            to = j;
                            break;
                        }
                    }
                }
                diameter = to - from;
                if (diameter > maxHeightDiameter)
                {
                    position = i;
                    maxHeightDiameter = diameter;
                }
            }

            for (int i = 0; i < image.Height; i++)
            {
                image.byteImage[position, i].R = image.byteImage[position, i].G = image.byteImage[position, i].B = 0;
            }

            //width
            for (int i = 0; i < image.Height; i++)
            {
                from = -1;
                to = -1;
                for (int j = 0; j < image.Width; j++)
                {
                    if (image.getB(j, i) == 0)
                    {
                        from = j;
                        break;
                    }
                }
                if (from != -1)
                {
                    for (int j = image.Width - 1; j > 0; j--)
                    {
                        if (image.getB(j, i) == 0)
                        {
                            to = j;
                            break;
                        }
                    }
                }
                diameter = to - from;
                if (diameter > maxWidthDiameter)
                {
                    position = i;
                    maxWidthDiameter = diameter;
                }
            }

            for (int i = 0; i < image.Width; i++)
            {
                image.byteImage[i, position].R = image.byteImage[i, position].G = image.byteImage[i, position].B = 0;
            }

            pictureBox1.Image = ByteImage.convertByteImageToBitmap(image);
            return new Diameter(maxWidthDiameter,maxHeightDiameter);
        }

        #endregion

    }
}
