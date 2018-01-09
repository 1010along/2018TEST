namespace zxingTest
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.pictureBoxQr = new System.Windows.Forms.PictureBox();
            this.buttonQr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQr)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(81, 14);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(183, 21);
            this.textBoxText.TabIndex = 0;
            // 
            // pictureBoxQr
            // 
            this.pictureBoxQr.Location = new System.Drawing.Point(14, 41);
            this.pictureBoxQr.Name = "pictureBoxQr";
            this.pictureBoxQr.Size = new System.Drawing.Size(331, 257);
            this.pictureBoxQr.TabIndex = 1;
            this.pictureBoxQr.TabStop = false;
            // 
            // buttonQr
            // 
            this.buttonQr.Location = new System.Drawing.Point(270, 12);
            this.buttonQr.Name = "buttonQr";
            this.buttonQr.Size = new System.Drawing.Size(75, 23);
            this.buttonQr.TabIndex = 2;
            this.buttonQr.Text = "生成二维码";
            this.buttonQr.UseVisualStyleBackColor = true;
            this.buttonQr.Click += new System.EventHandler(this.buttonQr_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "请输入内容：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 309);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonQr);
            this.Controls.Add(this.pictureBoxQr);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成二维码";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.PictureBox pictureBoxQr;
        private System.Windows.Forms.Button buttonQr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

