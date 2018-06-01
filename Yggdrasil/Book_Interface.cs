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

namespace Yggdrasil
{
    
    public partial class Book_Interface : Form
    {
        public static string url = string.Format(@"http://www.irran.top:8080/Yggdrasil/book/yyjw12315s4fe87g98f4dw/1.txt");
        private Book currentBook = new Book();
        public Book_Interface()
        {
            currentBook.Chapter_no = 5;
            InitializeComponent();
            Image Cover = Image.FromStream(WebRequest.Create("http://www.irran.top:8080/Yggdrasil/book/yyjw12315s4fe87g98f4dw/cover.jpg").GetResponse().GetResponseStream());
            pictureBox1.Image = Cover;
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
            url = string.Format(@"http://www.irran.top:8080/Yggdrasil/book/yyjw12315s4fe87g98f4dw/"+ChapterBox.Text+".txt");
        }

        private void BeginReadButton_Click(object sender, EventArgs e)
        {
            

            this.Hide();
            Read_Interface.pageNumber = 1;
            Read_Interface readInter = new Read_Interface();
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

        private void Book_Interface_Load(object sender, EventArgs e)
        {

        }
    }
}
