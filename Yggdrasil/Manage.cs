using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
        }

        private DataTable dbconn(string strSql)
        {
            conn.Open();
            this.adapter = new MySqlDataAdapter(strSql, conn);
            DataTable dtSelect = new DataTable();
            int rnt = this.adapter.Fill(dtSelect);
            conn.Close();
            return dtSelect;
        }

        private Boolean dbUpdate()
        {
            DataTable dtUpdate = new DataTable();
            dtUpdate = this.dbconn(sqlStr);
            dtUpdate.Rows.Clear();
            DataTable dtShow = new DataTable();
            dtShow = (DataTable)this.booksView.DataSource;

            for (int i = 0; i < dtShow.Rows.Count; i++)
            {
                dtUpdate.ImportRow(dtShow.Rows[i]);
            }
            try
            {
                this.conn.Open();
                MySqlCommandBuilder commandBuilder;
                commandBuilder = new MySqlCommandBuilder(this.adapter);
                this.adapter.Update(dtUpdate);
                this.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            dtUpdate.AcceptChanges();
            return true;
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

                    MySqlDataAdapter tempSda = new MySqlDataAdapter(tempSql1, conn);
                    DataSet tempDs = new DataSet();
                    tempSda.Fill(tempDs);
                    DataTable tempDt = new DataTable();
                    tempDt = tempDs.Tables[0];

                    string tempSql2 = string.Format("INSERT INTO user(user_name) values({0}) ", value);

                    if (compareInDb(tempDt, value) == 0)
                    {
                        MessageBox.Show("There is no such value!");
                        MySqlCommand tempCmd = new MySqlCommand(tempSql2, conn);
                        if (tempCmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("The insert is successful!");
                            string tempSql3 = string.Format("SELECT user_id FROM user WHERE user_name = {0} ", value);
                            MySqlDataAdapter tempSda3 = new MySqlDataAdapter(tempSql3, conn);
                            DataSet tempDs3 = new DataSet();
                            tempSda3.Fill(tempDs3);
                            DataTable tempDt3 = new DataTable();
                            tempDt3 = tempDs3.Tables[0];
                            string newUserId = tempDt3.Rows[1].ToString();
                            booksView[column - 1, row].Value = newUserId; 
                        }
                    }
                    conn.Close();
                    break;
                case 5:
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

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (dbUpdate())
            {
                MessageBox.Show("The change is successful!");
            }
        }

        private void addChapterButton_Click(object sender, EventArgs e)
        {

        }

        private void modifyChapterButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
