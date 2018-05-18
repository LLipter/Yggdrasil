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
    public partial class Signin : Form
    {
        Form lastForm;
        public Signin(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if(txtAccount!=null && txtPassword != null)
            {
                if (txtConfirmPassword.Text == txtPassword.Text)
                {
                    this.Close();
                    lastForm.Show();
                }
                else
                {
                    Warning warningPage = new Warning("The password and confirm password don't match!");
                    warningPage.Show();
                }
            }
            
           
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lastForm.Show();
            this.Close();
        }
    }
}
