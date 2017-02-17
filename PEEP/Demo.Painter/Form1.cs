using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.Painter
{
    public partial class Form1 : Form
    {
        Bitmap originImg;
        Image finishImg;
        Graphics g;
        Pen p = new Pen(Color.Red, 1);
        bool startDraw;
        List<Point> lstPoint = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            //设置双缓冲，避免闪烁  
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            //设置笔的属性，避免出现“毛刺”  
            p.StartCap = LineCap.Round;
            p.EndCap = LineCap.Round;
            p.LineJoin = LineJoin.Round;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            originImg = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(originImg);
            //画布背景初始化为白底    
            //g.Clear(Color.White);

            pictureBox1.Image = originImg;
            finishImg = (Image)originImg.Clone();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startDraw = true;

                lstPoint.Clear();
                lstPoint.Add(e.Location);
                finishImg = (Image)originImg.Clone();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startDraw)
            {
                g = Graphics.FromImage(finishImg);
                g.SmoothingMode = SmoothingMode.AntiAlias; //抗锯齿    

                lstPoint.Add(e.Location);
                g = Graphics.FromImage(finishImg);
                g.DrawCurve(p, lstPoint.ToArray());

                reDraw();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            startDraw = false;
            originImg = (Bitmap)finishImg;

            pictureBox1.Image = originImg;
        }

        /// <summary>    
        /// 重绘绘图区（二次缓冲技术）    
        /// </summary>    
        private void reDraw()
        {
            using (Graphics graphics = pictureBox1.CreateGraphics())
            {
                graphics.DrawImage(finishImg, new Point(0, 0));
            }
            using (MemoryStream ms = new MemoryStream())
            {
                textBox1.Text = "";
                byte[] argb = GetImagePixel(finishImg);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < argb.Length; i++)
                {
                    sb.Append(argb[i].ToString("x2") + " ");
                }
                textBox1.Text = sb.ToString();

                finishImg.Save(ms, ImageFormat.Png);
                long size = ms.Length;
                LbSize1.Text = "size: " + size + " B / ARGB: " + argb.Length;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                textBox2.Text = "";
                byte[] argb = GetImagePixel(pictureBox2.Image);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < argb.Length; i++)
                {
                    sb.Append(argb[i].ToString("x2") + " ");
                }
                textBox2.Text = sb.ToString();

                pictureBox2.Image.Save(ms, ImageFormat.Png);
                long size = ms.Length;
                LbSize2.Text = "size: " + size + " B / ARGB: " + argb.Length;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox3.Image?.Save(ms, ImageFormat.Png);
                LbSize3.Text = "size: " + ms.Length + " B";
            }
        }
        public byte[] GetImagePixel(Image img)
        {
            return GetImagePixel(new Bitmap(img));
        }
        public byte[] GetImagePixel(Bitmap img)
        {
            byte[] result = new byte[img.Width * img.Height * 4];
            int n = 0;
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    result[n] = img.GetPixel(i, j).A;
                    result[n + 1] = img.GetPixel(i, j).R;
                    result[n + 2] = img.GetPixel(i, j).G;
                    result[n + 3] = img.GetPixel(i, j).B;
                    n += 4;
                }
            }
            return result;
        }
    }
}
