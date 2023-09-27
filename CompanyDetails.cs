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
    public partial class Company_Details : DevExpress.XtraEditors.XtraForm
    {

        //Declaring Variables for your company
        public string company_name;
        public string gst;
        public string pan;
        public string company_address;
        public string lut;
        public string cin;

        //Declaring variables for account details
        public string bank_name;
        public string account_number;
        public string account_name;
        public string ifsc;
        public string swift_code;
        public string bank_address;

        //
       

        string path = System.Configuration.ConfigurationManager.
       ConnectionStrings["mydb"].ConnectionString;
        private SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;

        SqlConnection sqlConnection;
        public Company_Details()
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
                adpt = new SqlDataAdapter("exec LoadCompanyWithAccount", conn);
                adpt.Fill(dt);
                dataGridView2.DataSource = dt;
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
                dt = new DataTable();
                conn.Open();
                adpt = new SqlDataAdapter("exec LoadCompanyWithAccount", conn);
                adpt.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Are You sure to delete?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(path))
                    {
                        connection.Open();
                        string query = "exec DeleteCompanyAndAccountsByName @CompanyName";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@CompanyName", company_name);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Deleted Successfully");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Company_Details company_Details = Application.OpenForms["Company_Details"] as Company_Details;
            company_Details.RefreshDataGridView();

            NoBlueColored();
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
        private void Company_Details_Load(object sender, EventArgs e)
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
            dataGridView2.Columns[10].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
            dataGridView2.Columns[11].HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);

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
            dataGridView2.Columns[10].Width = 320;
            dataGridView2.Columns[11].Width = 320;
            NoBlueColored();
           
        }

        private void btnadd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CompanyRegistration companyRegistration = new CompanyRegistration();
            companyRegistration.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnupdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           


            CompanyUpdateForm update_Form = new CompanyUpdateForm();
            update_Form.Show();

           
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                company_name = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                gst = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                pan = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                company_address = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                lut = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                cin = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                bank_name = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                account_number = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                account_name = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                ifsc = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
                swift_code = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
                bank_address = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();

                GridRowColored();
            }
        }

       
    }
}