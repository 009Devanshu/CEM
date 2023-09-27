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
    public partial class CompanyRegistration : DevExpress.XtraEditors.XtraForm
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
        public CompanyRegistration()
        {
            InitializeComponent();
            conn = new SqlConnection(path
               );
           
        }

       
        private void CompanyRegistration_Load(object sender, EventArgs e)
        {
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == "" || txtGST.Text == "" || txtPan.Text == "" || txtCompanyAddress.Text == "" || txtLUT.Text == "" || txtCIN.Text == ""
               || txtBankName.Text == "" || txtAccountNumber.Text == "" || txtAccountName.Text == "" || txtIFSC.Text == "" || txtSwift.Text == "" || txtBankAddress.Text == "")
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
                using (SqlConnection connection = new SqlConnection(path))
                {
                    connection.Open();
                    string query = "exec InsertCompanyAndAccount  @CompanyName, @GST, @PAN,@CompanyAddress, @LUT,@CIN, @BankName, @AccountNumber,@AccountName, @IFSCCode, @SwiftCode,@BankAddress";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
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

                         

                        }
                        else
                        {
                            MessageBox.Show("Data Insertion Failed");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}