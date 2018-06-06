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

namespace Yggdrasil
{
    public partial class User_Collection : Form
    {
        private ArrayList imageList = new ArrayList();
        private ArrayList labelList = new ArrayList();

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
    }
}
