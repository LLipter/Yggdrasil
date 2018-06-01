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

namespace Yggdrasil
{
    public partial class Main : Form
    {

        private Form lastForm;//usde for getting the login info
        int s = 0;//used as a counter for the recommend books
        int privilege;
        Book currentBook = new Book();
        List<Book> recommends = new List<Book>();//list for the recommend books
        List<Image> recommendsCover = new List<Image>();//list for the covers of the recommend books
        public Main(Form lastForm,int privilege)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.privilege = privilege;
            if (privilege<20) btnBookManagement.Hide();//if the privilege is not high enough,then the user has no right to manage the books
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
            Manage managePage = new Manage();
            managePage.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search searchPage = new Search();
            searchPage.Show();
        }
    

        private void btnBook1_Click(object sender, EventArgs e)
        {
            Book_Interface bkitfPage = new Book_Interface();
            bkitfPage.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            recommends = DatabaseUtility.getRecommendBooks();
            for(int i = 0; i < 3; i++) { imlRecommend.Images[i] = recommends[i].; }
            shiftBook(0);
            
        }
        private void shiftBook(int s)
        {
            piBShow.Image = imlRecommend.Images[s];
            currentBook = recommends[s];
        }
    }

}
