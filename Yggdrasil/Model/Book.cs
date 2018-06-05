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
using System.IO;

namespace Yggdrasil.Model
{
   public class Book
    {
        private int book_id;
        private string book_name;
        private string location;
        private int book_status;
        private Publisher publisher;
        private int chapter_no;
        private DateTime create_date;
        private DateTime modify_date;
        private string info = null;
        private Image cover = null;
        private ArrayList types = null;

        public int Book_id { get { return book_id; } set { book_id = value; } }
        public string Book_name { get { return book_name; } set { book_name = value; } }
        public string Location { get { return location; } set { location = value; } }
        public int Book_status { get { return book_status; } set { book_status = value; } }
        public Publisher Publisher { get { return publisher; } set { publisher = value; } }
        public int Chapter_no { get { return chapter_no; } set { chapter_no = value; } }
        public DateTime Create_date { get { return create_date; } set { create_date = value; } }
        public DateTime Modify_date { get { return modify_date; } set { modify_date = value; } }

        public static Book noSuchBook = new Book();

        public Image getCover()
        {
            if (cover != null)
                return cover;
            return cover = Image.FromStream(WebRequest.Create("http://www.irran.top:8080/Yggdrasil/book/"+ this.location + "/cover.jpg").GetResponse().GetResponseStream());
        }

        public string getInfo()
        {
            if (info != null)
                return info;
            WebClient wc = new WebClient();
            Stream binaryInputStream = wc.OpenRead("http://www.irran.top:8080/Yggdrasil/book/" + this.location + "/info.txt");
            StreamReader sr = new StreamReader(binaryInputStream, Encoding.UTF8);
            return info = sr.ReadToEnd();
        }

        public ArrayList getTypes()
        {
            if (types != null)
                return types;
            DatabaseUtility.getTypes(ref types, this);
            return types;
        }

        public Book()
        {

        }




        //将Image转换成流数据，并保存为byte[]   
        public byte[] getCoverInByte()
        {
            if (cover == null)
                getCover();
            MemoryStream mstream = new MemoryStream();
            cover.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length);
            mstream.Close();
            return byData;
        }
    }
}
