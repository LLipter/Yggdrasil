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

        //移动窗体
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.Location.X - this.oldX; //新的鼠标位置
                this.Top += e.Location.Y - this.oldY;
            }
        }
        private int oldX = 0;
        private int oldY = 0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.oldX = e.Location.X; //鼠标原来位置
                this.oldY = e.Location.Y;
            }
        }
        //关闭窗体
        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text == "") { MessageBox.Show("Please input username!"); }
            else if (txtPassword.Text == "") { MessageBox.Show("Please input password!"); }
            else { 
            User currentUser = new User();
            int situation = DatabaseUtility.getUser(ref currentUser, txtAccount.Text);
            if (situation == -1) { MessageBox.Show("You have some problems about the Internet!"); }
            else
            {
                Global.user = currentUser;
                    if (currentUser == User.noSuchUser) { MessageBox.Show("The user doesn't exist"); }
                    else
                    {
                        if(currentUser.Passwd == txtPassword.Text){
                            Main mainPage = new Main(this);
                            mainPage.Show();
                            txtAccount.Text = "";
                            txtPassword.Text = "";
                            this.Hide();
                        }
                        else MessageBox.Show("Password is not correct.");

                    }
            }
        } 
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            Signin signInPage = new Signin(this);
            signInPage.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //this.skinEngine1.SkinFile = "RealOne.ssk";//***为皮肤名称
        }
    }
}
