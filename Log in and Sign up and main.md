# #4 Log in and Sign up
Log in and sign up are two basic parts that are necessary for every complete application. All we need to do is never let any error thrown out.
In order to make the log in procedure more convenient,we want to let user log in by click "enter" button, so we realize it with the codes below.

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.btnLogIn_Click(sender, e);//触发button事件  
            }
        }

        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.btnLogIn_Click(sender, e);//触发button事件  
            }
        }
This makes user directly log in without clicking the mouse.

When we get the content of username and password, we have to judge if the content is valid,so we realize it with codes below.

        if (txtAccount.Text == "") { MessageBox.Show("Please input username!"); }
        else if (txtPassword.Text == "") { MessageBox.Show("Please input password!"); }
        else 
        { 
            User currentUser = new User();
            string Acount;
            Acount = txtAccount.Text.Replace("\\", "\\\\");
            Acount = txtAccount.Text.Replace("'", "\\'");
        }

We use a *global* class to store some gobal objects like current user. We change the object of current user to change the account of logging in.

     class Global
    {
        public static User user;   // represents current user
    }
So in the Log in button's function, we have this code to do its function.

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

In the Sign up part,we totally do the same judging job to make sure everything input is right for the system. And we encapsulate the content about communication with the database in the *DatabaseUtility* class to simplify the code in the form design.

Main form is the most important showing form in the whole system. We recommend book for users, we get several books from our database and put their covers in the imagelist to store,and showing them in a picture box. We use a timer to change the picture box's image to dynamicly show the cover of one of the recommended books.

        Book currentBook = new Book();
        ArrayList recommends = new ArrayList();//list for the recommend books
         private void timShow_Tick(object sender, EventArgs e)
        {
            if (s < 4) {}
            else { s -= 4; }
            shiftBook(s);
            s++;
        }
        private void shiftBook(int s)
        {
            piBShow.Image = imlRecommend.Images[s];
            currentBook = (Book)recommends[s];
        }

And in the constructor of the main form,we'll decide whether to hide the *Book Manage* button by judging the privildge.

    public Main(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.privilege = Global.user.Privilege;
            if (privilege<10) btnBookManagement.Hide();
            //if the privilege is not high enough,then the user has no right to manage the books
        }