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
using System.IO;

namespace Yggdrasil
{
    
    public partial class Read_Interface : Form
    {
        
        public static int pageNumber = 1;
        static int totalPage = 2;
        int head = 0;
       // public static string url = string.Format(@"http://www.irran.top:8080/Yggdrasil/book/yyjw12315s4fe87g98f4dw/1.txt");
        public Read_Interface()
        {
            InitializeComponent();
            ChapterNameText.Text = string.Format(@"Chapter"+Book_Interface.chapNo.ToString());
            WebClient wc = new WebClient();
            Stream FirstPage = wc.OpenRead(Book_Interface.url);
            StreamReader sr = new StreamReader(FirstPage, Encoding.UTF8);
            String content = sr.ReadToEnd();
            content = content.Replace("\n", "\r\n");
            totalPage = Convert.ToInt32(content.Length / 500) + 1;
            head = (pageNumber - 1) * 500;
            BookContents.Text = content.Substring(head, 500);

            FirstPage.Close();
            sr.Close();
            wc.Dispose();
        }

        private void ChapterName_TextChanged(object sender, EventArgs e)
        {

        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            pageNumber--;
            if (pageNumber <= 0)
            {
                pageNumber = 0;
                BookContents.Text = "Sorry! This is the first page of current chapter";
            }
            else
            {
                WebClient wc = new WebClient();
                Stream CurrentPage = wc.OpenRead(Book_Interface.url);
                StreamReader sr = new StreamReader(CurrentPage, Encoding.UTF8);
                String content = sr.ReadToEnd();
                content = content.Replace("\n", "\r\n");
                head = (pageNumber - 1) * 500;
                if (content.Length - head >= 500)
                {
                    BookContents.Text = content.Substring(head, 500);
                }
                else
                {
                    BookContents.Text = content.Substring(head, content.Length - head - 1);
                }
                CurrentPage.Close();
                sr.Close();
                wc.Dispose();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)      
        {
            pageNumber++;
            if (pageNumber > totalPage)
            {
                pageNumber = totalPage + 1;
                BookContents.Text = "Sorry! This is the last page of current chapter";
            }
            else
            {
                WebClient wc = new WebClient();
                Stream CurrentPage = wc.OpenRead(Book_Interface.url);
                StreamReader sr = new StreamReader(CurrentPage, Encoding.UTF8);
                String content = sr.ReadToEnd();
                content = content.Replace("\n", "\r\n");
                head = (pageNumber - 1) * 500;
                if (content.Length - head >= 500)
                {
                    BookContents.Text = content.Substring(head, 500);
                }
                else
                {
                    BookContents.Text = content.Substring(head, content.Length - head - 1);
                }
                CurrentPage.Close();
                sr.Close();
                wc.Dispose();
            }


        }

        private void Contents_TextChanged(object sender, EventArgs e)
        {

        }

        private void Read_Interface_Load(object sender, EventArgs e)
        {

        }
    }
}
