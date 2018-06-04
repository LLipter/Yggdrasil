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
using Yggdrasil.Model;

namespace Yggdrasil
{
    public partial class frmBookReport : Form
    {
        public frmBookReport()
        {
            InitializeComponent();

        }

        private void frmBookReport_Load(object sender, EventArgs e)
        {
            ArrayList books = null;
            int res = DatabaseUtility.getBookByName(ref books, "_");

            YggdrasilDataSet ds = new YggdrasilDataSet();
            BookReport cr = new BookReport();
            foreach(Book book in books)
            {
                DataRow r = ds.Tables["book"].NewRow();
                r[0] = book.Book_id;
                r[1] = book.Book_name;
                r[2] = book.Location;
                if (book.Book_status == 1)
                    r[3] = "on shelf";
                else
                    r[3] = "off shelf";
                r[3] = read.GetInt32("book_status");
                if (!read.IsDBNull(4))
                    r[4] = read.GetInt32("publisher_id");
                else
                    r[4] = -1; // -1 indicates its publisher_id is null
                r[5] = read.GetInt32("chapter_no");
                r[6] = read.GetDateTime("create_date");
                r[7] = read.GetDateTime("modify_date");
                ds.Tables["dataTable1"].Rows.Add(r);
            }

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
