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
    public partial class ClientDetails : DevExpress.XtraEditors.XtraForm
    {
        //Declaring Variables for your company
        public string client_name;
        public string company_name;
       
        public string display_block;
        public string preferred_block;
        public string client_address;
        public string contact_number;

        //Declaring variables for account details
        public string client_country;
        public string client_email;
        public string client_gst;
        


        //Declaring datasource fields
        string path = System.Configuration.ConfigurationManager.
                                            ConnectionStrings["mydb"].ConnectionString;
        private SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;

        
        public ClientDetails()
        {
            InitializeComponent();
            conn = new SqlConnection(path);
            AllDisplay();
        }

        public void RefreshDataGridView()
        {
            try
            {

                dt = new System.Data.DataTable();
                conn.Open();
                adpt = new SqlDataAdapter("exec LoadClient", conn);
                adpt.Fill(dt);
                //dataGridView2.DataSource = dt;
                // Filter the DataTable to only include rows where the IsDeleted column is 1
                DataRow[] filteredRows = dt.Select("IsPresent=1");
                DataTable filteredDataTable = dt.Clone();
                foreach (DataRow row in filteredRows)
                {
                    filteredDataTable.ImportRow(row); // Import the matching rows into the new DataTable
                }
                dataGridView2.DataSource = filteredDataTable;


                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AllDisplay()
        {
            try
            {

                dt = new System.Data.DataTable();
                conn.Open();
                adpt = new SqlDataAdapter("exec LoadClient", conn);
                adpt.Fill(dt);
                //dataGridView2.DataSource = dt;
                // Filter the DataTable to only include rows where the IsDeleted column is 1
                DataRow[] filteredRows = dt.Select("IsPresent=1");
                DataTable filteredDataTable = dt.Clone();
                foreach (DataRow row in filteredRows)
                {
                    filteredDataTable.ImportRow(row); // Import the matching rows into the new DataTable
                }
                dataGridView2.DataSource = filteredDataTable;


                conn.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClientDetails_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView2.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView2.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView2.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView2.Columns[4].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView2.Columns[5].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView2.Columns[6].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView2.Columns[7].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView2.Columns[8].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView2.Columns[9].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);



            dataGridView2.Columns[0].Width = 320;
            dataGridView2.Columns[1].Width = 320;
            dataGridView2.Columns[2].Width = 320;
            dataGridView2.Columns[3].Width = 320;
            dataGridView2.Columns[4].Width = 300;
            dataGridView2.Columns[5].Width = 320;
            dataGridView2.Columns[6].Width = 320;
            dataGridView2.Columns[7].Width = 320;
            dataGridView2.Columns[8].Width = 320;
            dataGridView2.Columns[9].Width = 320;
            AllDisplay();

            NoBlueColored();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain2 frmMain2 = new frmMain2();
            frmMain2.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
               
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Client_Update_Form update_Form = new Client_Update_Form();
            update_Form.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Are You sure to delete?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(path))
                    {
                        connection.Open();


                      

                        // Use a parameterized query to prevent SQL injection
                        string query = "exec DeleteClient @name";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {

                            cmd.Parameters.AddWithValue("@name", client_name);

                            cmd.ExecuteNonQuery(); 
                        }

                        MessageBox.Show("Employee data deleted successfully");
                        ClientDetails clientDetails = Application.OpenForms["ClientDetails"] as ClientDetails;
                        clientDetails.RefreshDataGridView();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
                
            }

            NoBlueColored();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                client_name = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                company_name = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                display_block = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                preferred_block = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                client_address = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                client_country = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                contact_number = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                client_email = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                //client_gst = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();

                GridRowColored();
            }
        }

        public void NoBlueColored()
        {
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black; //This is the text color 
        }
        public void GridRowColored()
        {
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White; //This is the text color 
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Invoice_Form invoice_Form = new Invoice_Form();
            invoice_Form.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Invoice_Form invoice_Form = new Invoice_Form();
            invoice_Form.Show();
        }
    }
}
