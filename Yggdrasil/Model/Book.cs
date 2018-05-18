using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yggdrasil.Model
{
    class Book
    {
        private int book_id;
        private string book_name;
        private string location;
        private int book_status;
        private int publisher_id;
        private DateTime create_date;
        private DateTime modify_date;

        public int Book_id { get => book_id; set => book_id = value; }
        public string Book_name { get => book_name; set => book_name = value; }
        public string Location { get => location; set => location = value; }
        public int Book_status { get => book_status; set => book_status = value; }
        public int Publisher_id { get => publisher_id; set => publisher_id = value; }
        public DateTime Create_date { get => create_date; set => create_date = value; }
        public DateTime Modify_date { get => modify_date; set => modify_date = value; }

        public Book(int bid,string bn,string locat,int bookstat,int publishid,DateTime cd,DateTime md)
        {
            book_id = bid;
            book_name = bn;
            location = locat;
            book_status = bookstat;
            publisher_id = publishid;
            create_date = cd;
            modify_date = md;
        }
        public Book()
        {

        }

    }
}
