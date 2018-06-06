using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Yggdrasil.Model;

namespace Yggdrasil
{
    public partial class Manage : Form
    {
        private static string connDatabase = "yggdrasil";
        private static string connHost = "www.irran.top";
        private static string connUser = "yggdrasil";
        private static string connPassword = "admin";
        private static string connStr = string.Format("Database={0};Data Source={1};User Id={2};Password={3};Charset=utf8", connDatabase, connHost, connUser, connPassword);
        private static string sqlStr = "SELECT b.book_id,b.book_name,a.user_id,u.user_name,b.publisher_id,p.publisher_name,b.book_status,b.create_date,b.modify_date " +
                                        "FROM book b " +
                                        "LEFT JOIN author a " +
                                        "ON a.book_id = b.book_id " +
                                        "LEFT JOIN user u " +
                                        "ON u.user_id = a.user_id " +
                                        "LEFT JOIN publisher p " +
                                        "ON b.publisher_id = p.publisher_id ";
        private string[,] changedItem;
        private ArrayList bookList = new ArrayList();

        MySqlConnection conn;
        MySqlDataAdapter adapter;

        public Manage()
        {
            InitializeComponent();
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();

            sda.Fill(ds);
            booksView.DataSource = ds.Tables[0];
            booksView.RowHeadersVisible = false;
            booksView.Columns[0].ReadOnly = true;
            booksView.Columns[2].ReadOnly = true;
            booksView.Columns[4].ReadOnly = true;
            booksView.Columns[7].ReadOnly = true;
            booksView.Columns[8].ReadOnly = true;

            int column = booksView.ColumnCount;
            int row = booksView.RowCount;
            changedItem = new string[column -1,row -1];
        }

        private void dbUpdate()
        {
            conn.Open();
            MySqlCommand cmd;
            int column = booksView.ColumnCount;
            int row = booksView.RowCount;
            int bookId;
            int otherId;
            for(int i = 0; i < column; i++)
            {
                for(int j = 0; j< row; j++)
                {
                    if(changedItem[i,j] != null)
                    {
                        switch (j)
                        {
                            case 1:
                                bookId = Convert.ToInt32(booksView[i, j].Value.ToString());
                                string sqlStr1 = string.Format("UPDATE book" +
                                                               "SET book_name = {0} " +
                                                               "WHERE book_id = {1} ", changedItem[i, j], bookId);
                                cmd = new MySqlCommand(sqlStr1, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("Update success!");
                                }
                                break;
                            case 2:
                                bookId = Convert.ToInt32(booksView[i, j].Value.ToString());
                                otherId = Convert.ToInt32(changedItem[i, j]);
                                string sqlStr2 = string.Format("UPDATE author" +
                                                               "SET user_id = {0} " +
                                                               "WHERE book_id = {1} ", otherId, bookId);
                                cmd = new MySqlCommand(sqlStr2, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("Update success!");
                                }
                                break;
                            case 4:
                                bookId = Convert.ToInt32(booksView[i, j].Value.ToString());
                                otherId = Convert.ToInt32(changedItem[i, j]);
                                string sqlStr4 = string.Format("UPDATE publisher_id" +
                                                               "SET publisher_id = {0} " +
                                                               "WHERE book_id = {1} ", otherId, bookId);
                                cmd = new MySqlCommand(sqlStr4, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("Update success!");
                                }
                                break;
                            case 6:
                                bookId = Convert.ToInt32(booksView[i, j].Value.ToString());
                                int status = Convert.ToInt32(changedItem[i, j]);
                                    string sqlStr6 = string.Format("UPDATE book_status" +
                                                                   "SET bookStatus = {0} " +
                                                                   "WHERE book_id = {1} ", status, bookId);
                                    cmd = new MySqlCommand(sqlStr6, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("Update success!");
                                }
                                break;
                        }
                    }
                }
            }
            conn.Close();
        }

        private void booksView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            byte[] utf8 = Encoding.UTF8.GetBytes(booksView[column, row].Value.ToString());
            string value = Encoding.UTF8.GetString(utf8);
            switch (column)
            {
                case 3:
                    conn.Open();

                    string tempSql1 = "SELECT user_name FROM user ";

                    DataTable tempDt = getTable(tempSql1);

                    string tempSql2 = string.Format("INSERT INTO user(user_name) values({0}) ", value);

                    if (compareInDb(tempDt, value) == 0)
                    {
                        MessageBox.Show("There is no such value!");
                        MySqlCommand tempCmd = new MySqlCommand(tempSql2, conn);
                        if (tempCmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("The insert is successful!");
                            string tempSql3 = string.Format("SELECT user_id FROM user WHERE user_name = {0} ", value);
                            DataTable tempDt3 = getTable(tempSql3);
                            string newUserId = tempDt3.Rows[1].ToString();
                            booksView[column - 1, row].Value = newUserId;
                            changedItem[column - 1, row] = newUserId; 
                        }
                    }
                    else
                    {
                        string tempSql3 = string.Format("SELECT user_id FROM user WHERE user_name = {0} ", value);
                        DataTable tempDt3 = getTable(tempSql3);
                        string newUserId = tempDt3.Rows[1].ToString();
                        booksView[column - 1, row].Value = newUserId;
                        changedItem[column - 1, row] = newUserId;
                    }
                    conn.Close();
                    break;
                case 5:
                    conn.Open();

                    string tempSql4 = "SELECT publisher_name FROM publisher ";

                    DataTable tempDt4 = getTable(tempSql4);

                    string tempSql5 = string.Format("INSERT INTO publisher(publisher_name) values({0}) ", value);

                    if (compareInDb(tempDt4, value) == 0)
                    {
                        MessageBox.Show("There is no such value!");
                        MySqlCommand tempCmd = new MySqlCommand(tempSql5, conn);
                        if (tempCmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("The insert is successful!");
                            string tempSql6 = string.Format("SELECT publisher_id FROM publisher WHERE publisher_name = {0} ", value);
                            DataTable tempDt6 = getTable(tempSql6);
                            string newPublisherId = tempDt6.Rows[1].ToString();
                            booksView[column - 1, row].Value = newPublisherId;
                            changedItem[column - 1, row] = newPublisherId;
                        }
                    }
                    else
                    {
                        string tempSql6 = string.Format("SELECT publisher_id FROM publisher WHERE publisher_name = {0} ", value);
                        DataTable tempDt6 = getTable(tempSql6);
                        string newPublisherId = tempDt6.Rows[1].ToString();
                        booksView[column - 1, row].Value = newPublisherId;
                        changedItem[column - 1, row] = newPublisherId;
                    }
                    conn.Close();
                    break;
                case 6:
                    int status = Convert.ToInt32(value);
                    if(status == 0 || status == 1)
                    {
                        changedItem[column, row] = value;
                    }
                    else
                    {
                        MessageBox.Show("This cell is only can be 0 or 1!");
                        int bookId = Convert.ToInt32(booksView[0, row].Value.ToString());
                        string tempSql7 = string.Format("SELECT book_status FROM publisher WHERE publisher_name = {0} ", bookId);
                        DataTable tempDt7 = getTable(tempSql7);
                        string oldStatus = tempDt7.Rows[1].ToString();
                        booksView[column, row].Value = oldStatus;
                    }
                    break;
                default:
                    changedItem[column, row] = value;
                    break;
            }
        }

        private int compareInDb(DataTable dt, string value)
        {
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string dtValue = dt.Rows[i].ToString();
                if (value == dtValue)
                {
                    count++;
                }
            }
            return count;
        }

        private DataTable getTable(string sqlStr)
        {
            MySqlDataAdapter tempSda = new MySqlDataAdapter(sqlStr, conn);
            DataSet tempDs = new DataSet();
            tempSda.Fill(tempDs);
            DataTable tempDt = new DataTable();
            tempDt = tempDs.Tables[0];
            return tempDt;
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            dbUpdate();
        }

        private void addChapterButton_Click(object sender, EventArgs e)
        {
            if (bookList[0] == null)
            {
                MessageBox.Show("Please click the cell!");
            }
            else
            {
                int bookId = (int)bookList[0];
                Modify_Chapter chapter = new Modify_Chapter(bookId);
            }
        }

        private void booksView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bookList.Clear();
            bookList.Add(Convert.ToInt32(booksView[0,e.RowIndex].Value));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
