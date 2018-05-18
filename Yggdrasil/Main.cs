using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yggdrasil
{
    public partial class Main : Form
    {
        private Form lastForm;
        public Main(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastForm.Close();
        }

    }
}
