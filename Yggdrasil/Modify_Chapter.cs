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
        private User user = new User();
        private string bookUrl;
        private static int chapterNo = 1;
        private int bookId = 0;
        private string initCon;
        private string initNewCon;
        private string initAuthor;
        private ArrayList authorList = new ArrayList();

        public Modify_Chapter()
        {
            InitializeComponent();
        }

        public Modify_Chapter(int theBookId)
        {
            InitializeComponent();
            bookId = theBookId;
            if (DatabaseUtility.getBookByIDInAdmin(ref book, bookId) == -1)
            {
                MessageBox.Show("There is no Internet!");
            }
            else
            {
                for (int i = 1; i <= book.Chapter_no; i++)
                {
                    chapterBox.Items.Add(i);
                }
            }
            if (DatabaseUtility.getAuthors(ref authorList) == -1)
            {
                MessageBox.Show("There is no Internet!");
            }
            else
            {
                for (int i = 0; i < authorList.Count; i++)
                {
                    user = (User)authorList[i];
                    authorBox.Items.Add(user.User_name);
                }
            }
            User temp = (User)authorList[0];
            initAuthor = temp.User_name;
            initCon = chapterContent.Text.ToString();
            initNewCon = newBookContent.Text.ToString();
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
            string author = authorBox.Text.ToString();

            if (initCon == content && author == initAuthor)
            {
                MessageBox.Show("Please change the content and the click the button!");
            }
            else if(initCon != content && author == initAuthor)
            {
                if (DatabaseUtility.modifyBookContent(book, chapterNo, content) == -1)
                {
                    MessageBox.Show("There is something wrong with the content!");
                }
            }else if(initCon == content && author != initAuthor)
            {
                if(DatabaseUtility.modifyAuthorByName(author, bookId) == 0)
                {
                    MessageBox.Show("There already exists the author!");
                }
            }
            else
            {
                if (DatabaseUtility.modifyBookContent(book, chapterNo, content) == -1)
                {
                    MessageBox.Show("There is something wrong with the content!");
                }
                if (DatabaseUtility.modifyAuthorByName(author, bookId) == 0)
                {
                    MessageBox.Show("There already exists the author!");

                }
            }
            chapterContent.Text = "";
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            Stream FirstPage = wc.OpenRead(bookUrl);
            StreamReader sr = new StreamReader(FirstPage, Encoding.UTF8);
            String content = sr.ReadToEnd();
            content = content.Replace("\n", "\r\n");
            if (content.Length > 500)
                chapterContent.Text = content.Substring(0, 500);
            else
                chapterContent.Text = content;
            initCon = chapterContent.Text.ToString();

            FirstPage.Close();
            sr.Close();
            wc.Dispose();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string newContent = newBookContent.Text.ToString();
            int newChapNo = Convert.ToInt32(newChapterNo.Text.ToString());
            if(newChapNo > book.Chapter_no) {
                DatabaseUtility.updateChapterNoByBookId(newChapNo,bookId);
                if (DatabaseUtility.modifyBookContent(book, newChapNo, newContent) == -1)
                {
                    MessageBox.Show("There is something wrong with the content!");
                }
                else
                    refresh();
            }
            else
            {
                MessageBox.Show("Please enter the book content!");
            }
            newChapterNo.Text = "";
            newBookContent.Text = "";
        }

        private void refresh()
        {
            DatabaseUtility.getBookByIDInAdmin(ref book, bookId);
            chapterBox.Items.Clear();
            for (int i = 1; i <= book.Chapter_no; i++)
            {
                chapterBox.Items.Add(i);
            }
            initNewCon = "";
        }

        private void newChapterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void chapterContent_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
