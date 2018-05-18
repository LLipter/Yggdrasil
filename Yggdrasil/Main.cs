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
    public partial class Main : Form
    {

        private Form lastForm;
        int s = 0;
        
        public Main(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastForm.Close();
        }

        private void timShow_Tick(object sender, EventArgs e)
        {
            if (s < 4) {}
            else { s -= 4; }
            piBShow.Image = imlRecommend.Images[s];
            s++;
        }

        private void btnShow1_Click(object sender, EventArgs e)
        {
            piBShow.Image = imlRecommend.Images[0];
        }

        private void btnShow2_Click(object sender, EventArgs e)
        {
            piBShow.Image = imlRecommend.Images[1];
        }

        private void btnShow3_Click(object sender, EventArgs e)
        {
            piBShow.Image = imlRecommend.Images[2];
        }

        private void btnShow4_Click(object sender, EventArgs e)
        {
            piBShow.Image = imlRecommend.Images[3];
        }
    }
}
