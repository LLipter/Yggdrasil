using System;
using System.Collections;
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
    public partial class Search : Form
    {
        static int pageNum = 0;
        static int totalPage = 0;
        private int size;
        private ArrayList bookList = new ArrayList();
        private ArrayList labelList = new ArrayList();
        private ArrayList imageList = new ArrayList();

        

        public Search()
        {
            InitializeComponent();
            labelList.Add(book1);
            labelList.Add(book2);
            labelList.Add(book3);
            labelList.Add(book4);
            labelList.Add(book5);
            labelList.Add(book6);
            imageList.Add(image1);
            imageList.Add(image2);
            imageList.Add(image3);
            imageList.Add(image4);
            imageList.Add(image5);
            imageList.Add(image6);
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            clear();
            if(searchText.Text == "")
            {
                MessageBox.Show("Please enter the name of book");
            }
            else
            {
                byte[] utf8 = Encoding.UTF8.GetBytes(searchText.Text.ToString());
                string wantBook = Encoding.UTF8.GetString(utf8);
                if (getData(wantBook) == 1)
                {
                    showBook();
                }
            }
        }

        private void changePageButton_Click(object sender, EventArgs e)
        {
            if (pageChangeText.Text == "")
            {
                MessageBox.Show("Please enter the page number!");
            }
            else
            {
                string pageText = pageChangeText.ToString();
                if (pageText.Contains("/"))
                {
                    MessageBox.Show("Please enter number like this--5!");
                }
                else
                {
                    pageNum = Convert.ToInt32(pageText);
                    showBook();
                }
            }

        }

        private void lastPageButton_Click(object sender, EventArgs e)
        {
            if(pageNum == 1)
            {
                MessageBox.Show("This is the first page!");
            }
            else
            {
                pageNum--;
                showBook();
            }
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            if (pageNum == totalPage)
            {
                MessageBox.Show("This is the Last page!");
            }
            else
            {
                pageNum++;
                showBook();
            }
        }

        private int getData(String name)
        {
            if (DatabaseUtility.getBookByName(ref bookList, name) == -1)
            {
                MessageBox.Show("Error, the network doesn't connect!");
                return -1;
            }
            else
            {
                size = bookList.Count;
                if(size == 0)
                {
                    MessageBox.Show("Sorry, there isn't such book!");
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
            Book book = new Book();
            Label labelShow = new Label();
            PictureBox imageShow = new PictureBox();
            for (int i = 6 * pageNum + 1; i <= size; i++)
            {
                string location;
                string targetSite;
                int temp = i % 6;
                if(temp == 7)
                {
                    return;
                }
                labelShow = (Label)labelList[temp - 1];
                imageShow = (PictureBox)imageList[temp - 1];
                book = (Book)bookList[temp - 1];
                labelShow.Text = book.Book_name;
                location = book.Location;
                targetSite = "http://www.irran.top:8080/Yggdrasil/book/" + location + "/cover.jpg";
                imageShow.Load(targetSite);
            }
            if (pageNum == 0)
            {
                pageNum++;
            }
            pageChangeText.Text = String.Format("{0}/{1}",pageNum,totalPage);
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

            pageNum = 0;
            totalPage = 0;
            bookList.Clear();
        }

        private void pageChangeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
