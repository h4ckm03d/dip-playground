using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageLib
{

    public struct ByteColor
    {
        public byte R;
        public byte G;
        public byte B;
    }

    public class ByteImage
    {
        public ByteColor[] byteImage;
        public int[] PosY;
        public int Height;
        public int Width;

        public ByteColor this[int x, int y]
        {
            get { return byteImage[x + PosY[y]]; }
            set { byteImage[x + PosY[y]] = value; }
        }
        
        public ByteImage(int iWidth, int iHeight)
        {
            Width = iWidth;
            Height = iHeight;
            PosY = new int[Height];
            PosY[0] = 0;
            for (int x = 1; x < Height; x++)
                PosY[x] = PosY[x - 1] + Width;
            byteImage = new ByteColor[Width * Height];
        }

        public void SetAll(int x, int y, byte R, byte G, byte B)
        {
            int idx = x + PosY[y];
            byteImage[idx].B = B;
            byteImage[idx].G = G;
            byteImage[idx].R = R;
        }

        public void SetByteColor(int x, int y, ByteColor value)
        {
            byteImage[x + PosY[y]] = value;
        }
        public ByteColor GetByteColor(int x, int y)
        {
            return byteImage[x + PosY[y]];
        }

        // Static method
        public static ByteImage convertBitmapToByteImage(Bitmap bitmapImage)
        {
            BitmapData bdInputImage = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte PixelSize = 3; // Red Green Blue

            // set array segment 
            ByteImage byImage = new ByteImage(bitmapImage.Width, bitmapImage.Height);

            unsafe
            {
                byte* pInputImage = (byte*)(void*)bdInputImage.Scan0;
                // details explanation about stride image, http://www.codersource.net/csharp_image_Processing.aspx
                int nOffset = bdInputImage.Stride - bdInputImage.Width * PixelSize;
                for (int y = 0; y < bdInputImage.Height; y++)
                {
                    for (int x = 0; x < bdInputImage.Width; x++)
                    {
                        byImage.SetAll(x, y, pInputImage[2], pInputImage[1], pInputImage[0]);
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
            Bitmap bitmapImage = new Bitmap(byImage.Width, byImage.Height);
            BitmapData bdImgSegment = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte PixelSize = 3; // Red Green Blue

            unsafe
            {
                byte* pImgSegmented = (byte*)(void*)bdImgSegment.Scan0;
                int nOffset = bdImgSegment.Stride - bdImgSegment.Width * PixelSize;
                int idx = 0;
                for (int y = 0; y < bdImgSegment.Height; y++)
                {
                    for (int x = 0; x < bdImgSegment.Width; x++)
                    {
                        idx = x + y * byImage.Width;
                        pImgSegmented[0] = byImage[x, y].B;
                        pImgSegmented[1] = byImage[x, y].G;
                        pImgSegmented[2] = byImage[x, y].R;
                        pImgSegmented += PixelSize;
                    }
                    pImgSegmented += nOffset;
                }
            }

            bitmapImage.UnlockBits(bdImgSegment);
            return bitmapImage;
        }

        public static ByteImage copyValue(ByteImage input)
        {
            ByteImage result = new ByteImage(input.Width, input.Height);
            for (int y = 0; y < result.Height; y++)
            {
                for (int x = 0; x < result.Width; x++)
                {
                    result[x, y]= input[x, y];
                }
            }
            return result;
        }

    }
}
