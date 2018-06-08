using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yggdrasil.Model;
using System.Net;

namespace Yggdrasil
{
    public partial class Main : Form
    {
        private Form lastForm;//usde for getting the login info
        int s = 0;//used as a counter for the recommend books
        int privilege;
        Book currentBook = new Book();
        ArrayList recommends = new ArrayList();//list for the recommend books
        public Main(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.privilege = Global.user.Privilege;
            if (privilege<10) btnBookManagement.Hide();//if the privilege is not high enough,then the user has no right to manage the books
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastForm.Close();
        }

        private void timShow_Tick(object sender, EventArgs e)
        {
            if (s < 4) {}
            else { s -= 4; }
            shiftBook(s);
            s++;
        }

        private void btnShow1_Click(object sender, EventArgs e)
        {
            shiftBook(0);
            
        }

        private void btnShow2_Click(object sender, EventArgs e)
        {
            shiftBook(1);
            
        }

        private void btnShow3_Click(object sender, EventArgs e)
        {
            shiftBook(2);
            
        }

        private void btnShow4_Click(object sender, EventArgs e)
        {
            shiftBook(3);
            
        }

        private void btnBookManagement_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                Manage managePage = new Manage(this);
                managePage.Show();
                this.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {  
            if (IsInternetAvailable())
            {
                if (txtSearch.Text != "")
                {
                    Search searchPage = new Search(txtSearch.Text, this);
                    searchPage.Show();
                    this.Enabled = false;
                }
                else MessageBox.Show("Please input information!");
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }
    
        private void btnBook1_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                Book_Interface bkitfPage = new Book_Interface(currentBook,this);
                bkitfPage.Show();
                this.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            int status = DatabaseUtility.getBooks(ref recommends,7);
            int counter = 0;
            if (status == -1) { MessageBox.Show("You have some problems about the Internet!"); }
            else
            {
                for (; counter <= 3; counter++)
                {
                    imlRecommend.Images.Add(((Book)recommends[counter]).getCover());
                }
                shiftBook(0);
            }
            //将展示按钮文字与书本名称对应，将下方的推荐书目图片，书名对应
            {
                btnShow1.Text = ((Book)recommends[0]).Book_name;
                btnShow2.Text = ((Book)recommends[1]).Book_name;
                btnShow3.Text = ((Book)recommends[2]).Book_name;
                btnShow4.Text = ((Book)recommends[3]).Book_name;

                picBox1.Image = ((Book)recommends[4]).getCover();
                lblBook1.Text = ((Book)recommends[4]).Book_name;

                picBox2.Image = ((Book)recommends[5]).getCover();
                lblBook2.Text = ((Book)recommends[5]).Book_name;

                picBox3.Image = ((Book)recommends[6]).getCover();
                lblBook3.Text = ((Book)recommends[6]).Book_name;
            }


        }

        private void shiftBook(int s)
        {
            piBShow.Image = imlRecommend.Images[s];
            currentBook = (Book)recommends[s];
        }

        private void picBox1_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                Book_Interface bookInfo = new Book_Interface(((Book)recommends[4]),this);
                bookInfo.Show();
                this.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        private void picBox2_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                Book_Interface bookInfo = new Book_Interface(((Book)recommends[5]),this);
                bookInfo.Show();
                this.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        private void picBox3_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                Book_Interface bookInfo = new Book_Interface(((Book)recommends[6]),this);
                bookInfo.Show();
                this.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }
        
        //function used to check network
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

        private void CollectionButton_Click(object sender, EventArgs e)
        {
            User_Collection myCollection = new User_Collection(this);
            myCollection.Show();
            this.Enabled = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            lastForm.Show();
        }
    }

}
