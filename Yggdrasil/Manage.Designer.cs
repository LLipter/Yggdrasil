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
            this.addBookButton = new System.Windows.Forms.Button();
            this.addChapterButton = new System.Windows.Forms.Button();
            this.modifyChapterButton = new System.Windows.Forms.Button();
            this.booksView = new System.Windows.Forms.DataGridView();
            this.bookListLabel = new System.Windows.Forms.Label();
            this.commitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.booksView)).BeginInit();
            this.SuspendLayout();
            // 
            // addBookButton
            // 
            this.addBookButton.Location = new System.Drawing.Point(633, 311);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(171, 23);
            this.addBookButton.TabIndex = 1;
            this.addBookButton.Text = "Add Book To Stock";
            this.addBookButton.UseVisualStyleBackColor = true;
            // 
            // addChapterButton
            // 
            this.addChapterButton.Location = new System.Drawing.Point(413, 243);
            this.addChapterButton.Name = "addChapterButton";
            this.addChapterButton.Size = new System.Drawing.Size(128, 23);
            this.addChapterButton.TabIndex = 4;
            this.addChapterButton.Text = "Add Chapter";
            this.addChapterButton.UseVisualStyleBackColor = true;
            this.addChapterButton.Click += new System.EventHandler(this.addChapterButton_Click);
            // 
            // modifyChapterButton
            // 
            this.modifyChapterButton.Location = new System.Drawing.Point(572, 243);
            this.modifyChapterButton.Name = "modifyChapterButton";
            this.modifyChapterButton.Size = new System.Drawing.Size(128, 23);
            this.modifyChapterButton.TabIndex = 6;
            this.modifyChapterButton.Text = "Modify Chapter";
            this.modifyChapterButton.UseVisualStyleBackColor = true;
            this.modifyChapterButton.Click += new System.EventHandler(this.modifyChapterButton_Click);
            // 
            // booksView
            // 
            this.booksView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksView.Location = new System.Drawing.Point(88, 40);
            this.booksView.Name = "booksView";
            this.booksView.RowTemplate.Height = 27;
            this.booksView.Size = new System.Drawing.Size(636, 181);
            this.booksView.TabIndex = 7;
            this.booksView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // bookListLabel
            // 
            this.bookListLabel.AutoSize = true;
            this.bookListLabel.Location = new System.Drawing.Point(115, 22);
            this.bookListLabel.Name = "bookListLabel";
            this.bookListLabel.Size = new System.Drawing.Size(215, 15);
            this.bookListLabel.TabIndex = 10;
            this.bookListLabel.Text = "The books in the inventory";
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(152, 243);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(178, 23);
            this.commitButton.TabIndex = 11;
            this.commitButton.Text = "Commit Modification";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 399);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.bookListLabel);
            this.Controls.Add(this.booksView);
            this.Controls.Add(this.modifyChapterButton);
            this.Controls.Add(this.addChapterButton);
            this.Controls.Add(this.addBookButton);
            this.Name = "Manage";
            this.Text = "管理界面";
            this.Load += new System.EventHandler(this.Manage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.booksView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Button addChapterButton;
        private System.Windows.Forms.Button modifyChapterButton;
        private System.Windows.Forms.DataGridView booksView;
        private System.Windows.Forms.Label bookListLabel;
        private System.Windows.Forms.Button commitButton;
    }
}