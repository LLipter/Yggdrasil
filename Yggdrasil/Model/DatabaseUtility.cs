using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Yggdrasil.Model
{
    class DatabaseUtility
    {

        private static string connDatabase = "yggdrasil";
        private static string connHost = "www.irran.top";
        private static string connUser = "yggdrasil";
        private static string connPassword = "admin";
        private static string connStr = string.Format("Database={0};Data Source={1};User Id={2};Password={3};Charset=utf8", connDatabase, connHost, connUser, connPassword);



        private static MySqlConnection openConn()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (MySqlException exp)
            {
                // cannot access the database, which means a possible failure in network connection
                Console.WriteLine(exp.Message);
                return null;
            }
            return conn;
        }

        public static int getUser(ref User user, String userName)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("SELECT * FROM user WHERE user_name='{0}'", userName);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            if (!read.Read())
                user = User.noSuchUser;    // no such user
            else
            {
                user.User_id = read.GetInt32("user_id");
                user.User_name = read.GetString("user_name");
                user.Passwd = read.GetString("passwd");
                if (!read.IsDBNull(3))
                    user.Nick_name = read.GetString("nick_name");
                else
                    user.Nick_name = null;
                user.Privilege = read.GetInt32("privilege");
                user.Register_date = read.GetDateTime("register_date");

            }
            read.Close();
            return 1;   // 1 means everything is right
        }
        public static int register(ref User user)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("INSERT INTO user(user_name,passwd,nick_name) VALUES('{0}','{1}','{2}');", user.User_name, user.Passwd, user.Nick_name);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            if (cmd.ExecuteNonQuery() == 1) { };
            return 1;
        }

        public static int getBookByName(ref ArrayList books, String bookName)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("SELECT * FROM book WHERE book_name like '%{0}%'", bookName);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            MySqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                Book book = new Book();
                book.Book_id = read.GetInt32("book_id");
                book.Book_name = read.GetString("book_name");
                if (!read.IsDBNull(2))
                    book.Location = read.GetString("location");
                else
                    book.Location = null;
                book.Book_status = read.GetInt32("book_status");
                if (!read.IsDBNull(4))
                    book.Publisher_id = read.GetInt32("publisher_id");
                else
                    book.Publisher_id = -1; // -1 indicates its publisher_id is null
                book.Chapter_no = read.GetInt32("chapter_no");
                book.Create_date = read.GetDateTime("create_date");
                book.Modify_date = read.GetDateTime("modify_date");
                books.Add(book);
            }
            read.Close();
            return 1;   // 1 means everything is right
        }


        public static int getBookByID(ref Book book, int book_id)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("SELECT * FROM book WHERE book_id = '{0}'", book_id);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            MySqlDataReader read = cmd.ExecuteReader();

            if (!read.Read())
                book = Book.noSuchBook;    // no such book
            else
            {
                book.Book_id = read.GetInt32("book_id");
                book.Book_name = read.GetString("book_name");
                if (!read.IsDBNull(2))
                    book.Location = read.GetString("location");
                else
                    book.Location = null;
                book.Book_status = read.GetInt32("book_status");
                if (!read.IsDBNull(4))
                    book.Publisher_id = read.GetInt32("publisher_id");
                else
                    book.Publisher_id = -1; // -1 indicates its publisher_id is null
                book.Chapter_no = read.GetInt32("chapter_no");
                book.Create_date = read.GetDateTime("create_date");
                book.Modify_date = read.GetDateTime("modify_date");
            }
            read.Close();
            return 1;   // 1 means everything is right
        }

        public static int getBooks(ref ArrayList books, int number)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("SELECT * FROM book LIMIT {0}", number);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            MySqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                Book book = new Book();
                book.Book_id = read.GetInt32("book_id");
                book.Book_name = read.GetString("book_name");
                if (!read.IsDBNull(2))
                    book.Location = read.GetString("location");
                else
                    book.Location = null;
                book.Book_status = read.GetInt32("book_status");
                if (!read.IsDBNull(4))
                    book.Publisher_id = read.GetInt32("publisher_id");
                else
                    book.Publisher_id = -1; // -1 indicates its publisher_id is null
                book.Chapter_no = read.GetInt32("chapter_no");
                book.Create_date = read.GetDateTime("create_date");
                book.Modify_date = read.GetDateTime("modify_date");
                books.Add(book);
            }
            read.Close();
            return 1;   // 1 means everything is right
        }
    }


}