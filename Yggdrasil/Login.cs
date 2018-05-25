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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text == null) { MessageBox.Show("Please input username!"); }
            if (txtPassword.Text == null) { MessageBox.Show("Please input password!"); }
            User currentUser = new User();
            int situation = DatabaseUtility.getUser(ref currentUser, txtAccount.Text);
            if (situation == -1) { MessageBox.Show("You have some problems about the Internet!"); }
            else { }
            if (currentUser == User.noSuchUser) { MessageBox.Show("The user doesn't exist"); }
            Main mainPage = new Main(this,30);
            mainPage.Show();
            this.Hide();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            Signin signInPage = new Signin(this);
            signInPage.Show();
            this.Hide();
        }
    }
}
