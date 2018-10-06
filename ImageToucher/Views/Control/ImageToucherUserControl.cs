using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageToucher.Views.Control
{
    internal enum ZoomType
    {
        /// <summary>
        /// 放大
        /// </summary>
        ZoomIn,
        /// <summary>
        /// 缩小
        /// </summary>
        ZoomOut,
        /// <summary>
        /// 自动缩放
        /// </summary>
        Auto,
        /// <summary>
        /// 原图
        /// </summary>
        Origin
    }

    public partial class ImageToucherUserControl : UserControl
    {
        /// <summary>
        /// 原始图像
        /// </summary>
        private Image _srcImage;
        /// <summary>
        /// 缩放比例（默认原图比例1:1）
        /// 原图长宽始终不会改变，缩放比例乘以原图长宽只会更改PictureBox的长宽
        /// 同时放置PictureBox的Panel（此处为panelPicPnl）的长宽固定，且打开AutoSrcoll选项
        /// 让PictureBox在Panel内自由变化
        /// 同时使用缩放比例生成对应的展示的Image渲染到PictureBox中
        /// </summary>
        private double _scale = 1.0;
        /// <summary>
        /// 放大最大比例
        /// </summary>
        private const double MAX_SCALE = 3.0;
        /// <summary>
        /// 缩小最小比例
        /// </summary>
        private const double MIN_SCALE = 0.3;
        /// <summary>
        /// 比例变化度
        /// </summary>
        private const double SCALE_GAP = 0.1;
        /// <summary>
        /// 鼠标进入PictureBox拖动图像状态标志
        /// </summary>
        private bool _moving = false;
        /// <summary>
        /// 鼠标在PictureBox中按下准备拖动的位置坐标
        /// </summary>
        private Point posInPicBox = new Point(0, 0);
        public ImageToucherUserControl()
        {
            InitializeComponent();
        }
        
        public Image SrcImage
        {
            get
            {
                return this._srcImage;
            }
            set
            {
                this._srcImage = value;
                zoomImage(ZoomType.Auto);
            }
        }
        /// <summary>
        /// 缩放类型生成缩放比例
        /// </summary>
        /// <param name="zoomType"></param>
        private void zoomImage(ZoomType zoomType)
        {
            if (this._srcImage == null)
            {
                return;
            }
            switch (zoomType)
            {
                case ZoomType.ZoomIn:
                    if (this._scale < MAX_SCALE)
                    {
                        this._scale += SCALE_GAP;
                    }
                    break;
                case ZoomType.ZoomOut:
                    if (this._scale > MIN_SCALE)
                    {
                        this._scale -= SCALE_GAP;
                    }
                    break;
                case ZoomType.Origin:
                    this._scale = 1.0;
                    break;
                case ZoomType.Auto:
                    this._scale = 1.0;
                    // 计算放置PictureBox的Panel的长宽与原始图像的比例
                    // 取最小值即可得到最适应的缩放比
                    this._scale = Math.Min(this._scale, Convert.ToDouble(this.panelPicPnl.Width - 10) / this._srcImage.Width);
                    this._scale = Math.Min(this._scale, Convert.ToDouble(this.panelPicPnl.Height - 10) / this._srcImage.Height);
                    break;
                default:
                    this._scale = 1.0;
                    break;
            }
            showImage();
        }
        /// <summary>
        /// 根据缩放比例构建PictureBox的长宽并向其中渲染缩放比例之后的图像
        /// </summary>
        private void showImage()
        {
            // 计算得到PictureBox的宽、高
            this.pictureBox1.Width = (int)Math.Floor(this._scale * this._srcImage.Width);
            this.pictureBox1.Height = (int)Math.Floor(this._scale * this._srcImage.Height);
            // 定位PictureBox在PicPnl中的左右定位（实现当缩小到一定程度以后图像左右居中）
            int widthGap = (this.panelPicPnl.Width - 6) - this.pictureBox1.Width;
            if (widthGap >= 0)
            {
                this.pictureBox1.Left = widthGap / 2;
            }
            // 同理，上下定位
            int heightGap = (this.panelPicPnl.Height - 6) - this.pictureBox1.Height;
            if (heightGap >= 0)
            {
                this.pictureBox1.Top = heightGap / 2;
            }
            // 生成仅仅供展示的对应比例的位图
            Image showImage = new Bitmap(_srcImage, new Size(this.pictureBox1.Width, this.pictureBox1.Height));
            this.pictureBox1.Image = showImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zoomImage(ZoomType.Auto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zoomImage(ZoomType.ZoomIn);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zoomImage(ZoomType.ZoomOut);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            zoomImage(ZoomType.Origin);
        }
        /// <summary>
        /// 鼠标开始点击PictureBox区域准备拖动图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this._moving = true;
            // 记录鼠标点击时的坐标
            posInPicBox = new Point(e.X, e.Y);
        }
        /// <summary>
        /// 鼠标在PictureBox中移动，且已经点击图像，拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._moving)
            {
                this.pictureBox1.Left += e.X - posInPicBox.X;
                this.pictureBox1.Top += e.Y - posInPicBox.Y; 
            }
        }
        /// <summary>
        /// 鼠标松开图像拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this._moving = false;
            this.posInPicBox = new Point(0, 0);
        }
    }
}
