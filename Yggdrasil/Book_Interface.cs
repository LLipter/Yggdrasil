using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Yggdrasil.Model;
using System.Collections;

namespace Yggdrasil
{
    
    public partial class Book_Interface : Form
    {   
        
        private string bookURL;
        private Book currentBook;
        public static int chapNo = 1;
        private int TotalChapNo;
        private ArrayList bookComments;
        private Comment UserComment;
        private bool IsFavorite;
        private Form lastWinform;
        //private User user1;
        public Book_Interface(Book cbook,Form LastForm)
        {
            InitializeComponent();
            lastWinform = LastForm;
            ContinueReadButton.Visible = false;
            currentBook = cbook;
            TotalChapNo = currentBook.Chapter_no;
            bookURL = string.Format(@"http://www.irran.top:8080/Yggdrasil/book/" + currentBook.Location + "/1.txt");
            

            //Judge whether the network is available
            if (IsInternetAvailable())
            {   
                DatabaseUtility.checkFavorite(ref IsFavorite, Global.user, currentBook);//Check whether the book is user's favorite
                if (IsFavorite)
                {
                    CollectButton.Text = "Remove from Collection";
                }
                else
                {
                    CollectButton.Text = "Add to My Collection";
                }

                Image Cover = Image.FromStream(WebRequest.Create("http://www.irran.top:8080/Yggdrasil/book/" + currentBook.Location + "/cover.jpg").GetResponse().GetResponseStream());
                pictureBox1.Image = Cover;
                BookNameLabel.Text = currentBook.Book_name;
                Summary.Text = currentBook.getInfo();
                for (int i = 1; i <= currentBook.Chapter_no; i++)
                {
                    ChapterBox.Items.Add(i);
                }
                DatabaseUtility.getComments(ref bookComments, currentBook);

                for (int j = 0; j < bookComments.Count; j++)
                {   
                    Comment newCommentItem = (Comment)bookComments[j];
                  
                    CommentsBox.AppendText(newCommentItem.User_name + "-------" + newCommentItem.Create_date.ToString() + "\r\n" + newCommentItem.Content.ToString() + "\r\n" + "\r\n");

                }
            }
            else
            {
                MessageBox.Show("Please check your network!");
            }

        }
        //This imcomplete function may be useful if you want to improve the performance
        

        private void ChapterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContinueReadButton.Visible = false;
            bookURL = string.Format(@"http://www.irran.top:8080/Yggdrasil/book/"+currentBook.Location+"/"+ChapterBox.Text+".txt");
            chapNo = Convert.ToInt32(ChapterBox.Text);
        }

        private void BeginReadButton_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                if (TotalChapNo > 0)
                {
                    ContinueReadButton.Visible = true;
                    this.Hide();
                    Read_Interface.pageNumber = 1;
                    Read_Interface readInter = new Read_Interface(bookURL);
                    readInter.ShowDialog();

                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sorry,The contents haven't been put on now");
                }
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        public string getBookURL()
        {
            return bookURL;
        }

        private void Book_Interface_Load(object sender, EventArgs e)
        {

        }

        private void ContinueReadButton_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                this.Hide();
                Read_Interface readInter = new Read_Interface(bookURL);
                readInter.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        private void CommentButton_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                UserComment = new Comment();
                UserComment.User_id = Global.user.User_id;
                UserComment.Book_id = currentBook.Book_id;
                UserComment.Content = WriteCommentBox.Text.ToString();
                UserComment.Content = UserComment.Content.Replace("\\", "\\\\");
                UserComment.Content = UserComment.Content.Replace("'", "\\'");
                int commitSuccess = DatabaseUtility.setComment(ref UserComment);
                CommentsBox.Clear();
                DatabaseUtility.getComments(ref bookComments, currentBook);

                for (int j = 0; j < bookComments.Count; j++)
                {
                    Comment newCommentItem = (Comment)bookComments[j];
                    CommentsBox.AppendText(newCommentItem.User_name + "-------" + newCommentItem.Create_date.ToString() + "\r\n" + newCommentItem.Content.ToString() + "\r\n" + "\r\n");

                }
                WriteCommentBox.Clear();
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

        //function used to check network
        private bool IsInternetAvailable()
        {
            try
            {
                Dns.GetHostEntry("www.baidu.com");
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }

        private void CollectButton_Click(object sender, EventArgs e)
        {
            if (!IsFavorite)
            {
                IsFavorite = true;
                CollectButton.Text = "Remove from Collection";
                if (IsInternetAvailable())
                {    
                    int situation;
                    situation = DatabaseUtility.setFavorite(Global.user, currentBook);
                    if (situation == 1)
                    {
                        MessageBox.Show("Add successfully");
                    }
                    else if (situation == -2)
                    {
                        MessageBox.Show("This book has already been in your collection!");
                    }
                }
                else
                {
                    MessageBox.Show("Please check your network");
                }
            }
            else
            {
                IsFavorite = false;
                CollectButton.Text = "Add to My Collection";
                if (IsInternetAvailable())
                {
                    int situation;
                    situation = DatabaseUtility.removeFavorite(Global.user, currentBook);
                    if (situation == 1)
                    {
                        MessageBox.Show("Remove successfully");
                    }
                    else if (situation == -2)
                    {
                        MessageBox.Show("This book has already been removed!");
                    }
                }
                else
                {
                    MessageBox.Show("Please check your network");
                }
            }
        }

        private void Book_Interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastWinform.Enabled = true;
        }
    }
}
