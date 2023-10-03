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
        string client_name;
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
                adpt = new SqlDataAdapter("exec LoadInvoiceReport", conn);
                adpt.Fill(dt);

                // Filter the DataTable to only include rows where the IsDeleted column is 1
                DataRow[] filteredRows = dt.Select("IsPresent=1");
                DataTable filteredDataTable = dt.Clone();
                foreach (DataRow row in filteredRows)
                {
                    filteredDataTable.ImportRow(row); // Import the matching rows into the new DataTable
                }
                dataGridView1.DataSource = filteredDataTable;

               
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RefreshDataGridView()
        {
            try
            {

                dt = new System.Data.DataTable();
                conn.Open();
                adpt = new SqlDataAdapter("exec LoadInvoiceReport", conn);
                adpt.Fill(dt);

                // Filter the DataTable to only include rows where the IsDeleted column is 1
                DataRow[] filteredRows = dt.Select("IsPresent=1");
                DataTable filteredDataTable = dt.Clone();
                foreach (DataRow row in filteredRows)
                {
                    filteredDataTable.ImportRow(row); // Import the matching rows into the new DataTable
                }
                dataGridView1.DataSource = filteredDataTable;


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
            dataGridView1.Columns[16].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);

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
            dataGridView1.Columns[16].Width = 320;
            
            AllDisplay();

            NoBlueColored();
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Invoice_Form invoice_Form = new Invoice_Form();
            invoice_Form.Show();
            RefreshDataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                client_name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int IsDeleted = 0;
            if (MessageBox.Show("Are You sure to delete?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    dataGridView1.Rows.Remove(selectedRow);

                    using(SqlConnection connection = new SqlConnection(path))
                    {
                        connection.Open();
                        string query = "exec DeleteInvoiceRow @client_name,@IsDeleted";
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("client_name", client_name);
                            command.Parameters.AddWithValue("IsDeleted", IsDeleted);
                            command.ExecuteNonQuery();
                            RefreshDataGridView();
                        }
                    }
                }
            }
        }
    }
}