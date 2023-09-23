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
    public partial class ucRegister : DevExpress.XtraEditors.XtraUserControl
    {
        //Declaring Variables for your company
        string company_name;
        string gst;
        string pan;
        string company_address;
        string lut;
        string cin;

        //Declaring variables for account details
        string bank_name;
        string account_number;
        string account_name;
        string ifsc;
        string swift_code;
        string bank_address;
       

        //Declaring datasource fields
        string path = System.Configuration.ConfigurationManager.
                                            ConnectionStrings["mydb"].ConnectionString;
        private SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;

        SqlConnection sqlConnection;
        private static ucRegister _instance;

        public static ucRegister Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucRegister();
                return _instance;
            }
        }
        public ucRegister()
        {
            InitializeComponent();
            conn = new SqlConnection(path
               );
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
        private void ucRegister_Load(object sender, EventArgs e)
        {




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

            //Changing style of Grid Column Header
            dataGridView2.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[4].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[5].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[6].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[7].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[8].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[9].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[10].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            dataGridView2.Columns[11].HeaderCell.Style.Font = new Font("Tahoma", 8F, FontStyle.Bold);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
           
            if(txtCompanyName.Text=="" || txtGST.Text=="" || txtPan.Text==""|| txtCompanyAddress.Text==""||txtLUT.Text==""||txtCIN.Text==""
                ||txtBankName.Text==""||txtAccountNumber.Text==""||txtAccountName.Text==""||txtIFSC.Text==""||txtSwift.Text==""||txtBankAddress.Text=="")
            {
                MessageBox.Show("Please fill in the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop registration process

            }
            company_name = txtCompanyName.Text;
            gst = txtGST.Text;
            pan = txtPan.Text;
            company_address = txtCompanyAddress.Text;
            lut = txtLUT.Text;
            cin = txtCIN.Text;
            bank_name = txtBankName.Text;
            account_number = txtAccountNumber.Text;
            account_name = txtAccountName.Text;
            ifsc = txtIFSC.Text;
            swift_code = txtSwift.Text;
            bank_address = txtBankAddress.Text;

            try
            {
                using(SqlConnection connection = new SqlConnection(path))
                {
                    connection.Open();
                    string query = "exec InsertCompanyAndAccount  @CompanyName, @GST, @PAN,@CompanyAddress, @LUT,@CIN, @BankName, @AccountNumber,@AccountName, @IFSCCode, @SwiftCode,@BankAddress";
                    using(SqlCommand cmd = new SqlCommand(query,connection))
                    {
                        cmd.Parameters.AddWithValue("@CompanyName", company_name);
                        cmd.Parameters.AddWithValue("@GST", gst);
                        cmd.Parameters.AddWithValue("@PAN", pan);
                        cmd.Parameters.AddWithValue("@CompanyAddress", company_address);
                        cmd.Parameters.AddWithValue("@LUT", lut);
                        cmd.Parameters.AddWithValue("@CIN", cin);
                        cmd.Parameters.AddWithValue("@BankName", bank_name);
                        cmd.Parameters.AddWithValue("@AccountNumber", account_number);
                        cmd.Parameters.AddWithValue("@AccountName", account_name);
                        cmd.Parameters.AddWithValue("@IFSCCode", ifsc);
                        cmd.Parameters.AddWithValue("@SwiftCode", swift_code);
                        cmd.Parameters.AddWithValue("@BankAddress", bank_address);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Successfully Inserted");

                            AllDisplay(); // Refresh the DataGridView

                        }
                        else
                        {
                            MessageBox.Show("Data Insertion Failed");
                        }
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBankAddress_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           /* if (MessageBox.Show("Are You sure to delete?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(path))
                    {
                        connection.Open();


                        string name = txtCompanyName.Text;
                        string company = txtGST.Text;

                        // Use a parameterized query to prevent SQL injection
                        string query = "DeleteEmployeeAndDetailsByCodeAndName @";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {

                            *//*cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@company", company);*//*

                            cmd.ExecuteNonQuery(); // Execute the stored procedure
                        }

                        MessageBox.Show("Employee data deleted successfully");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }*/
           
        }

        private void rightMouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Determine the row that was right-clicked
                int rowIndex = dataGridView2.HitTest(e.X, e.Y).RowIndex;

                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                {
                    // Clear any existing selections
                    dataGridView2.ClearSelection();

                    // Select the clicked row
                    dataGridView2.Rows[e.RowIndex].Selected = true;

                    // Get the position for showing the context menu
                    Point mousePos = dataGridView2.PointToClient(Cursor.Position);

                    // Show the context menu at the clicked position
                    contextMenuStrip1.Show(dataGridView2, mousePos);
                }
                //contextMenuStrip1.Show(btnget, 0, btnget.Height);
                
                /*  OtherDetails o = new OtherDetails();
                  o.ShowDialog();*/
            }

        }
    }
}
