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
            conn.Close();
            return 1;   // 1 means everything is right
        }
        public static int register(ref User user)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("INSERT INTO user(user_name,passwd,nick_name) VALUES('{0}','{1}','{2}');", user.User_name, user.Passwd, user.Nick_name);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            if (cmd.ExecuteNonQuery() == 0)
            {
                conn.Close();
                return -2; // duplicate user name
            }
            conn.Close();
            return 1;// 1 means everything is right
        }

        public static int getBookByName(ref ArrayList books, String bookName)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("SELECT * FROM book WHERE book_name like '%{0}%' WHERE book_status = 1", bookName);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            books = new ArrayList();
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
                {
                    int publisher_id = read.GetInt32("publisher_id");
                    Publisher publisher = null;
                    DatabaseUtility.getPublisherByID(ref publisher, publisher_id);
                    book.Publisher = publisher;
                }
                else
                    book.Publisher = null; // publisher_id is null
                book.Chapter_no = read.GetInt32("chapter_no");
                book.Create_date = read.GetDateTime("create_date");
                book.Modify_date = read.GetDateTime("modify_date");
                books.Add(book);
            }
            read.Close();
            conn.Close();
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
                {
                    int publisher_id = read.GetInt32("publisher_id");
                    Publisher publisher = null;
                    DatabaseUtility.getPublisherByID(ref publisher, publisher_id);
                    book.Publisher = publisher;
                }
                else
                    book.Publisher = null; // publisher_id is null
                book.Chapter_no = read.GetInt32("chapter_no");
                book.Create_date = read.GetDateTime("create_date");
                book.Modify_date = read.GetDateTime("modify_date");
            }
            read.Close();
            conn.Close();
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
                {
                    int publisher_id = read.GetInt32("publisher_id");
                    Publisher publisher = null;
                    DatabaseUtility.getPublisherByID(ref publisher, publisher_id);
                    book.Publisher = publisher;
                } else
                    book.Publisher = null; // publisher_id is null
                book.Chapter_no = read.GetInt32("chapter_no");
                book.Create_date = read.GetDateTime("create_date");
                book.Modify_date = read.GetDateTime("modify_date");
                books.Add(book);
            }
            read.Close();
            conn.Close();
            return 1;   // 1 means everything is right
        }

        public static int getPublisherByID(ref Publisher publisher, int publisher_id)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("SELECT * FROM publisher WHERE publisher_id = '{0}'", publisher_id);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            MySqlDataReader read = cmd.ExecuteReader();

            if (!read.Read())
                publisher = Publisher.noSuchPublisher;    // no such publisher
            else
            {
                publisher.Publisher_id = read.GetInt32("publisher_id");
                if (!read.IsDBNull(1))
                    publisher.Publisher_name = read.GetString("publisher_name");
                else
                    publisher.Publisher_name = null;
            }
            read.Close();
            conn.Close();
            return 1;   // 1 means everything is right
        }

        public static int getTypeByID(ref Type type, int type_id)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("SELECT * FROM type WHERE type_id = '{0}'", type_id);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            MySqlDataReader read = cmd.ExecuteReader();

            if (!read.Read())
                type = Type.noSuchType;    // no such type
            else
            {
                type.Type_id = read.GetInt32("type_id");
                if (!read.IsDBNull(1))
                    type.Ptype_id = read.GetInt32("ptype_id");
                else
                    type.Ptype_id = -1;
                type.Type_name = read.GetString("type_name");
            }
            read.Close();
            conn.Close();
            return 1;   // 1 means everything is right
        }

        public static int getTypes(ref ArrayList types, Book book)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("SELECT * FROM book_type WHERE book_id = {0}", book.Book_id);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            types = new ArrayList();

            while (read.Read())
            {
                int type_id = read.GetInt32("type_id");
                Type type = new Type();
                DatabaseUtility.getTypeByID(ref type, type_id);
                types.Add(type);
            }
            read.Close();
            conn.Close();
            return 1;   // 1 means everything is right
        }

        public static int getComments(ref ArrayList comments, Book book)
        {
            MySqlConnection conn = openConn();
            if (conn == null)
                return -1;  // -1 means cannot connect to database
            string sqlStr = string.Format("SELECT * FROM comment WHERE book_id = {0}", book.Book_id);
            MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            comments = new ArrayList();

            while (read.Read())
            {
                int comment_id = read.GetInt32("comment_id");
                int book_id = read.GetInt32("book_id");
                int user_id = read.GetInt32("user_id");
                string comment = read.GetString("comment");
                Comment the_comment = new Comment();
                the_comment.Comment_id = comment_id;
                the_comment.Book_id = book_id;
                the_comment.User_id = user_id;
                the_comment.Comment = comment;
                comments.Add(the_comment);
            }
            read.Close();
            conn.Close();
            return 1;   // 1 means everything is right
        }
    }


}