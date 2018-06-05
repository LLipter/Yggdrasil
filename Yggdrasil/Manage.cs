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
