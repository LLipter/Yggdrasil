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
    public partial class Signin : Form
    {
        Form lastForm;
        public Signin(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }


        private void btnCommit_Click(object sender, EventArgs e)
        {

            if (txtAccount.Text == "") { MessageBox.Show("Please input username!"); }
            else if (txtPassword.Text == "") { MessageBox.Show("Please input password!"); }
            else
            {
                if (txtConfirmPassword.Text != txtPassword.Text)
                {
                    MessageBox.Show("The password and confirm password don't match!", "Warning!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    User currentUser = new User();
                    currentUser.User_name = txtAccount.Text;
                    currentUser.Passwd = txtPassword.Text;
                    this.Close();
                    lastForm.Show();
                }
            }
            
           
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lastForm.Show();
            this.Close();
        }
    }
}
