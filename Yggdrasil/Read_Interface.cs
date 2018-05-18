using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Yggdrasil
{
    
    public partial class Read_Interface : Form
    {
        static int pageNumber = 1;
        static int totalPage = 2;
        public Read_Interface()
        {
            InitializeComponent();
        }

        private void ChapterName_TextChanged(object sender, EventArgs e)
        {

        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            pageNumber--;
            if (pageNumber == 0)
            {
                BookContents.Text = "Sorry! This is the first page of current chapter";
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
            
        {
            pageNumber++;
            if (pageNumber == totalPage)
            {
                BookContents.Text = "Sorry! This is the last page of current chapter";
            }
        }

        private void Contents_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}
