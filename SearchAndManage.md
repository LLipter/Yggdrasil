#1.1 Search Form
In the form, the user can search for the book he wants to read by entering the name of it. But the name can be just one character of the actual name.  
So we will allow user to enter the textbox. At the same time, user can enter "\" or "'" even though we use c# for the system. And evertime the form will show 6 books.
###So our code shold be like
```c#

    private void searchButton_Click(object sender, EventArgs e)
        {
            if (IsInternetAvailable())
            {
                clear();
                pageNum = 0;
                totalPage = 0;
                bookList.Clear();
                if (searchText.Text == "")
                {
                    MessageBox.Show("Please enter the name of book");
                }
                else
                {
                    byte[] utf8 = Encoding.UTF8.GetBytes(searchText.Text.ToString());
                    string wantBook = Encoding.UTF8.GetString(utf8);
                    if (getData(wantBook) == 1)
                    {
                        showBook();
                    }
                    PageLabel.Text = string.Format("{0}/{1}", pageNum + 1, totalPage);
                }
            }
            else
            {
                MessageBox.Show("Please check your network");
            }
        }

    private int getData(String name)
        {
            string SearchItem;
            SearchItem = name.Replace("\\", "\\\\");
            SearchItem = name.Replace("'", "\\'");
            if (DatabaseUtility.getBookByName(ref bookList, SearchItem) == -1)
            {
                MessageBox.Show("Error, the network doesn't connect!");
                return -1;
            }
            else
            {
                size = bookList.Count;
                if(size == 0)
                {
                    MessageBox.Show("Sorry, there isn't such book!");
                    return 0;
                }
                if (size % 6 == 0)
                {
                    totalPage = size / 6;
                }
                else
                {
                    totalPage = (size / 6) + 1;
                }
                return 1;
            }
        }
```  

#1.2 What the user can do aftering searching 
Then we hope the user can go to the interface of book by clicing the image of book. And if the result of searching has more than 6 books, user can click the last button and next button to see the other books. But if it has been the first page or next page, the books won't change. And at last, user can click the book report button to get the report about the 6 books shown in current page.


#2.1 Manage From
Only the administrator can see the book management button the main form. The manage can modify the information of book like book_name, type_name, user_name and book_status. The user is the author. As for the book_status, if manager change it to 0, the user can't search for it in the search form. But the other things like book_id and modify_date is read-only. We use DataGridView to show the information of all books. And after modifying, manager clicks commit button to update the correspond things in the database. And at the same time the modify_date will be updated, too.
###SO our code should be like
```C#  

    private void dbUpdate()
        {
            conn.Open();
            MySqlCommand cmd;
            int bookId;
            int otherId;
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j< column; j++)
                {
                    if(changedItem[j,i] != null)
                    {
                        switch (j)
                        {
                            case 1:
                                bookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                                string sqlStr1 = string.Format("UPDATE book " +
                                                               "SET book_name = '{0}' " +
                                                               "WHERE book_id = '{1}' ",changedItem[j,i],bookId);
                                cmd = new MySqlCommand(sqlStr1, conn);
                                if(cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("There is something wrong with updating!");
                                    break;
                                }
                                break;
                            case 4:
                                bookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                                otherId = Convert.ToInt32(changedItem[j, i]);
                                string sqlStr4 = string.Format("UPDATE book " +
                                                               "SET publisher_id = '{0}' " +
                                                               "WHERE book_id = '{1}' ", otherId, bookId);
                                cmd = new MySqlCommand(sqlStr4, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("There is something wrong with updating!");
                                    break;
                                }
                                break;
                            case 6:
                                bookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                                int status = Convert.ToInt32(changedItem[j, i]);
                                string sqlStr6 = string.Format("UPDATE book " +
                                                               "SET book_status = '{0}' " +
                                                               "WHERE book_id = '{1}' ", status, bookId);
                                cmd = new MySqlCommand(sqlStr6, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("There is something wrong with updating!");
                                    break;
                                }
                                break;
                        }
                        int theBookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                        booksView[8, i].Value = System.DateTime.Now;
                        DatabaseUtility.updateModifyDateByBookId(theBookId);
                    }
                }
            }
            conn.Close();
        }
```
#2.1.1 Cell Value Changed
But what should we do if manager changes the value of other table in other table. We use cellValueChange event. When such things are changed, we will search for the changed value in the  database, if it doesn't exist, it will be insert into corresponding table. But if manager enters nothing, the system will remind him and the value will be recovered. In addition, the book_status can only be entered 0 or 1, if manager enters other number, the system will remind him. And when manager modifies the information, he can only press the characters, numbers and Backspace.

###So our code should be like
```C#  

    private void booksView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int ecolumn = e.ColumnIndex;
            int erow = e.RowIndex;
            byte[] utf8 = Encoding.UTF8.GetBytes(booksView[ecolumn, erow].Value.ToString());
            string value = Encoding.UTF8.GetString(utf8);
            switch (ecolumn)
            {
                case 1:
                    if (value == "")
                    {
                        conn.Open();
                        MessageBox.Show("The cell can't be empty!");
                        int bookId11 = Convert.ToInt32(booksView[0, erow].Value.ToString());
                        string sql11 = string.Format("SELECT book_name FROM book WHERE book_id = '{0}' ", bookId11);
                        MySqlCommand cmd11 = conn.CreateCommand();
                        cmd11.CommandText = sql11;
                        MySqlDataReader reader11 = cmd11.ExecuteReader();
                        string oldBook = "";
                        while (reader11.Read())
                            oldBook = reader11.GetString("book_name");
                        reader11.Close();
                        conn.Close();
                        booksView[ecolumn, erow].Value = oldBook;
                        break;
                    }
                    else
                    {
                        changedItem[ecolumn, erow] = value;
                        break;
                    }
                case 3:
                    if (value != "")
                    {
                        conn.Open();

                        string tempSql1 = "SELECT type_name FROM type ";
                        string tempSql2 = string.Format("INSERT INTO type(type_name) values('{0}') ", value);

                        if (compareInDb(tempSql1, value, "type_name") == 0)
                        {
                            MySqlCommand tempCmd = new MySqlCommand(tempSql2, conn);
                            if (tempCmd.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("There is something wrong with inserting!");
                            }
                        }
                        string tempSql3 = string.Format("SELECT type_id FROM type WHERE type_name = '{0}' ", value);
                        MySqlCommand cmd3 = conn.CreateCommand();
                        cmd3.CommandText = tempSql3;
                        MySqlDataReader reader3 = cmd3.ExecuteReader();
                        int newTypeId = 0;
                        while (reader3.Read())
                            newTypeId = reader3.GetInt32(reader3.GetOrdinal("type_id"));
                        booksView[ecolumn - 1, erow].Value = newTypeId;
                        reader3.Close();


                        int theBookId = Convert.ToInt32(booksView[0, erow].Value.ToString());
                        string tempSql0 = "SELECT book_id,type_id FROM book_type ";
                        if (compareInBT(tempSql0, theBookId, newTypeId) == 0)
                        {
                            string sqlStr = string.Format("DELETE FROM book_type WHERE book_id = '{0}' ", theBookId);
                            MySqlCommand cmd0 = new MySqlCommand(sqlStr, conn);
                            if (cmd0.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("There is something wrong with inserting!");
                            }

                            string tempSql = string.Format("INSERT INTO book_type(book_id,type_id) values('{0}','{1}') ", theBookId, newTypeId);
                            MySqlCommand tempCmd = new MySqlCommand(tempSql, conn);
                            if (tempCmd.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("There is something wrong with inserting!");
                            }
                        }
                        else
                        {
                            changedItem[ecolumn - 1, erow] = newTypeId.ToString();
                        }
                        conn.Close();
                        break;
                    }
                    else
                    {
                        conn.Open();
                        MessageBox.Show("The cell can't be empty!");
                        int typeId = Convert.ToInt32(booksView[ecolumn - 1, erow].Value.ToString());
                        string sql12 = string.Format("SELECT type_name FROM type WHERE type_id = '{0}' ",typeId);
                        MySqlCommand cmd12 = conn.CreateCommand();
                        cmd12.CommandText = sql12;
                        MySqlDataReader reader12 = cmd12.ExecuteReader();
                        string oldType = "";
                        while (reader12.Read())
                            oldType = reader12.GetString("type_name");
                        reader12.Close();
                        conn.Close();
                        booksView[ecolumn, erow].Value = oldType;
                        break;
                    }
                case 5:
                    if (value != "")
                    {
                        conn.Open();

                        string tempSql4 = "SELECT publisher_name FROM publisher ";
                        string tempSql5 = string.Format("INSERT INTO publisher(publisher_name) values('{0}') ", value);

                        if (compareInDb(tempSql4, value, "publisher_name") == 0)
                        {
                            MySqlCommand tempCmd = new MySqlCommand(tempSql5, conn);
                            if (tempCmd.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("There is something wrong with inserting!");
                            }
                        }
                        string tempSql6 = string.Format("SELECT publisher_id FROM publisher WHERE publisher_name = '{0}' ", value);
                        MySqlCommand cmd6 = conn.CreateCommand();
                        cmd6.CommandText = tempSql6;
                        MySqlDataReader reader6 = cmd6.ExecuteReader();
                        int newPublisherId = 0;
                        while (reader6.Read())
                            newPublisherId = reader6.GetInt32(reader6.GetOrdinal("publisher_id"));
                        booksView[ecolumn - 1, erow].Value = newPublisherId;
                        changedItem[ecolumn - 1, erow] = newPublisherId.ToString();
                        reader6.Close();
                        conn.Close();
                        break;
                    }
                    else
                    {
                        conn.Open();
                        MessageBox.Show("The cell can't be empty!");
                        int publisherId = Convert.ToInt32(booksView[ecolumn - 1, erow].Value.ToString());
                        string sql13 = string.Format("SELECT publisher_name FROM publisher WHERE publisher_id = '{0}' ", publisherId);
                        MySqlCommand cmd13 = conn.CreateCommand();
                        cmd13.CommandText = sql13;
                        MySqlDataReader reader13 = cmd13.ExecuteReader();
                        string oldPublisher = "";
                        while (reader13.Read())
                            oldPublisher = reader13.GetString("publisher_name");
                        reader13.Close();
                        conn.Close();
                        booksView[ecolumn, erow].Value = oldPublisher;
                        break;
                    }
                case 6:
                    int status = Convert.ToInt32(value);
                    if (status == 0 || status == 1)
                    {
                        changedItem[ecolumn, erow] = value;
                    }
                    else
                    {
                        conn.Open();
                        MessageBox.Show("The status must be 0 or 1");
                        int bookId14 = Convert.ToInt32(booksView[0, erow].Value.ToString());
                        string tempSql7 = string.Format("SELECT book_status FROM book WHERE book_id = '{0}' ", bookId14);
                        MySqlCommand cmd7 = conn.CreateCommand();
                        cmd7.CommandText = tempSql7;
                        MySqlDataReader reader7 = cmd7.ExecuteReader();
                        int oldStatus = 0;
                        while (reader7.Read())
                            oldStatus = reader7.GetInt32(reader7.GetOrdinal("book_status"));
                        booksView[ecolumn, erow].Value = oldStatus;
                        reader7.Close();
                        conn.Close();
                    }
                    break;
            }
            
        }

    private void booksView_KeyPress(object sender, KeyPressEventArgs e)
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
```

#2.2 Other button
At last, if manager clicks the modify chapter button or add book button, when manager select the cell of book, it will turn to the modify-chapter form or add-book form. And clicking the get report button will get the report abut all books. 

#3.1 Moodify Chapter
If manager want to modify the content of the specificed chapter, he should select the chapter_no in the first comboBox. And if he click show content button, the content will be show in the textBox. And then the manager can modify the content. Aftering modifying, clicking the modify button, it will be updated in the txt file on the server. But the content must be changed. And at the same time, manager can add author to corresponding book by selecting the user_name in the second comboBox and clicking the modify button.
###So our code should be like
```C#  

    private void showButton_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            Stream FirstPage = wc.OpenRead(bookUrl);
            StreamReader sr = new StreamReader(FirstPage, Encoding.UTF8);
            String content = sr.ReadToEnd();
            content = content.Replace("\n", "\r\n");
            chapterContent.Text = content;
            initCon = chapterContent.Text.ToString();

            FirstPage.Close();
            sr.Close();
            wc.Dispose();
        }

    private void modifyButton_Click(object sender, EventArgs e)
        {
            string content = chapterContent.Text.ToString();
            string author = authorBox.Text.ToString();

            if (content == initCon && author == "")
            {
                MessageBox.Show("Please change the content and the click the button!");
            }
            else if(content != initCon && author == "")
            {
                DatabaseUtility.modifyBookContent(book, chapterNo, content);
                DatabaseUtility.updateModifyDateByBookId(bookId);
                theView[8, row].Value = System.DateTime.Now;
            }
            else if(content == initCon && author != "")
            {
                if(DatabaseUtility.modifyAuthorByName(author, bookId) == 0)
                {
                    MessageBox.Show("There already exists the author!");
                }
                else
                {
                    DatabaseUtility.updateModifyDateByBookId(bookId);
                    theView[8, row].Value = System.DateTime.Now;
                }
            }
            else
            {
                DatabaseUtility.modifyBookContent(book, chapterNo, content);
                if (DatabaseUtility.modifyAuthorByName(author, bookId) == 0)
                {
                    MessageBox.Show("There already exists the author!");
                }
                DatabaseUtility.updateModifyDateByBookId(bookId);
                theView[8, row].Value = System.DateTime.Now;
            }
            chapterBox.Text = "";
            authorBox.Text = "";
            chapterContent.Text = "";
            initCon = chapterContent.Text.ToString();
        }
```

#3.2 Add Chapter
The label near chapter will show the chapter you will add. Change the content of the textBox and click add button. Correspongding things will be updated like chapter_no in databse and txt file on server. But the content must be changed, too. After clicking add button, you can see the changes in the first comboBox.

###So our code should be like
```C#  

     private void addButton_Click(object sender, EventArgs e)
        {
            string newContent = newBookContent.Text.ToString();
            int newChapNo = book.Chapter_no + 1;
            int temp = newChapNo + 1;
            if (newChapNo > book.Chapter_no) {
                DatabaseUtility.updateChapterNoByBookId(newChapNo,bookId);
                DatabaseUtility.modifyBookContent(book, newChapNo, newContent);
                DatabaseUtility.updateModifyDateByBookId(bookId);
                theView[8, row].Value = System.DateTime.Now;
            }
            else
            {
                MessageBox.Show("Please enter the book content!");
            }
            refresh();
            newBookContent.Text = "";
            newChapterNoLabel.Text = string.Format("New Chapter : {0}", temp.ToString());
        }
```