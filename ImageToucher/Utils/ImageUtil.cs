using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace ImageToucher.Utils
{
    public static class ImageUtil
    {
        /// <summary>
        /// 生成高质量缩略图（固定宽高），不一定保持原宽高比
        /// </summary>
        /// <param name="destPath">目标保存路径</param>
        /// <param name="srcPath">源文件路径</param>
        /// <param name="width">生成缩略图的宽度，设置为0，则与源图比处理</param>
        /// <param name="height">生成缩略图的高度，设置为0，则与源图等比例处理</param>
        /// <param name="quality">1~100整数,无效值则取默认值95</param>
        /// <param name="mimeType">如 image/jpeg</param>    
        public static bool GetThumbnailImage(string destPath, string srcPath, int destWidth, int destHeight, int quality, out string error, string mimeType = "image/jpeg")
        {
            bool retVal = false;
            error = string.Empty;
            //宽高不能小于0
            if (destWidth < 0 || destHeight < 0)
            {
                error = "目标宽高不能小于0";
                return retVal;
            }
            //宽高不能同时为0
            if (destWidth == 0 && destHeight == 0)
            {
                error = "目标宽高不能同时为0";
                return retVal;
            }
            Image srcImage = null;
            Image destImage = null;
            Graphics graphics = null;
            try
            {
                //获取源图像
                srcImage = Image.FromFile(srcPath, false);
                //计算高宽比例
                float d = (float)srcImage.Height / srcImage.Width;
                //如果输入的宽为0，则按高度等比缩放
                if (destWidth == 0)
                {
                    destWidth = Convert.ToInt32(destHeight / d);
                }
                //如果输入的高为0，则按宽度等比缩放
                if (destHeight == 0)
                {
                    destHeight = Convert.ToInt32(destWidth * d);
                }
                //定义画布
                destImage = new Bitmap(destWidth, destHeight);
                //获取高清Graphics
                graphics = GetGraphics(destImage);
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                //将源图像画到画布上，注意最后一个参数GraphicsUnit.Pixel
                graphics.DrawImage(srcImage, new Rectangle(0, 0, destWidth, destHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                //如果是覆盖则先释放源资源
                if (destPath == srcPath)
                {
                    srcImage.Dispose();
                }
                //保存到文件，同时进一步控制质量
                SaveImage2File(destPath, destImage, quality, mimeType);
                retVal = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (srcImage != null)
                    srcImage.Dispose();
                if (destImage != null)
                    destImage.Dispose();
                if (graphics != null)
                    graphics.Dispose();
            }
            return retVal;
        }
        //方法2
        /// <summary>
        /// 将Image实例保存到文件,注意此方法不执行 img.Dispose()
        /// 图片保存时本可以直接使用destImage.Save(path, ImageFormat.Jpeg)，但是这种方法无法进行进一步控制图片质量
        /// </summary>
        /// <param name="path"></param>
        /// <param name="img"></param>
        /// <param name="quality">1~100整数,无效值，则取默认值95</param>
        /// <param name="mimeType"></param>
        public static void SaveImage2File(string path, Image destImage, int quality, string mimeType = "image/jpeg")
        {
            //if (quality <= 0 || quality > 100) quality = 95;
            ////创建保存的文件夹
            //FileInfo fileInfo = new FileInfo(path);
            //if (!Directory.Exists(fileInfo.DirectoryName))
            //{
            //    Directory.CreateDirectory(fileInfo.DirectoryName);
            //}
            ////设置保存参数，保存参数里进一步控制质量
            //EncoderParameters encoderParams = new EncoderParameters();
            //long[] qua = new long[] { quality };
            //EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            //encoderParams.Param[0] = encoderParam;
            ////获取指定mimeType的mimeType的ImageCodecInfo
            //var codecInfo = ImageCodecInfo.GetImageEncoders().FirstOrDefault(ici => ici.MimeType == mimeType);
            //destImage.Save(path, codecInfo, encoderParams);
            destImage.Save(path);
        }
        /// <summary>
        /// 获取高清的Graphics
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Graphics GetGraphics(Image img)
        {
            var g = Graphics.FromImage(img);
            //设置质量
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            //InterpolationMode不能使用High或者HighQualityBicubic,如果是灰色或者部分浅色的图像是会在边缘处出一白色透明的线
            //用HighQualityBilinear却会使图片比其他两种模式模糊（需要肉眼仔细对比才可以看出）
            g.InterpolationMode = InterpolationMode.Default;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            return g;
        }
        public static Image GetImageThumb(Image mg, Size newSize)
        {
            double ratio = 0d;
            double myThumbWidth = 0d;
            double myThumbHeight = 0d;
            int x = 0;
            int y = 0;
            Bitmap bp;

            if ((mg.Width / Convert.ToDouble(newSize.Width)) > (mg.Height /
            Convert.ToDouble(newSize.Height)))
                ratio = Convert.ToDouble(mg.Width) / Convert.ToDouble(newSize.Width);
            else
                ratio = Convert.ToDouble(mg.Height) / Convert.ToDouble(newSize.Height);
            myThumbHeight = Math.Ceiling(mg.Height / ratio);
            myThumbWidth = Math.Ceiling(mg.Width / ratio);

            Size thumbSize = new Size((int)newSize.Width, (int)newSize.Height);
            bp = new Bitmap(newSize.Width, newSize.Height);
            x = (newSize.Width - thumbSize.Width) / 2;
            y = (newSize.Height - thumbSize.Height);
            using (System.Drawing.Graphics g = Graphics.FromImage(bp))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Rectangle rect = new Rectangle(x, y, thumbSize.Width, thumbSize.Height);
                g.DrawImage(mg, rect, 0, 0, mg.Width, mg.Height, GraphicsUnit.Pixel);
            }
            return bp;
        }
    }
}
