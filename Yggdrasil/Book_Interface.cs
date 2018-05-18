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
    public partial class Book_Interface : Form
    {
        public Book_Interface()
        {
            InitializeComponent();
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

        }

        private void BeginReadButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Read_Interface readInter = new Read_Interface();
            readInter.ShowDialog();
            this.Visible = true;
            
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
    }
}
