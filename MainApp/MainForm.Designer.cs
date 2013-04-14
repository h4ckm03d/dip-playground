namespace MainApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnToGrayScale = new System.Windows.Forms.Button();
            this.btnBW = new System.Windows.Forms.Button();
            this.btnResetImage = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.groupBoxImageLoad = new System.Windows.Forms.GroupBox();
            this.lblHeightDiameter = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWidthDiameter = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.groupBoxImageLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.pbImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 244);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLoadImage);
            this.flowLayoutPanel1.Controls.Add(this.btnToGrayScale);
            this.flowLayoutPanel1.Controls.Add(this.btnBW);
            this.flowLayoutPanel1.Controls.Add(this.btnResetImage);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(275, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(94, 244);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(3, 3);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(88, 23);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnToGrayScale
            // 
            this.btnToGrayScale.Location = new System.Drawing.Point(3, 32);
            this.btnToGrayScale.Name = "btnToGrayScale";
            this.btnToGrayScale.Size = new System.Drawing.Size(88, 23);
            this.btnToGrayScale.TabIndex = 2;
            this.btnToGrayScale.Text = "Gray Scale";
            this.btnToGrayScale.UseVisualStyleBackColor = true;
            this.btnToGrayScale.Click += new System.EventHandler(this.btnToGrayScale_Click);
            // 
            // btnBW
            // 
            this.btnBW.Location = new System.Drawing.Point(3, 61);
            this.btnBW.Name = "btnBW";
            this.btnBW.Size = new System.Drawing.Size(88, 23);
            this.btnBW.TabIndex = 4;
            this.btnBW.Text = "BW";
            this.btnBW.UseVisualStyleBackColor = true;
            this.btnBW.Click += new System.EventHandler(this.btnBW_Click);
            // 
            // btnResetImage
            // 
            this.btnResetImage.Location = new System.Drawing.Point(3, 90);
            this.btnResetImage.Name = "btnResetImage";
            this.btnResetImage.Size = new System.Drawing.Size(88, 23);
            this.btnResetImage.TabIndex = 3;
            this.btnResetImage.Text = "Reset";
            this.btnResetImage.UseVisualStyleBackColor = true;
            this.btnResetImage.Click += new System.EventHandler(this.btnResetImage_Click);
            // 
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(275, 244);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // groupBoxImageLoad
            // 
            this.groupBoxImageLoad.Controls.Add(this.panel1);
            this.groupBoxImageLoad.Location = new System.Drawing.Point(12, 12);
            this.groupBoxImageLoad.Name = "groupBoxImageLoad";
            this.groupBoxImageLoad.Size = new System.Drawing.Size(375, 263);
            this.groupBoxImageLoad.TabIndex = 1;
            this.groupBoxImageLoad.TabStop = false;
            // 
            // lblHeightDiameter
            // 
            this.lblHeightDiameter.AutoSize = true;
            this.lblHeightDiameter.Location = new System.Drawing.Point(12, 278);
            this.lblHeightDiameter.Name = "lblHeightDiameter";
            this.lblHeightDiameter.Size = new System.Drawing.Size(38, 13);
            this.lblHeightDiameter.TabIndex = 5;
            this.lblHeightDiameter.Text = "Height";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 391);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(393, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 391);
            this.panel2.TabIndex = 7;
            // 
            // lblWidthDiameter
            // 
            this.lblWidthDiameter.AutoSize = true;
            this.lblWidthDiameter.Location = new System.Drawing.Point(13, 295);
            this.lblWidthDiameter.Name = "lblWidthDiameter";
            this.lblWidthDiameter.Size = new System.Drawing.Size(35, 13);
            this.lblWidthDiameter.TabIndex = 8;
            this.lblWidthDiameter.Text = "Width";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 477);
            this.Controls.Add(this.lblWidthDiameter);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBoxImageLoad);
            this.Controls.Add(this.lblHeightDiameter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Digital Image Processing";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.groupBoxImageLoad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.GroupBox groupBoxImageLoad;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnToGrayScale;
        private System.Windows.Forms.Button btnResetImage;
        private System.Windows.Forms.Button btnBW;
        private System.Windows.Forms.Label lblHeightDiameter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWidthDiameter;
    }
}

