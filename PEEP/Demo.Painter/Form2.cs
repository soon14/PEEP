using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Demo.Painter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            LbStatus.Text = string.Format("Time: {0} ms", (DateTime.Now - dt).TotalMilliseconds);
        }
        private void FindDiff1()
        {
            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;
            Bitmap img = new Bitmap(width, height);
            int index = 0;
            byte[] p1Byte = GetImagePixel(new Bitmap(pictureBox1.Image));
            byte[] p2Byte = GetImagePixel(new Bitmap(pictureBox2.Image));
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (p1Byte[index] != p2Byte[index] || p1Byte[index + 1] != p2Byte[index + 1] ||
                        p1Byte[index + 2] != p2Byte[index + 2] || p1Byte[index + 3] != p2Byte[index + 3])
                    {
                        img.SetPixel(i, j,
                            Color.FromArgb(p2Byte[index], p2Byte[index + 1],
                            p2Byte[index + 2], p2Byte[index + 3]));
                    }
                    index += 4;
                }
            }
            pictureBox3.Image = img;
            img.Save(@"D:\Temp\desktop\" + Guid.NewGuid() + ".png", ImageFormat.Png);
        }
        private void FindDiff2()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;
            Bitmap img = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (b1.GetPixel(i, j) != b2.GetPixel(i, j))
                    {
                        img.SetPixel(i, j, b2.GetPixel(i, j));
                    }
                }
            }
            pictureBox3.Image = img;
            img.Save(@"D:\Temp\desktop\" + Guid.NewGuid() + ".png", ImageFormat.Png);
        }
        private void FindDiff3()
        {
            Emgu.CV.Image<Bgra, byte> Image1 = new Emgu.CV.Image<Bgra, byte>((Bitmap)pictureBox1.Image);
            Emgu.CV.Image<Bgra, byte> Image2 = new Emgu.CV.Image<Bgra, byte>((Bitmap)pictureBox2.Image);
            Emgu.CV.Image<Bgra, byte> Image3 = Image1.Sub(Image2);
            pictureBox3.Image = Image3.ToBitmap();
            Image3.Save(@"D:\Temp\desktop\1.png");
        }
        public byte[] GetImagePixel(Bitmap img)
        {
            byte[] result = new byte[img.Width * img.Height * 4];
            int n = 0;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color color = img.GetPixel(i, j);
                    result[n] = color.A;
                    result[n + 1] = color.R;
                    result[n + 2] = color.G;
                    result[n + 3] = color.B;
                    n += 4;
                }
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap img = (Bitmap)pictureBox1.Image;
            Dictionary<Color, List<Pt>> info = new Dictionary<Color, List<Pt>>();
            int colorCount = 0, ptCount = 0, n = 0;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color tmp = img.GetPixel(i, j);
                    Color color = Color.FromArgb(tmp.A, (tmp.R / 10 * 10), (tmp.G / 10 * 10), (tmp.B / 10 * 10));
                    if (!info.ContainsKey(color))
                    {
                        info.Add(color, new List<Pt>());
                        info[color].Add(new Pt() { X = i, Y = j });
                        colorCount++;
                    }
                    else
                    {
                        info[color].Add(new Pt() { X = i, Y = j });
                    }
                    ptCount++;
                    n += 4;
                }
            }
            label1.Text = string.Format("信息总长度: {0}  {1}", colorCount, ptCount);
        }
    }
    class Pt
    {
        public int X;
        public int Y;
    }
}
