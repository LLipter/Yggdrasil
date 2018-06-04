namespace Yggdrasil
{
    partial class Book_Interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Book_Interface));
            this.BookNameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChapterBox = new System.Windows.Forms.ComboBox();
            this.ChapterLabel = new System.Windows.Forms.Label();
            this.Summary = new System.Windows.Forms.TextBox();
            this.BeginReadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BookNameLabel
            // 
            this.BookNameLabel.AutoSize = true;
            this.BookNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.BookNameLabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BookNameLabel.Location = new System.Drawing.Point(42, 20);
            this.BookNameLabel.Name = "BookNameLabel";
            this.BookNameLabel.Size = new System.Drawing.Size(114, 24);
            this.BookNameLabel.TabIndex = 0;
            this.BookNameLabel.Text = "BookName";
            this.BookNameLabel.Click += new System.EventHandler(this.BookNameLabel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(46, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ChapterBox
            // 
            this.ChapterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChapterBox.FormattingEnabled = true;
            this.ChapterBox.Location = new System.Drawing.Point(46, 332);
            this.ChapterBox.Name = "ChapterBox";
            this.ChapterBox.Size = new System.Drawing.Size(121, 23);
            this.ChapterBox.TabIndex = 2;
            this.ChapterBox.SelectedIndexChanged += new System.EventHandler(this.ChapterBox_SelectedIndexChanged);
            // 
            // ChapterLabel
            // 
            this.ChapterLabel.AutoSize = true;
            this.ChapterLabel.BackColor = System.Drawing.Color.Transparent;
            this.ChapterLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChapterLabel.Location = new System.Drawing.Point(43, 303);
            this.ChapterLabel.Name = "ChapterLabel";
            this.ChapterLabel.Size = new System.Drawing.Size(70, 15);
            this.ChapterLabel.TabIndex = 3;
            this.ChapterLabel.Text = "Chapter";
            // 
            // Summary
            // 
            this.Summary.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Summary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Summary.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Summary.Location = new System.Drawing.Point(347, 47);
            this.Summary.Multiline = true;
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            this.Summary.Size = new System.Drawing.Size(425, 227);
            this.Summary.TabIndex = 4;
            this.Summary.Text = "This is the sample！This is the sample！This is the sample！This is the sample！This " +
    "is the sample！This is the sample！This is the sample！";
            this.Summary.TextChanged += new System.EventHandler(this.SummaryBox_TextChanged);
            // 
            // BeginReadButton
            // 
            this.BeginReadButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BeginReadButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BeginReadButton.Location = new System.Drawing.Point(414, 350);
            this.BeginReadButton.Name = "BeginReadButton";
            this.BeginReadButton.Size = new System.Drawing.Size(160, 63);
            this.BeginReadButton.TabIndex = 5;
            this.BeginReadButton.Text = "Begin to Read";
            this.BeginReadButton.UseVisualStyleBackColor = false;
            this.BeginReadButton.Click += new System.EventHandler(this.BeginReadButton_Click);
            this.BeginReadButton.MouseEnter += new System.EventHandler(this.BeginReadButton_OnMouseEnter);
            this.BeginReadButton.MouseLeave += new System.EventHandler(this.BeginReadButton_OnMouseLeave);
            // 
            // Book_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yggdrasil.Properties.Resources._5_120601095934;
            this.ClientSize = new System.Drawing.Size(784, 465);
            this.Controls.Add(this.BeginReadButton);
            this.Controls.Add(this.Summary);
            this.Controls.Add(this.ChapterLabel);
            this.Controls.Add(this.ChapterBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BookNameLabel);
            this.Name = "Book_Interface";
            this.Text = "书籍界面";
            this.Load += new System.EventHandler(this.Book_Interface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BookNameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox ChapterBox;
        private System.Windows.Forms.Label ChapterLabel;
        private System.Windows.Forms.TextBox Summary;
        private System.Windows.Forms.Button BeginReadButton;
    }
}