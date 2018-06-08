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
            string Acount, NickName,password;
            Acount = txtAccount.Text.Replace("\\", "\\\\");
            Acount = txtAccount.Text.Replace("'", "\\'");
            NickName  = txtAccount.Text.Replace("\\", "\\\\");
            NickName  = txtAccount.Text.Replace("'", "\\'");
            password  = txtAccount.Text.Replace("\\", "\\\\");
            password  = txtAccount.Text.Replace("'", "\\'");

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
                    currentUser.User_name = Acount ;
                    currentUser.Passwd = password;
                    currentUser.Nick_name = NickName;
                    int situation = DatabaseUtility.register(ref currentUser);
                    if (situation == -1) { MessageBox.Show("You have some problems about the Internet!"); }
                    else if(situation == -2)
                    {
                        MessageBox.Show("Duplicate user name!");
                    }
                    else
                    {
                        MessageBox.Show("You have signed in successfully!", "Success!",MessageBoxButtons.OK);
                        this.Close();
                        lastForm.Show();
                    }
                    
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

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
    || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
