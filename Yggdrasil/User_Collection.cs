using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Yggdrasil.Model;
using System.Net;


namespace Yggdrasil
{
    public partial class User_Collection : Form
    {
        static int totalPage = 0;
        static int pageNum = 0;
        private Form mainForm;
        private ArrayList imageList = new ArrayList();
        private ArrayList labelList = new ArrayList();
        private ArrayList bookList = new ArrayList();
        private int size;


        public User_Collection(Form main)
        {
            InitializeComponent();
            initCon();
            this.mainForm = main;
            if (getData() == 1)
            {
                EmptyMessageLabel.Visible = false;
                showBook();
            }
            else
            {
                EmptyMessageLabel.Visible = true;
            }
            for(int i = 1; i <= totalPage; i++) {

                PagecomboBox.Items.Add(i);
            }
            
        }

        private void initCon()
        {
            imageList.Add(image1);
            imageList.Add(image2);
            imageList.Add(image3);
            imageList.Add(image4);
            imageList.Add(image5);
            imageList.Add(image6);
            labelList.Add(book1);
            labelList.Add(book2);
            labelList.Add(book3);
            labelList.Add(book4);
            labelList.Add(book5);
            labelList.Add(book6);

        }

        private int getData()
        {
            if (DatabaseUtility.getFavorite(ref bookList, Global.user) == -1)
            {
                MessageBox.Show("Error, the network doesn't connect!");
                return -1;
            }
            else
            {
                size = bookList.Count;
                if (size == 0)
                {
                    //MessageBox.Show("Sorry, there isn't such book!");
                    return 0;
                }
                if (size % 6 == 0)
                {
                    totalPage = size / 6;
                }
                else
                {
                    totalPage = (size / 6) + 1;
                }
                return 1;
            }

        }

        private void showBook()
        {
            //int BookNo = 6 * pageNum;
            Book book = new Book();
            Label labelShow = new Label();
            PictureBox imageShow = new PictureBox();

            clear();

            if (6 * pageNum + 5 > size - 1)
            {
                for (int i = 6 * pageNum; i <= size - 1; i++)
                {
                    string location;
                    string targetSite;
                    int temp = i % 6;
                    if (temp == 7)
                    {
                        return;
                    }
                    labelShow = (Label)labelList[temp];
                    imageShow = (PictureBox)imageList[temp];
                    book = (Book)bookList[i];
                    labelShow.Text = book.Book_name;
                    location = book.Location;
                    targetSite = "http://www.irran.top:8080/Yggdrasil/book/" + location + "/cover.jpg";
                    imageShow.Load(targetSite);
                }
            }
            else
            {
                for (int i = 6 * pageNum; i <= 6 * pageNum + 5; i++)
                {
                    string location;
                    string targetSite;
                    int temp = i % 6;
                    if (temp == 7)
                    {
                        return;
                    }
                    labelShow = (Label)labelList[temp];
                    imageShow = (PictureBox)imageList[temp];
                    book = (Book)bookList[i];
                    labelShow.Text = book.Book_name;
                    location = book.Location;
                    targetSite = "http://www.irran.top:8080/Yggdrasil/book/" + location + "/cover.jpg";
                    imageShow.Load(targetSite);
                }
            }
            
           
       
         
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            int CurrentPage = pageNum;
            pageNum = CurrentPage;
            if (pageNum == totalPage-1)
            {
                
                showBook();
            }
            else
            {
                pageNum++;
                showBook();
            }
        }

        private void LastPageButton_Click(object sender, EventArgs e)
        {
            int CurrentPage = pageNum;
            pageNum = CurrentPage;
            if (pageNum == 0)
            {
                
                showBook();
            }
            else
            {
                pageNum--;
                showBook();
            }
        }

        private void clear()
        {
            Label label;
            PictureBox image;

            for (int i = 0; i < 6; i++)
            {
                label = (Label)labelList[i];
                label.Text = "";
            }
            for (int i = 0; i < 6; i++)
            {
                image = (PictureBox)imageList[i];
                image.Image = null;
            }

            //pageNum = 0;
            //totalPage = 0;
           // bookList.Clear();

        }

        private void image1_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                int localBook = pageNum * 6;
                if (localBook < size)
                {
                    Book_Interface book = new Book_Interface((Book)bookList[localBook],this);
                    book.Show();
                    this.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        private void image2_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                int localBook = pageNum * 6 + 1;
                if (localBook < size)
                {
                    Book_Interface book = new Book_Interface((Book)bookList[localBook],this);
                    book.Show();
                    this.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        private void image3_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                int localBook = pageNum * 6 + 2;
                if (localBook < size)
                {
                    Book_Interface book = new Book_Interface((Book)bookList[localBook],this);
                    book.Show();
                    this.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please check your network");
            }

        }

        private void image4_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                int localBook = pageNum * 6 + 3;
                if (localBook < size)
                {
                    Book_Interface book = new Book_Interface((Book)bookList[localBook],this);
                    book.Show();
                    this.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        private void image5_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                int localBook = pageNum * 6 + 4;
                if (localBook < size)
                {
                    Book_Interface book = new Book_Interface((Book)bookList[localBook],this);
                    book.Show();
                    this.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        private void image6_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                int localBook = pageNum * 6 + 5;
                if (localBook < size)
                {
                    Book_Interface book = new Book_Interface((Book)bookList[localBook],this);
                    book.Show();
                    this.Enabled = false;
                }
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

        private void User_Collection_FormClosing(object sender, FormClosingEventArgs e)
        {
            clear();
            pageNum = 0;
            totalPage = 0;
            bookList.Clear();
            labelList.Clear();
            imageList.Clear();
            mainForm.Enabled = true;
        }

        private void PagecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            pageNum = Convert.ToInt32(PagecomboBox.Text)-1;
            showBook();
        }
    }
}
