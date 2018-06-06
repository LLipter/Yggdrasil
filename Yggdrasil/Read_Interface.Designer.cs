namespace Yggdrasil
{
    partial class Read_Interface
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
            this.BookContents = new System.Windows.Forms.TextBox();
            this.LastPage = new System.Windows.Forms.Button();
            this.NextPage = new System.Windows.Forms.Button();
            this.ChapterName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BookContents
            // 
            this.BookContents.BackColor = System.Drawing.SystemColors.Info;
            this.BookContents.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BookContents.Location = new System.Drawing.Point(-2, 75);
            this.BookContents.Multiline = true;
            this.BookContents.Name = "BookContents";
            this.BookContents.ReadOnly = true;
            this.BookContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BookContents.Size = new System.Drawing.Size(688, 458);
            this.BookContents.TabIndex = 1;
            this.BookContents.TabStop = false;
            this.BookContents.TextChanged += new System.EventHandler(this.Contents_TextChanged);
            // 
            // LastPage
            // 
            this.LastPage.Location = new System.Drawing.Point(27, 559);
            this.LastPage.Name = "LastPage";
            this.LastPage.Size = new System.Drawing.Size(145, 45);
            this.LastPage.TabIndex = 2;
            this.LastPage.Text = "Last page";
            this.LastPage.UseVisualStyleBackColor = true;
            this.LastPage.Click += new System.EventHandler(this.LastButton_Click);
            // 
            // NextPage
            // 
            this.NextPage.Location = new System.Drawing.Point(488, 559);
            this.NextPage.Name = "NextPage";
            this.NextPage.Size = new System.Drawing.Size(153, 45);
            this.NextPage.TabIndex = 3;
            this.NextPage.Text = "Next page";
            this.NextPage.UseVisualStyleBackColor = true;
            this.NextPage.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // ChapterName
            // 
            this.ChapterName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChapterName.Font = new System.Drawing.Font("微软雅黑", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChapterName.Location = new System.Drawing.Point(-7, -4);
            this.ChapterName.Name = "ChapterName";
            this.ChapterName.ReadOnly = true;
            this.ChapterName.Size = new System.Drawing.Size(685, 80);
            this.ChapterName.TabIndex = 4;
            // 
            // Read_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yggdrasil.Properties.Resources._37698293_p0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(680, 605);
            this.Controls.Add(this.ChapterName);
            this.Controls.Add(this.NextPage);
            this.Controls.Add(this.LastPage);
            this.Controls.Add(this.BookContents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Read_Interface";
            this.Text = "阅读界面";
            this.Load += new System.EventHandler(this.Read_Interface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox BookContents;
        private System.Windows.Forms.Button LastPage;
        private System.Windows.Forms.Button NextPage;
        private System.Windows.Forms.TextBox ChapterName;
    }
}