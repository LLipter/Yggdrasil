namespace Yggdrasil
{
    partial class Add_Book
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
            this.SelectCoverButton = new System.Windows.Forms.Button();
            this.BookNameBox = new System.Windows.Forms.TextBox();
            this.InfoBox = new System.Windows.Forms.RichTextBox();
            this.NewBookNameLabel = new System.Windows.Forms.Label();
            this.BookInfoLabel = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.openImgDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // SelectCoverButton
            // 
            this.SelectCoverButton.BackColor = System.Drawing.Color.DarkOrange;
            this.SelectCoverButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectCoverButton.Location = new System.Drawing.Point(466, 48);
            this.SelectCoverButton.Name = "SelectCoverButton";
            this.SelectCoverButton.Size = new System.Drawing.Size(153, 34);
            this.SelectCoverButton.TabIndex = 0;
            this.SelectCoverButton.Text = "Select CoverImg";
            this.SelectCoverButton.UseVisualStyleBackColor = false;
            this.SelectCoverButton.Click += new System.EventHandler(this.SelectCoverButton_Click);
            // 
            // BookNameBox
            // 
            this.BookNameBox.Location = new System.Drawing.Point(158, 55);
            this.BookNameBox.Name = "BookNameBox";
            this.BookNameBox.Size = new System.Drawing.Size(283, 25);
            this.BookNameBox.TabIndex = 1;
            // 
            // InfoBox
            // 
            this.InfoBox.BackColor = System.Drawing.SystemColors.Info;
            this.InfoBox.Location = new System.Drawing.Point(158, 116);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(283, 161);
            this.InfoBox.TabIndex = 2;
            this.InfoBox.Text = "";
            // 
            // NewBookNameLabel
            // 
            this.NewBookNameLabel.AutoSize = true;
            this.NewBookNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NewBookNameLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewBookNameLabel.Location = new System.Drawing.Point(156, 26);
            this.NewBookNameLabel.Name = "NewBookNameLabel";
            this.NewBookNameLabel.Size = new System.Drawing.Size(123, 26);
            this.NewBookNameLabel.TabIndex = 3;
            this.NewBookNameLabel.Text = "Book Name";
            this.NewBookNameLabel.Click += new System.EventHandler(this.NewBookNameLabel_Click);
            // 
            // BookInfoLabel
            // 
            this.BookInfoLabel.AutoSize = true;
            this.BookInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.BookInfoLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BookInfoLabel.Location = new System.Drawing.Point(158, 87);
            this.BookInfoLabel.Name = "BookInfoLabel";
            this.BookInfoLabel.Size = new System.Drawing.Size(104, 26);
            this.BookInfoLabel.TabIndex = 4;
            this.BookInfoLabel.Text = "Book Info";
            // 
            // CommitButton
            // 
            this.CommitButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.CommitButton.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CommitButton.Location = new System.Drawing.Point(212, 303);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(184, 49);
            this.CommitButton.TabIndex = 5;
            this.CommitButton.Text = "Commit";
            this.CommitButton.UseVisualStyleBackColor = false;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // openImgDialog
            // 
            this.openImgDialog.FileName = "openFileDialog";
            // 
            // Add_Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Yggdrasil.Properties.Resources._5_120601095934;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(648, 432);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.BookInfoLabel);
            this.Controls.Add(this.NewBookNameLabel);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.BookNameBox);
            this.Controls.Add(this.SelectCoverButton);
            this.MaximizeBox = false;
            this.Name = "Add_Book";
            this.Text = "Add_Book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectCoverButton;
        private System.Windows.Forms.TextBox BookNameBox;
        private System.Windows.Forms.RichTextBox InfoBox;
        private System.Windows.Forms.Label NewBookNameLabel;
        private System.Windows.Forms.Label BookInfoLabel;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.OpenFileDialog openImgDialog;
    }
}