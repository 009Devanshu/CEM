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

namespace CEM
{
    public partial class InvoiceDetails : DevExpress.XtraEditors.XtraForm
    {
        string path = System.Configuration.ConfigurationManager.
                            ConnectionStrings["mydb"].ConnectionString;
        private SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;

        public InvoiceDetails()
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
                adpt = new SqlDataAdapter("exec LoadInvoice", conn);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InvoiceDetails_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[4].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[5].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[6].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[7].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[8].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[9].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[10].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[11].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[12].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[13].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[14].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView1.Columns[15].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);

            dataGridView1.Columns[0].Width = 320;
            dataGridView1.Columns[1].Width = 320;
            dataGridView1.Columns[2].Width = 320;
            dataGridView1.Columns[3].Width = 320;
            dataGridView1.Columns[4].Width = 300;
            dataGridView1.Columns[5].Width = 320;
            dataGridView1.Columns[6].Width = 320;
            dataGridView1.Columns[7].Width = 320;
            dataGridView1.Columns[8].Width = 320;
            dataGridView1.Columns[9].Width = 320;
            dataGridView1.Columns[10].Width = 320;
            dataGridView1.Columns[11].Width = 320;
            dataGridView1.Columns[12].Width = 320;
            dataGridView1.Columns[13].Width = 320;
            dataGridView1.Columns[14].Width = 320;
            dataGridView1.Columns[15].Width = 320;
            AllDisplay();
        }
        public void NoBlueColored()
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black; //This is the text color 
        }
        public void GridRowColored()
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White; //This is the text color 
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}