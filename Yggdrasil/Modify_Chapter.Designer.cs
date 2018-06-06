namespace Yggdrasil
{
    partial class Modify_Chapter
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
            this.chapterBox = new System.Windows.Forms.ComboBox();
            this.chapterLabel = new System.Windows.Forms.Label();
            this.bookLabel = new System.Windows.Forms.Label();
            this.chapterContent = new System.Windows.Forms.TextBox();
            this.modifyButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.newBookContent = new System.Windows.Forms.TextBox();
            this.newChapterLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.newChapterNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chapterBox
            // 
            this.chapterBox.FormattingEnabled = true;
            this.chapterBox.Location = new System.Drawing.Point(194, 36);
            this.chapterBox.Name = "chapterBox";
            this.chapterBox.Size = new System.Drawing.Size(121, 23);
            this.chapterBox.TabIndex = 0;
            this.chapterBox.SelectedIndexChanged += new System.EventHandler(this.chapterBox_SelectedIndexChanged);
            // 
            // chapterLabel
            // 
            this.chapterLabel.AutoSize = true;
            this.chapterLabel.Location = new System.Drawing.Point(111, 36);
            this.chapterLabel.Name = "chapterLabel";
            this.chapterLabel.Size = new System.Drawing.Size(63, 15);
            this.chapterLabel.TabIndex = 1;
            this.chapterLabel.Text = "Chapter";
            // 
            // bookLabel
            // 
            this.bookLabel.AutoSize = true;
            this.bookLabel.Location = new System.Drawing.Point(111, 9);
            this.bookLabel.Name = "bookLabel";
            this.bookLabel.Size = new System.Drawing.Size(39, 15);
            this.bookLabel.TabIndex = 2;
            this.bookLabel.Text = "Book";
            // 
            // chapterContent
            // 
            this.chapterContent.Location = new System.Drawing.Point(114, 65);
            this.chapterContent.Multiline = true;
            this.chapterContent.Name = "chapterContent";
            this.chapterContent.Size = new System.Drawing.Size(480, 146);
            this.chapterContent.TabIndex = 3;
            this.chapterContent.Text = "Please modify the chapter here!";
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(575, 36);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 4;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(383, 36);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(123, 23);
            this.showButton.TabIndex = 5;
            this.showButton.Text = "Show Content";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // newBookContent
            // 
            this.newBookContent.Location = new System.Drawing.Point(114, 261);
            this.newBookContent.Multiline = true;
            this.newBookContent.Name = "newBookContent";
            this.newBookContent.Size = new System.Drawing.Size(480, 146);
            this.newBookContent.TabIndex = 6;
            this.newBookContent.Text = "Please write the new chapter here!";
            // 
            // newChapterLabel
            // 
            this.newChapterLabel.AutoSize = true;
            this.newChapterLabel.Location = new System.Drawing.Point(111, 230);
            this.newChapterLabel.Name = "newChapterLabel";
            this.newChapterLabel.Size = new System.Drawing.Size(63, 15);
            this.newChapterLabel.TabIndex = 7;
            this.newChapterLabel.Text = "Chapter";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(575, 226);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // newChapterNo
            // 
            this.newChapterNo.Location = new System.Drawing.Point(194, 227);
            this.newChapterNo.Name = "newChapterNo";
            this.newChapterNo.Size = new System.Drawing.Size(100, 25);
            this.newChapterNo.TabIndex = 9;
            this.newChapterNo.Text = "New Chapter";
            this.newChapterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.newChapterNo_KeyPress);
            // 
            // Modify_Chapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.newChapterNo);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.newChapterLabel);
            this.Controls.Add(this.newBookContent);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.chapterContent);
            this.Controls.Add(this.bookLabel);
            this.Controls.Add(this.chapterLabel);
            this.Controls.Add(this.chapterBox);
            this.Name = "Modify_Chapter";
            this.Text = "修改章节";
            this.Load += new System.EventHandler(this.Chapter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chapterBox;
        private System.Windows.Forms.Label chapterLabel;
        private System.Windows.Forms.Label bookLabel;
        private System.Windows.Forms.TextBox chapterContent;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.TextBox newBookContent;
        private System.Windows.Forms.Label newChapterLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox newChapterNo;
    }
}