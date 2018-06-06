using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yggdrasil.Model;
using System.Net;
using System.IO;
using System.Collections;

namespace Yggdrasil
{
    public partial class Modify_Chapter : Form
    {
        private Book book = new Book();
        private string bookUrl;
        private static int chapterNo = 1;
        private int bookId = 0;

        public Modify_Chapter()
        {
            InitializeComponent();
        }

        public Modify_Chapter(int theBookId)
        {
            InitializeComponent();
            bookId = theBookId;
            DatabaseUtility.getBookByID(ref book,bookId);
        }

        private void Chapter_Load(object sender, EventArgs e)
        {

        }

        private void chapterBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            bookUrl = string.Format(@"http://www.irran.top:8080/Yggdrasil/book/" + book.Location + "/" + chapterBox.Text + ".txt");
            chapterNo = Convert.ToInt32(chapterBox.Text);
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            string content = chapterContent.Text.ToString();
            if (DatabaseUtility.modifyBookContent(book, chapterNo, content) == -1)
            {
                MessageBox.Show("There is something wrong with the content!");
            } 
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            Stream FirstPage = wc.OpenRead(bookUrl);
            StreamReader sr = new StreamReader(FirstPage, Encoding.UTF8);
            String content = sr.ReadToEnd();
            content = content.Replace("\n", "\r\n");
            chapterContent.Text = content.Substring(0, 500);

            FirstPage.Close();
            sr.Close();
            wc.Dispose();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string newContent = chapterContent.Text.ToString();
            int newChapNo = Convert.ToInt32(newChapterNo.Text.ToString());
            if (DatabaseUtility.modifyBookContent(book, newChapNo, newContent) == -1)
            {
                MessageBox.Show("There is something wrong with the content!");
            }
            else
                DatabaseUtility.getBookByID(ref book, bookId);
        }

        private void newChapterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
