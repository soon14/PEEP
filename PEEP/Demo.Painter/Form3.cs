using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.TimeUtils;
using Y.Utils.WindowsAPI;

namespace Demo.Painter
{
    public partial class Form3 : Form
    {
        Rectangle ScreenArea;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ScreenArea = Screen.GetBounds(this);

            //DateTime dt = DateTime.Now;
            //Bitmap b = ScreenCapture.Capture();
            //pictureBox1.Image = b;
            //label1.Text = "time: " + (DateTime.Now - dt).TotalMilliseconds + " ms";

            Screen1();
        }
        private void Screen1()
        {
            Task.Factory.StartNew(() =>
            {
                TimerTool tt = new TimerTool();
                Bitmap b = null;
                while (true)
                {
                    tt.Begin();
                    Graphics pictureG = pictureBox1.CreateGraphics();
                    b = ScreenCapture.Capture();

                    Graphics cursorG = Graphics.FromImage(b);
                    ScreenCapture.DrawCursorImageToScreenImage(ref cursorG);

                    pictureG.DrawImage(b, 0, 0, pictureBox1.Width, pictureBox1.Height);

                    b?.Dispose();
                    BeginInvoke(new Action(() =>
                    {
                        label1.Text = string.Format("{0} × {1}  time: {2} ms",
                            pictureBox1.Width, pictureBox1.Height, tt.ms);
                    }));

                    cursorG.Dispose();
                    pictureG.Dispose();
                    Thread.Sleep(10);
                }
            });
        }
        private void Screen2()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Size s = new Size(1366, 768);
                    Graphics pg = pictureBox1.CreateGraphics();
                    pg.CopyFromScreen(0, 0, 0, 0, s);
                    pg.Dispose();
                }
            });
        }

        private void label1_Click(object sender, EventArgs e)
        {
            using (HatchBrush br = new HatchBrush(HatchStyle.DiagonalBrick, Color.Red, Color.Pink))
            {
                Graphics pg = pictureBox1.CreateGraphics();
                pg.FillRectangle(br, 0, 0, ScreenArea.Width, ScreenArea.Height);
                pg.DrawRectangle(Pens.Red, 0, 0, ScreenArea.Width, ScreenArea.Height);
                pg.Dispose();
            }
        }
    }
}
