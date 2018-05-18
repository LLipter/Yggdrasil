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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Form3 mainPage = new Form3();
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
