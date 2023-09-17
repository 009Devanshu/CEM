using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
//using System.Collections.Specialized;

namespace CEM
{
    public partial class frmMain2 : DevExpress.XtraEditors.XtraForm
    {

        string path = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;     

        SqlConnection sqlConnection;
        public frmMain2()
        {
            InitializeComponent();
          
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}