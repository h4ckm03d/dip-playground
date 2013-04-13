using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageLib
{

    struct ByteColor
    {
        public byte R;
        public byte G;
        public byte B;
    }

    class ByteImage
    {
        public ByteColor[,] byteImage;
        public int Height;
        public int Width;

        public ByteImage(int iWidth, int iHeight)
        {
            Width = iWidth;
            Height = iHeight;
            byteImage = new ByteColor[Width, Height];
        }

        public byte getR(int x, int y)
        {
            return byteImage[x, y].R;
        }

        public byte getG(int x, int y)
        {
            return byteImage[x, y].G;
        }

        public byte getB(int x, int y)
        {
            return byteImage[x, y].B;
        }

        // Static method
        public static ByteImage convertBitmapToByteImage(Bitmap bitmapImage)
        {
            BitmapData bdInputImage = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte PixelSize = 3; // Red Green Blue

            // set dimensi array segmen sesuai dengan dimensi gambar
            ByteImage byImage = new ByteImage(bitmapImage.Width, bitmapImage.Height);

            unsafe
            {
                byte* pInputImage = (byte*)(void*)bdInputImage.Scan0;
                // kelebihan set, lihat http://www.codersource.net/csharp_image_Processing.aspx
                int nOffset = bdInputImage.Stride - bdInputImage.Width * PixelSize;

                for (int y = 0; y < bdInputImage.Height; y++)
                {
                    for (int x = 0; x < bdInputImage.Width; x++)
                    {
                        byImage.byteImage[x, y].R = pInputImage[2];
                        byImage.byteImage[x, y].G = pInputImage[1];
                        byImage.byteImage[x, y].B = pInputImage[0];
                        pInputImage += PixelSize;
                    }
                    pInputImage += nOffset;
                }
            }

            bitmapImage.UnlockBits(bdInputImage);
            return byImage;
        }

        public static Bitmap convertByteImageToBitmap(ByteImage byImage)
        {
            Bitmap skinHairSegment = new Bitmap(byImage.Width, byImage.Height);
            BitmapData bdImgSegment = skinHairSegment.LockBits(new Rectangle(0, 0, skinHairSegment.Width, skinHairSegment.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte PixelSize = 3; // Red Green Blue

            unsafe
            {
                byte* pImgSegmented = (byte*)(void*)bdImgSegment.Scan0;
                // kelebihan set, lihat http://www.codersource.net/csharp_image_Processing.aspx
                int nOffset = bdImgSegment.Stride - bdImgSegment.Width * PixelSize;

                for (int y = 0; y < bdImgSegment.Height; y++)
                {
                    for (int x = 0; x < bdImgSegment.Width; x++)
                    {
                        pImgSegmented[0] = byImage.getB(x, y);
                        pImgSegmented[1] = byImage.getG(x, y);
                        pImgSegmented[2] = byImage.getR(x, y);
                        pImgSegmented += PixelSize;
                    }
                    pImgSegmented += nOffset;
                }
            }

            skinHairSegment.UnlockBits(bdImgSegment);
            return skinHairSegment;
        }

        public static ByteImage copyValue(ByteImage input)
        {
            ByteImage result = new ByteImage(input.Width, input.Height);
            for (int y = 0; y < result.Height; y++)
            {
                for (int x = 0; x < result.Width; x++)
                {
                    result.byteImage[x, y] = input.byteImage[x, y];
                }
            }
            return result;
        }

    }
}
