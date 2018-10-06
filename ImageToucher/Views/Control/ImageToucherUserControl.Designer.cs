namespace ImageToucher.Views.Control
{
    partial class ImageToucherUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPicPnlContainer = new System.Windows.Forms.Panel();
            this.panelBtnPnl = new System.Windows.Forms.Panel();
            this.panelPicPnl = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panelPicPnlContainer.SuspendLayout();
            this.panelBtnPnl.SuspendLayout();
            this.panelPicPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPicPnlContainer
            // 
            this.panelPicPnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPicPnlContainer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelPicPnlContainer.Controls.Add(this.panelPicPnl);
            this.panelPicPnlContainer.Location = new System.Drawing.Point(0, 40);
            this.panelPicPnlContainer.Name = "panelPicPnlContainer";
            this.panelPicPnlContainer.Size = new System.Drawing.Size(520, 520);
            this.panelPicPnlContainer.TabIndex = 0;
            // 
            // panelBtnPnl
            // 
            this.panelBtnPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBtnPnl.BackColor = System.Drawing.Color.SteelBlue;
            this.panelBtnPnl.Controls.Add(this.button5);
            this.panelBtnPnl.Controls.Add(this.button4);
            this.panelBtnPnl.Controls.Add(this.button3);
            this.panelBtnPnl.Controls.Add(this.button2);
            this.panelBtnPnl.Controls.Add(this.button1);
            this.panelBtnPnl.Location = new System.Drawing.Point(0, 0);
            this.panelBtnPnl.Name = "panelBtnPnl";
            this.panelBtnPnl.Size = new System.Drawing.Size(520, 40);
            this.panelBtnPnl.TabIndex = 1;
            // 
            // panelPicPnl
            // 
            this.panelPicPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPicPnl.AutoScroll = true;
            this.panelPicPnl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelPicPnl.Controls.Add(this.pictureBox1);
            this.panelPicPnl.Location = new System.Drawing.Point(3, 3);
            this.panelPicPnl.Name = "panelPicPnl";
            this.panelPicPnl.Size = new System.Drawing.Size(514, 514);
            this.panelPicPnl.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(510, 510);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "自适应";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(293, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "放大";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(350, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "缩小";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(407, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "右旋转";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(464, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(51, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "原图";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ImageToucherUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBtnPnl);
            this.Controls.Add(this.panelPicPnlContainer);
            this.MinimumSize = new System.Drawing.Size(520, 560);
            this.Name = "ImageToucherUserControl";
            this.Size = new System.Drawing.Size(520, 560);
            this.panelPicPnlContainer.ResumeLayout(false);
            this.panelBtnPnl.ResumeLayout(false);
            this.panelPicPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPicPnlContainer;
        private System.Windows.Forms.Panel panelBtnPnl;
        private System.Windows.Forms.Panel panelPicPnl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}
