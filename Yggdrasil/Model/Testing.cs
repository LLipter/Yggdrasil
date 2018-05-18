using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yggdrasil.Model
{
    class Testing
    {

        public static void printUser(User user)
        {
            Console.WriteLine("User information");
            Console.WriteLine("user_id       " + user.User_id);
            Console.WriteLine("user_name     " + user.User_name);
            Console.WriteLine("passwd        " + user.Passwd);
            Console.WriteLine("nick_name     " + user.Nick_name);
            Console.WriteLine("privilege     " + user.Privilege);
            Console.WriteLine("register_date " + user.Register_date);
            Console.WriteLine("user_id       " + user.User_id);
        }

        public static void printBook(Book book)
        {
            Console.WriteLine("Book information");
            Console.WriteLine("book_id       " + book.Book_id);
            Console.WriteLine("book_name     " + book.Book_name);
            Console.WriteLine("location      " + book.Location);
            Console.WriteLine("book_status   " + book.Book_status);
            Console.WriteLine("publisher_id  " + book.Publisher_id);
            Console.WriteLine("chapter_no    " + book.Chapter_no);
            Console.WriteLine("create_date   " + book.Create_date);
            Console.WriteLine("modify_date   " + book.Modify_date);
        }
    }
}
