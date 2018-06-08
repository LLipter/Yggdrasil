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
        private Form manageForm;
        private ArrayList books = null;

        public frmBookReport()
        {
            InitializeComponent();

        }

        public frmBookReport(Form theForm)
        {
            InitializeComponent();
            manageForm = theForm;
        }

        public frmBookReport(ArrayList books)
        {
            InitializeComponent();
            this.books = books;

        }

        private void frmBookReport_Load(object sender, EventArgs e)
        {
            ArrayList books = null;
            if (this.books != null)
                books = this.books;
            else
                DatabaseUtility.getBookByName(ref books, "_");

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
                if (book.Publisher != null)
                    r[4] = book.Publisher.Publisher_name;
                else
                    r[4] = null;
                r[5] = book.Chapter_no;
                r[6] = book.Create_date;
                r[7] = book.Modify_date;
                r[8] = book.getInfo();
                r[9] = book.getCoverInByte();
                ds.Tables["book"].Rows.Add(r);
            }

            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
        }

        private void frmBookReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(manageForm != null)
                manageForm.Enabled = true;
        }
    }
}
