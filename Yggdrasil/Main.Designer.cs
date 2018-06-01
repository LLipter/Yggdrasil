namespace Yggdrasil
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblDividingline = new System.Windows.Forms.Label();
            this.btnBook1 = new System.Windows.Forms.Button();
            this.btnBook2 = new System.Windows.Forms.Button();
            this.btnBook3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblBook3 = new System.Windows.Forms.Label();
            this.lblBook2 = new System.Windows.Forms.Label();
            this.lblBook1 = new System.Windows.Forms.Label();
            this.btnBookManagement = new System.Windows.Forms.Button();
            this.imlRecommend = new System.Windows.Forms.ImageList(this.components);
            this.btnShow1 = new System.Windows.Forms.Button();
            this.btnShow2 = new System.Windows.Forms.Button();
            this.btnShow3 = new System.Windows.Forms.Button();
            this.btnShow4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timShow = new System.Windows.Forms.Timer(this.components);
            this.piBShow = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piBShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSearch.Location = new System.Drawing.Point(225, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(125, 29);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(365, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblDividingline
            // 
            this.lblDividingline.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lblDividingline.Location = new System.Drawing.Point(12, 65);
            this.lblDividingline.Name = "lblDividingline";
            this.lblDividingline.Size = new System.Drawing.Size(644, 5);
            this.lblDividingline.TabIndex = 3;
            // 
            // btnBook1
            // 
            this.btnBook1.FlatAppearance.BorderSize = 0;
            this.btnBook1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook1.Image = ((System.Drawing.Image)(resources.GetObject("btnBook1.Image")));
            this.btnBook1.Location = new System.Drawing.Point(30, 42);
            this.btnBook1.Name = "btnBook1";
            this.btnBook1.Size = new System.Drawing.Size(150, 150);
            this.btnBook1.TabIndex = 6;
            this.btnBook1.UseVisualStyleBackColor = true;
            // 
            // btnBook2
            // 
            this.btnBook2.FlatAppearance.BorderSize = 0;
            this.btnBook2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook2.Image = ((System.Drawing.Image)(resources.GetObject("btnBook2.Image")));
            this.btnBook2.Location = new System.Drawing.Point(205, 42);
            this.btnBook2.Name = "btnBook2";
            this.btnBook2.Size = new System.Drawing.Size(150, 150);
            this.btnBook2.TabIndex = 7;
            this.btnBook2.UseVisualStyleBackColor = true;
            this.btnBook2.Click += new System.EventHandler(this.btnBook1_Click);
            // 
            // btnBook3
            // 
            this.btnBook3.FlatAppearance.BorderSize = 0;
            this.btnBook3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook3.Image = ((System.Drawing.Image)(resources.GetObject("btnBook3.Image")));
            this.btnBook3.Location = new System.Drawing.Point(372, 42);
            this.btnBook3.Name = "btnBook3";
            this.btnBook3.Size = new System.Drawing.Size(150, 150);
            this.btnBook3.TabIndex = 8;
            this.btnBook3.UseVisualStyleBackColor = true;
            this.btnBook3.Click += new System.EventHandler(this.btnBook1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.lblBook3);
            this.groupBox1.Controls.Add(this.lblBook2);
            this.groupBox1.Controls.Add(this.lblBook1);
            this.groupBox1.Controls.Add(this.btnBook1);
            this.groupBox1.Controls.Add(this.btnBook3);
            this.groupBox1.Controls.Add(this.btnBook2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(66, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 241);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(30, -7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(163, 36);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // lblBook3
            // 
            this.lblBook3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBook3.AutoSize = true;
            this.lblBook3.Location = new System.Drawing.Point(417, 195);
            this.lblBook3.Name = "lblBook3";
            this.lblBook3.Size = new System.Drawing.Size(69, 25);
            this.lblBook3.TabIndex = 11;
            this.lblBook3.Text = "Book3";
            this.lblBook3.Click += new System.EventHandler(this.btnBook1_Click);
            // 
            // lblBook2
            // 
            this.lblBook2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBook2.AutoSize = true;
            this.lblBook2.Location = new System.Drawing.Point(250, 195);
            this.lblBook2.Name = "lblBook2";
            this.lblBook2.Size = new System.Drawing.Size(69, 25);
            this.lblBook2.TabIndex = 10;
            this.lblBook2.Text = "Book2";
            this.lblBook2.Click += new System.EventHandler(this.btnBook1_Click);
            // 
            // lblBook1
            // 
            this.lblBook1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBook1.AutoSize = true;
            this.lblBook1.Location = new System.Drawing.Point(58, 195);
            this.lblBook1.Name = "lblBook1";
            this.lblBook1.Size = new System.Drawing.Size(69, 25);
            this.lblBook1.TabIndex = 9;
            this.lblBook1.Text = "Book1";
            this.lblBook1.Click += new System.EventHandler(this.btnBook1_Click);
            // 
            // btnBookManagement
            // 
            this.btnBookManagement.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBookManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnBookManagement.Image")));
            this.btnBookManagement.Location = new System.Drawing.Point(477, 12);
            this.btnBookManagement.Name = "btnBookManagement";
            this.btnBookManagement.Size = new System.Drawing.Size(188, 36);
            this.btnBookManagement.TabIndex = 10;
            this.btnBookManagement.UseVisualStyleBackColor = true;
            this.btnBookManagement.Click += new System.EventHandler(this.btnBookManagement_Click);
            // 
            // imlRecommend
            // 
            this.imlRecommend.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlRecommend.ImageSize = new System.Drawing.Size(256, 256);
            this.imlRecommend.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnShow1
            // 
            this.btnShow1.BackColor = System.Drawing.Color.Transparent;
            this.btnShow1.FlatAppearance.BorderSize = 0;
            this.btnShow1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShow1.Location = new System.Drawing.Point(96, 280);
            this.btnShow1.Name = "btnShow1";
            this.btnShow1.Size = new System.Drawing.Size(130, 30);
            this.btnShow1.TabIndex = 11;
            this.btnShow1.Text = "example1";
            this.btnShow1.UseVisualStyleBackColor = false;
            this.btnShow1.Click += new System.EventHandler(this.btnShow1_Click);
            // 
            // btnShow2
            // 
            this.btnShow2.BackColor = System.Drawing.Color.Transparent;
            this.btnShow2.FlatAppearance.BorderSize = 0;
            this.btnShow2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShow2.Location = new System.Drawing.Point(225, 280);
            this.btnShow2.Name = "btnShow2";
            this.btnShow2.Size = new System.Drawing.Size(130, 30);
            this.btnShow2.TabIndex = 12;
            this.btnShow2.Text = "example2";
            this.btnShow2.UseVisualStyleBackColor = false;
            this.btnShow2.Click += new System.EventHandler(this.btnShow2_Click);
            // 
            // btnShow3
            // 
            this.btnShow3.BackColor = System.Drawing.Color.Transparent;
            this.btnShow3.FlatAppearance.BorderSize = 0;
            this.btnShow3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShow3.Location = new System.Drawing.Point(356, 280);
            this.btnShow3.Name = "btnShow3";
            this.btnShow3.Size = new System.Drawing.Size(130, 30);
            this.btnShow3.TabIndex = 13;
            this.btnShow3.Text = "example3";
            this.btnShow3.UseVisualStyleBackColor = false;
            this.btnShow3.Click += new System.EventHandler(this.btnShow3_Click);
            // 
            // btnShow4
            // 
            this.btnShow4.BackColor = System.Drawing.Color.Transparent;
            this.btnShow4.FlatAppearance.BorderSize = 0;
            this.btnShow4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShow4.Location = new System.Drawing.Point(486, 280);
            this.btnShow4.Name = "btnShow4";
            this.btnShow4.Size = new System.Drawing.Size(130, 30);
            this.btnShow4.TabIndex = 14;
            this.btnShow4.Text = "example4";
            this.btnShow4.UseVisualStyleBackColor = false;
            this.btnShow4.Click += new System.EventHandler(this.btnShow4_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.label2.Location = new System.Drawing.Point(223, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 26);
            this.label2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.label4.Location = new System.Drawing.Point(354, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(3, 26);
            this.label4.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.label5.Location = new System.Drawing.Point(486, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(3, 26);
            this.label5.TabIndex = 18;
            // 
            // timShow
            // 
            this.timShow.Enabled = true;
            this.timShow.Interval = 2500;
            this.timShow.Tick += new System.EventHandler(this.timShow_Tick);
            // 
            // piBShow
            // 
            this.piBShow.ImageLocation = "";
            this.piBShow.InitialImage = ((System.Drawing.Image)(resources.GetObject("piBShow.InitialImage")));
            this.piBShow.Location = new System.Drawing.Point(225, 77);
            this.piBShow.Name = "piBShow";
            this.piBShow.Size = new System.Drawing.Size(256, 200);
            this.piBShow.TabIndex = 19;
            this.piBShow.TabStop = false;
            this.piBShow.Click += new System.EventHandler(this.btnBook1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 50);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(668, 580);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShow4);
            this.Controls.Add(this.btnShow3);
            this.Controls.Add(this.btnShow2);
            this.Controls.Add(this.btnShow1);
            this.Controls.Add(this.btnBookManagement);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDividingline);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.piBShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piBShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblDividingline;
        private System.Windows.Forms.Button btnBook1;
        private System.Windows.Forms.Button btnBook2;
        private System.Windows.Forms.Button btnBook3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBookManagement;
        private System.Windows.Forms.ImageList imlRecommend;
        private System.Windows.Forms.Button btnShow1;
        private System.Windows.Forms.Button btnShow2;
        private System.Windows.Forms.Button btnShow3;
        private System.Windows.Forms.Button btnShow4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timShow;
        private System.Windows.Forms.PictureBox piBShow;
        private System.Windows.Forms.Label lblBook3;
        private System.Windows.Forms.Label lblBook2;
        private System.Windows.Forms.Label lblBook1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}