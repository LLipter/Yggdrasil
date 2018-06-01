using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Yggdrasil.Model;
using System.Net;

namespace Yggdrasil.Model
{
    class Book
    {
        private int book_id;
        private string book_name;
        private string location;
        private int book_status;
        private int publisher_id;
        private int chapter_no;
        private DateTime create_date;
        private DateTime modify_date;

        public int Book_id { get { return book_id; } set { book_id = value; } }
        public string Book_name { get { return book_name; } set { book_name = value; } }
        public string Location { get { return location; } set { location = value; } }
        public int Book_status { get { return book_status; } set { book_status = value; } }
        public int Publisher_id { get { return publisher_id; } set { publisher_id = value; } }
        public int Chapter_no { get { return chapter_no; } set { chapter_no = value; } }
        public DateTime Create_date { get { return create_date; } set { create_date = value; } }
        public DateTime Modify_date { get { return modify_date; } set { modify_date = value; } }

        public static Book noSuchBook = new Book();
        public static Image getCover(Book currentBook)
        {
            return Image.FromStream(WebRequest.Create("[图片]http://www.irran.top:8080/Yggdrasil/book/"+ currentBook.location + "/cover.jpg").GetResponse().GetResponseStream());
        }
    }
}
