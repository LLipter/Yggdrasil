namespace Yggdrasil
{
    partial class Manage
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
            this.upBooks = new System.Windows.Forms.Label();
            this.addBookButton = new System.Windows.Forms.Button();
            this.upBookButton = new System.Windows.Forms.Button();
            this.downBookButton = new System.Windows.Forms.Button();
            this.addChapterButton = new System.Windows.Forms.Button();
            this.downBooks = new System.Windows.Forms.Label();
            this.modifyChapterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // upBooks
            // 
            this.upBooks.AutoSize = true;
            this.upBooks.Location = new System.Drawing.Point(143, 136);
            this.upBooks.Name = "upBooks";
            this.upBooks.Size = new System.Drawing.Size(135, 15);
            this.upBooks.TabIndex = 0;
            this.upBooks.Text = "the Books Are Up";
            // 
            // addBookButton
            // 
            this.addBookButton.Location = new System.Drawing.Point(594, 302);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(81, 23);
            this.addBookButton.TabIndex = 1;
            this.addBookButton.Text = "Add Book";
            this.addBookButton.UseVisualStyleBackColor = true;
            // 
            // upBookButton
            // 
            this.upBookButton.Location = new System.Drawing.Point(227, 173);
            this.upBookButton.Name = "upBookButton";
            this.upBookButton.Size = new System.Drawing.Size(36, 23);
            this.upBookButton.TabIndex = 2;
            this.upBookButton.Text = "Up";
            this.upBookButton.UseVisualStyleBackColor = true;
            // 
            // downBookButton
            // 
            this.downBookButton.Location = new System.Drawing.Point(365, 173);
            this.downBookButton.Name = "downBookButton";
            this.downBookButton.Size = new System.Drawing.Size(56, 23);
            this.downBookButton.TabIndex = 3;
            this.downBookButton.Text = "Down";
            this.downBookButton.UseVisualStyleBackColor = true;
            // 
            // addChapterButton
            // 
            this.addChapterButton.Location = new System.Drawing.Point(594, 149);
            this.addChapterButton.Name = "addChapterButton";
            this.addChapterButton.Size = new System.Drawing.Size(128, 23);
            this.addChapterButton.TabIndex = 4;
            this.addChapterButton.Text = "Add Chapter";
            this.addChapterButton.UseVisualStyleBackColor = true;
            // 
            // downBooks
            // 
            this.downBooks.AutoSize = true;
            this.downBooks.Location = new System.Drawing.Point(328, 136);
            this.downBooks.Name = "downBooks";
            this.downBooks.Size = new System.Drawing.Size(151, 15);
            this.downBooks.TabIndex = 5;
            this.downBooks.Text = "the Books Are Down";
            // 
            // modifyChapterButton
            // 
            this.modifyChapterButton.Location = new System.Drawing.Point(594, 219);
            this.modifyChapterButton.Name = "modifyChapterButton";
            this.modifyChapterButton.Size = new System.Drawing.Size(128, 23);
            this.modifyChapterButton.TabIndex = 6;
            this.modifyChapterButton.Text = "Modify Chapter";
            this.modifyChapterButton.UseVisualStyleBackColor = true;
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 399);
            this.Controls.Add(this.modifyChapterButton);
            this.Controls.Add(this.downBooks);
            this.Controls.Add(this.addChapterButton);
            this.Controls.Add(this.downBookButton);
            this.Controls.Add(this.upBookButton);
            this.Controls.Add(this.addBookButton);
            this.Controls.Add(this.upBooks);
            this.Name = "Manage";
            this.Text = "管理界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label upBooks;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Button upBookButton;
        private System.Windows.Forms.Button downBookButton;
        private System.Windows.Forms.Button addChapterButton;
        private System.Windows.Forms.Label downBooks;
        private System.Windows.Forms.Button modifyChapterButton;
    }
}