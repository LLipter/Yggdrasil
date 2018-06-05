using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Yggdrasil.Model;
using System.Collections;

namespace Yggdrasil
{
    
    public partial class Book_Interface : Form
    {   
        
        private string bookURL;
        private Book currentBook;
        public static int chapNo = 1;
        private ArrayList bookComments;

        public Book_Interface(Book cbook)
        {
            InitializeComponent();
            ContinueReadButton.Visible = false;
            currentBook = cbook;
            bookURL = string.Format(@"http://www.irran.top:8080/Yggdrasil/book/" + currentBook.Location + "/1.txt");

            Image Cover = Image.FromStream(WebRequest.Create("http://www.irran.top:8080/Yggdrasil/book/"+currentBook.Location+"/cover.jpg").GetResponse().GetResponseStream());
            pictureBox1.Image = Cover;
            BookNameLabel.Text = currentBook.Book_name;
            Summary.Text = currentBook.getInfo();
            for (int i = 1; i <= currentBook.Chapter_no; i++)
            {
                ChapterBox.Items.Add(i);
            }
        }

        private void BookNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SummaryBox_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void ChapterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bookURL = string.Format(@"http://www.irran.top:8080/Yggdrasil/book/"+currentBook.Location+"/"+ChapterBox.Text+".txt");
            chapNo = Convert.ToInt32(ChapterBox.Text);
        }

        private void BeginReadButton_Click(object sender, EventArgs e)
        {

            ContinueReadButton.Visible = true;
            this.Hide();
            Read_Interface.pageNumber = 1;
            Read_Interface readInter = new Read_Interface(bookURL);
            readInter.ShowDialog();
           
            this.Show();
            
        }
        private void BeginReadButton_OnMouseEnter(object sender, EventArgs e)
        {
            string path = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            path += @"\pic\button2.png";
            BeginReadButton.BackgroundImage = Image.FromFile(path);
        }
        private void BeginReadButton_OnMouseLeave(object sender, EventArgs e)
        {
            string path = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            path += @"\pic\button1.png";
            BeginReadButton.BackgroundImage = Image.FromFile(path);
        }

        public string getBookURL()
        {
            return bookURL;
        }

        private void Book_Interface_Load(object sender, EventArgs e)
        {

        }

        private void ContinueReadButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Read_Interface readInter = new Read_Interface(bookURL);
            readInter.ShowDialog();
            this.Show();
        }
    }
}
