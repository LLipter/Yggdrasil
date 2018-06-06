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

namespace Yggdrasil
{
    public partial class User_Collection : Form
    {
        static int totalPage = 0;
        static int pageNum = 0;
        private ArrayList imageList = new ArrayList();
        private ArrayList labelList = new ArrayList();
        private ArrayList bookList = new ArrayList();
        private int size;


        public User_Collection()
        {
            InitializeComponent();
            initCon();
            
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
                if (temp == 7)
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
            //pageChangeText.Text = String.Format("{0}/{1}", pageNum, totalPage);
        }

    }
}
