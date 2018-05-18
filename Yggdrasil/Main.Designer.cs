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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblDividingline = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is the logo";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(311, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(82, 21);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(399, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(51, 21);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblDividingline
            // 
            this.lblDividingline.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lblDividingline.Location = new System.Drawing.Point(12, 61);
            this.lblDividingline.Name = "lblDividingline";
            this.lblDividingline.Size = new System.Drawing.Size(644, 5);
            this.lblDividingline.TabIndex = 3;
            // 
            // btnShow
            // 
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.Location = new System.Drawing.Point(96, 69);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(520, 240);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "button1";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(30, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 150);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(205, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 150);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(372, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 150);
            this.button5.TabIndex = 8;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(66, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 213);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recommend";
            // 
            // btnBookManagement
            // 
            this.btnBookManagement.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBookManagement.Location = new System.Drawing.Point(488, 13);
            this.btnBookManagement.Name = "btnBookManagement";
            this.btnBookManagement.Size = new System.Drawing.Size(168, 36);
            this.btnBookManagement.TabIndex = 10;
            this.btnBookManagement.Text = "Book Management";
            this.btnBookManagement.UseVisualStyleBackColor = true;
            // 
            // imlRecommend
            // 
            this.imlRecommend.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlRecommend.ImageStream")));
            this.imlRecommend.TransparentColor = System.Drawing.Color.Transparent;
            this.imlRecommend.Images.SetKeyName(0, "TIM图片20180510014734.jpg");
            this.imlRecommend.Images.SetKeyName(1, "TIM图片20180510014743.jpg");
            this.imlRecommend.Images.SetKeyName(2, "TIM图片20180510014748.jpg");
            this.imlRecommend.Images.SetKeyName(3, "TIM图片20180510014751.jpg");
            // 
            // btnShow1
            // 
            this.btnShow1.BackColor = System.Drawing.Color.Transparent;
            this.btnShow1.FlatAppearance.BorderSize = 0;
            this.btnShow1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShow1.Location = new System.Drawing.Point(96, 283);
            this.btnShow1.Name = "btnShow1";
            this.btnShow1.Size = new System.Drawing.Size(130, 26);
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
            this.btnShow2.Location = new System.Drawing.Point(226, 283);
            this.btnShow2.Name = "btnShow2";
            this.btnShow2.Size = new System.Drawing.Size(130, 26);
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
            this.btnShow3.Location = new System.Drawing.Point(356, 283);
            this.btnShow3.Name = "btnShow3";
            this.btnShow3.Size = new System.Drawing.Size(130, 26);
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
            this.btnShow4.Location = new System.Drawing.Point(486, 283);
            this.btnShow4.Name = "btnShow4";
            this.btnShow4.Size = new System.Drawing.Size(130, 26);
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
            this.timShow.Interval = 200;
            this.timShow.Tick += new System.EventHandler(this.timShow_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(668, 580);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShow4);
            this.Controls.Add(this.btnShow3);
            this.Controls.Add(this.btnShow2);
            this.Controls.Add(this.btnShow1);
            this.Controls.Add(this.btnBookManagement);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lblDividingline);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "主界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblDividingline;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
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
    }
}