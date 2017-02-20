using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.WindowsAPI;

namespace Demo.Painter
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //DateTime dt = DateTime.Now;
            //Bitmap b = ScreenCapture.Capture();
            //pictureBox1.Image = b;
            //label1.Text = "time: " + (DateTime.Now - dt).TotalMilliseconds + " ms";

            Task.Factory.StartNew(() =>
            {
                Bitmap b = null;
                while (true)
                {
                    DateTime dt = DateTime.Now;
                    b = ScreenCapture.Capture();
                    BeginInvoke(new Action(() =>
                    {
                        pictureBox1.Image = b;
                        label1.Text = "time: " + (DateTime.Now - dt).TotalMilliseconds + " ms";
                    }));
                    Thread.Sleep(100);
                    b?.Dispose();
                }
            });
        }
    }
}
