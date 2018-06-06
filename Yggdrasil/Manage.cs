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
        private static int column;
        private static int row;

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

            column = booksView.ColumnCount;
            row = booksView.RowCount;
            changedItem = new string[column,row];
        }

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
                                MessageBox.Show("Update success!");
                                break;
                            case 2:
                                bookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                                otherId = Convert.ToInt32(changedItem[j, i]);
                                string sqlStr2 = string.Format("UPDATE author " +
                                                               "SET user_id = '{0}' " +
                                                               "WHERE book_id = '{1}' ", otherId, bookId);
                                cmd = new MySqlCommand(sqlStr2, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("There is something wrong with updating!");
                                    break;
                                }
                                MessageBox.Show("Update success!");
                                break;
                            case 4:
                                bookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                                otherId = Convert.ToInt32(changedItem[j, i]);
                                string sqlStr4 = string.Format("UPDATE publisher_id " +
                                                               "SET publisher_id = '{0}' " +
                                                               "WHERE book_id = '{1}' ", otherId, bookId);
                                cmd = new MySqlCommand(sqlStr4, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("There is something wrong with updating!");
                                    break;
                                }
                                MessageBox.Show("Update success!");
                                break;
                            case 6:
                                bookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                                int status = Convert.ToInt32(changedItem[j, i]);
                                string sqlStr6 = string.Format("UPDATE book_status " +
                                                               "SET bookStatus = '{0}' " +
                                                               "WHERE book_id = '{1}' ", status, bookId);
                                cmd = new MySqlCommand(sqlStr6, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("There is something wrong with updating!");
                                    break;
                                }
                                MessageBox.Show("Update success!");
                                break;
                        }
                    }
                }
            }
            conn.Close();
        }


        private void booksView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int ecolumn = e.ColumnIndex;
            int erow = e.RowIndex;
            byte[] utf8 = Encoding.UTF8.GetBytes(booksView[ecolumn, erow].Value.ToString());
            string value = Encoding.UTF8.GetString(utf8);
            if (value != "")
            {
                switch (ecolumn)
                {
                    case 3:
                        conn.Open();

                        string tempSql1 = "SELECT user_name FROM user ";

                        DataTable tempDt = new DataTable();
                        getTable(ref tempDt, tempSql1);

                        string tempSql2 = string.Format("INSERT INTO user(user_name) values('{0}') ", value);

                        if (compareInDb(tempDt, value) == 0)
                        {
                            MessageBox.Show("There is no such value!");
                            MySqlCommand tempCmd = new MySqlCommand(tempSql2, conn);
                            if (tempCmd.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("There is something wrong with inserting!");
                            }
                            string tempSql3 = string.Format("SELECT user_id FROM user WHERE user_name = '{0}' ", value);
                            DataTable tempDt3 = new DataTable();
                            getTable(ref tempDt3, tempSql3);
                            string newUserId = tempDt3.Rows[1].ToString();
                            booksView[ecolumn - 1, erow].Value = newUserId.ToString();
                            changedItem[ecolumn - 1, erow] = newUserId;

                        }
                        else
                        {
                            string tempSql3 = string.Format("SELECT user_id FROM user WHERE user_name = '{0}' ", value);
                            DataTable tempDt3 = new DataTable();
                            getTable(ref tempDt3, tempSql3);
                            string newUserId = tempDt3.Rows[1].ToString();
                            booksView[ecolumn - 1, erow].Value = newUserId.ToString();
                            changedItem[ecolumn - 1, erow] = newUserId;
                        }
                        conn.Close();
                        break;
                    case 5:
                        conn.Open();

                        string tempSql4 = "SELECT publisher_name FROM publisher ";

                        DataTable tempDt4 = new DataTable();
                        getTable(ref tempDt4, tempSql4);

                        string tempSql5 = string.Format("INSERT INTO publisher(publisher_name) values('{0}') ", value);

                        if (compareInDb(tempDt4, value) == 0)
                        {
                            MessageBox.Show("There is no such value!");
                            MySqlCommand tempCmd = new MySqlCommand(tempSql5, conn);
                            if (tempCmd.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("There is something wrong with inserting!");
                            }
                            conn.Close();
                            conn.Open();
                            string tempSql6 = string.Format("SELECT publisher_id FROM publisher WHERE publisher_name = '{0}' ", value);
                            DataTable tempDt6 = new DataTable();
                            getTable(ref tempDt6, tempSql6);
                            string newPublisherId = tempDt6.Rows[0].ToString();
                            booksView[ecolumn - 1, erow].Value = Convert.ToInt32(newPublisherId);
                            changedItem[ecolumn - 1, erow] = newPublisherId;

                        }
                        else
                        {
                            string tempSql6 = string.Format("SELECT publisher_id FROM publisher WHERE publisher_name = '{0}' ", value);
                            DataTable tempDt6 = new DataTable();
                            getTable(ref tempDt6, tempSql6);
                            string newPublisherId = tempDt6.Rows[1].ToString();
                            booksView[ecolumn - 1, erow].Value = newPublisherId.ToString();
                            changedItem[ecolumn - 1, erow] = newPublisherId;
                        }
                        conn.Close();
                        break;
                    case 6:
                        int status = Convert.ToInt32(value);
                        if (status == 0 || status == 1)
                        {
                            changedItem[ecolumn, erow] = value;
                        }
                        else
                        {
                            MessageBox.Show("This cell is only can be 0 or 1!");
                            int bookId = Convert.ToInt32(booksView[0, erow].Value.ToString());
                            string tempSql7 = string.Format("SELECT book_status FROM publisher WHERE publisher_name = '{0}' ", bookId);
                            DataTable tempDt7 = new DataTable();
                            getTable(ref tempDt7, tempSql7);
                            string oldStatus = tempDt7.Rows[1].ToString();
                            booksView[ecolumn, erow].Value = oldStatus;
                        }
                        break;
                    default:
                        changedItem[ecolumn, erow] = value;
                        break;
                }
            }
        }

        private int compareInDb(DataTable dt, string value)
        {
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte[] utf8 = Encoding.UTF8.GetBytes(dt.Rows[i].ToString());
                string dtValue = Encoding.UTF8.GetString(utf8);
                if (value == dtValue)
                {
                    count++;
                }
            }
            return count;
        }

        private void getTable(ref DataTable tempDt, string sqlStr)
        {
            MySqlDataAdapter tempSda = new MySqlDataAdapter(sqlStr, conn);
            DataSet tempDs = new DataSet();
            tempSda.Fill(tempDs);
            tempDt = tempDs.Tables[0];
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            dbUpdate();
            MessageBox.Show("The modify is successful!");
            for(int i = 0; i < column; i++)
            {
                for(int j = 0; j < row; j++)
                {
                    changedItem[i,j] = null;
                }
            }

        }

        private void modifyChapterButton_Click(object sender, EventArgs e)
        {
            if (bookList[0] == null)
            {
                MessageBox.Show("Please click the cell!");
            }
            else
            {
                int bookId = (int)bookList[0];
                Modify_Chapter chapter = new Modify_Chapter(bookId);
                chapter.Show();
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
