/*----------------------------------------------------------------
        // Copyright (C) 2007 L3'Studio
        // 版权所有。 
        // 开发者：L3'Studio团队
        // 文件名：ScreenCapture.cs
        // 文件功能描述：屏幕捕获（带有压缩）。
//----------------------------------------------------------------*/

using System;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ICanSeeYou.Windows
{
    /// <summary>
    /// 屏幕捕获类
    /// </summary>
    public class ScreenCapture
    {
        /// <summary>
        /// 把当前屏幕捕获到位图对象中
        /// </summary>
        /// <param name="hdcDest">目标设备的句柄</param>
        /// <param name="nXDest">目标对象的左上角的X坐标</param>
        /// <param name="nYDest">目标对象的左上角的X坐标</param>
        /// <param name="nWidth">目标对象的矩形的宽度</param>
        /// <param name="nHeight">目标对象的矩形的长度</param>
        /// <param name="hdcSrc">源设备的句柄</param>
        /// <param name="nXSrc">源对象的左上角的X坐标</param>
        /// <param name="nYSrc">源对象的左上角的X坐标</param>
        /// <param name="dwRop">光栅的操作值</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
        IntPtr hdcDest,
        int nXDest,
        int nYDest,
        int nWidth,
        int nHeight,
        IntPtr hdcSrc,
        int nXSrc,
        int nYSrc,
        int dwRop
        );

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr CreateDC(
        string lpszDriver, // 驱动名称
        string lpszDevice, // 设备名称
        string lpszOutput, // 无用，可以设定位"NULL"
        IntPtr lpInitData // 任意的打印机数据
        );

        /// <summary>
        /// 屏幕捕获到位图对象中
        /// </summary>
        /// <returns></returns>
        public static Image Capture()
        {
            //创建显示器的DC
            IntPtr dc1 = CreateDC("DISPLAY", null, null, (IntPtr)null);
            //由一个指定设备的句柄创建一个新的Graphics对象
            Graphics g1 = Graphics.FromHdc(dc1);
            //根据屏幕大小创建一个与之相同大小的Bitmap对象
            Bitmap ScreenImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, g1);

            Graphics g2 = Graphics.FromImage(ScreenImage);
            //获得屏幕的句柄
            IntPtr dc3 = g1.GetHdc();
            //获得位图的句柄
            IntPtr dc2 = g2.GetHdc();
            //把当前屏幕捕获到位图对象中
            BitBlt(dc2, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, dc3, 0, 0, 13369376);
            //释放屏幕句柄
            g1.ReleaseHdc(dc3);
            //释放位图句柄
            g2.ReleaseHdc(dc2);

            //压缩图片
            Image bmp = MakeThumbnail(ScreenImage, ScreenImage.Width * 3 / 4, ScreenImage.Height * 3 / 4);
            //ScreenImage.SetResolution(800,600);
            return bmp;
        }

        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="originalImage"></param>
        public static Image  MakeThumbnail(Image originalImage, int towidth,int toheight)
        {
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;       
     
            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置低质量,高速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);
            return bitmap;
        }
    }
}
