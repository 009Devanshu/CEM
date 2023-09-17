using iText.Kernel.Pdf;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using iText.Forms.Fields;
using iText.Forms;
using iText.Layout;
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
using System.Xml.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using System.Linq.Expressions;
using DevExpress.XtraEditors;

using System.Globalization;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Utilities;
using System.Configuration;


namespace CEM
{
    public partial class ucDetails : DevExpress.XtraEditors.XtraUserControl
    {
        string path = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;    
       
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;
        private static ucDetails _instance;

        public static ucDetails Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucDetails();
                return _instance;
            }
        }
        
        public ucDetails()
        {
            InitializeComponent();
            conn = new SqlConnection(path);
            AllDisplay();
        }
        public void AllDisplay()
        {
            try
            {

                dt = new System.Data.DataTable();
                conn.Open();
                adpt = new SqlDataAdapter("exec loadcompany", conn);
                adpt.Fill(dt);
                gridControl1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ucDetails_Load(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
