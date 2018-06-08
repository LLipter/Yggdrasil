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
    public partial class Add_Book : Form
    {   
        
        public Add_Book()
        {
            InitializeComponent();
        }

        private void SelectCoverButton_Click(object sender, EventArgs e)
        {
            openImgDialog.Multiselect = false;
            openImgDialog.RestoreDirectory = true;
            openImgDialog.Filter = "JPG|*.jpg";
            openImgDialog.ShowDialog();
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            int situation;
            string bookName,bookInfo;
            bookName = BookNameBox.Text.Replace("\\", "\\\\");
            bookName = BookNameBox.Text.Replace("'", "\\'");
            bookInfo = InfoBox.Text.Replace("\\", "\\\\");
            bookInfo = InfoBox.Text.Replace("'", "\\'");
            if (IsInternetAvailable())
            {
                if (BookNameBox.Text == "")
                {
                    MessageBox.Show("Please input the book name");
                }else if (InfoBox.Text == "")
                {
                    MessageBox.Show("Please input the book info");
                }else if (openImgDialog.FileName == "")
                {
                    MessageBox.Show("Please select one cover Img");
                }
                situation = DatabaseUtility.addBook(bookName, bookInfo, openImgDialog.FileName);
                if(situation == 1)
                {
                    MessageBox.Show("Add successful!");
                }
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        private bool IsInternetAvailable()
        {
            try
            {
                Dns.GetHostEntry("www.baidu.com");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private void NewBookNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
