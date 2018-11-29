using ImageToucher.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = false;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(this.openFileDialog1.FileName);
                //string err = string.Empty;
                //Image image2 = ImageUtil.GetImageThumb(img, new Size(img.Width/2, img.Height/2));
                //ImageUtil.GetThumbnailImage("test.jpg", this.openFileDialog1.FileName, img.Width /2, img.Height/2, 95, out err);
                this.imageToucherUserControl1.SrcImage = img;
                List<Rectangle> rects = new List<Rectangle>();
                List<Rectangle> after = rects.Select(r => {
                    Point p = new Point();
                    p.X = (int)(r.Left * 0.8);
                    return new Rectangle((int)(r.Left * 0.8), (int)(r.Top * 0.8), (int)(r.Width * 0.8), (int)(r.Height * 0.8));
                }).ToList();
            }
        }
    }
}
