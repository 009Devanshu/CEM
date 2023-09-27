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
    public partial class CompanyUpdateForm : DevExpress.XtraEditors.XtraForm
    {
        string companyName;
        string newGST;
        string newPAN;
        string newAddress;
        string newLUT;
        string newCIN;
        string newBankName;
        string newAccountNumber;
        string newAccountName;
        string newIFSCCode;
        string newSwiftCode;
        string newAccountAddress;

        
        //Declaring datasource fields
      
       
        public CompanyUpdateForm()
        {
            InitializeComponent();
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           

            string path = System.Configuration.ConfigurationManager.
                                          ConnectionStrings["mydb"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(path))
                {
                    connection.Open();
                    string companyName = txtCompanyName.Text;
                    string newGST = txtGST.Text;
                    string newPAN = txtPan.Text;
                    string  newAddress = txtCompanyAddress.Text;
                    string newLUT = txtLUT.Text;
                    string newCIN = txtCIN.Text;
                    string newBankName = txtBankName.Text;
                    string newAccountNumber = txtAccountNumber.Text;
                    string newAccountName = txtAccountName.Text;
                    string newIFSCCode = txtIFSC.Text;
                    string newSwiftCode = txtSwift.Text;
                    string newAccountAddress = txtBankAddress.Text;
                    string query = "exec UpdateCompanyAccount @CompanyName,@NewGST,@NewPAN,@NewAddress,@NewLUT,@NewCIN,@NewBankName,@NewAccountNumber,@NewAccountName,@NewIFSCCode,@NewSwiftCode,@NewAccountAddress";
                    using(SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CompanyName", companyName);
                        cmd.Parameters.AddWithValue("@NewGST", newGST);
                        cmd.Parameters.AddWithValue("@NewPAN", newPAN);
                        cmd.Parameters.AddWithValue("@NewAddress", newAddress);
                        cmd.Parameters.AddWithValue("@NewLUT", newLUT);
                        cmd.Parameters.AddWithValue("@NewCIN", newCIN);
                        cmd.Parameters.AddWithValue("@NewBankName", newBankName);
                        cmd.Parameters.AddWithValue("@NewAccountNumber", newAccountNumber);
                        cmd.Parameters.AddWithValue("@NewAccountName", newAccountName);
                        cmd.Parameters.AddWithValue("@NewIFSCCode", newIFSCCode);
                        cmd.Parameters.AddWithValue("@NewSwiftCode", newSwiftCode);
                        cmd.Parameters.AddWithValue("@NewAccountAddress", newAccountAddress);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            
                            MessageBox.Show("Data Successfully Inserted ");
                            Company_Details company_Details = Application.OpenForms["Company_Details"] as Company_Details;
                            company_Details.RefreshDataGridView();
                            company_Details.NoBlueColored();
                        }
                        else
                        {
                            MessageBox.Show("Data Insertion Failed");
                        }
                    }
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void CompanyUpdateForm_Load(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["Company_Details"];
            txtCompanyName.Text = ((Company_Details)f).company_name;
            txtGST.Text = ((Company_Details)f).gst;
            txtPan.Text = ((Company_Details)f).pan;
            txtCompanyAddress.Text = ((Company_Details)f).company_address;
            txtLUT.Text = ((Company_Details)f).lut;
            txtCIN.Text = ((Company_Details)f).cin;
            txtBankName.Text = ((Company_Details)f).bank_name;
            txtAccountNumber.Text = ((Company_Details)f).account_number;
            txtAccountName.Text = ((Company_Details)f).account_name;
            txtIFSC.Text = ((Company_Details)f).ifsc;
            txtSwift.Text = ((Company_Details)f).swift_code;
            txtBankAddress.Text = ((Company_Details)f).bank_address;

          

            companyName = txtCompanyName.Text;
            newGST = txtGST.Text;
            newPAN = txtPan.Text;
            newAddress = txtCompanyAddress.Text;
            newLUT = txtLUT.Text;
            newCIN = txtCIN.Text;
            newBankName = txtBankName.Text;
            newAccountNumber = txtAccountNumber.Text;
            newAccountName = txtAccountName.Text;
            newIFSCCode = txtIFSC.Text;
            newSwiftCode = txtSwift.Text;
            newAccountAddress = txtBankAddress.Text;

            txtCompanyName.Select(0, 0);
            txtGST.Select(0, 0);
            txtPan.Select(0, 0);
            txtCompanyAddress.Select(0, 0);
            txtLUT.Select(0, 0);
            txtCIN.Select(0, 0);
            txtBankName.Select(0, 0);
            txtAccountNumber.Select(0, 0);
            txtAccountName.Select(0, 0);
            txtIFSC.Select(0, 0);
            txtSwift.Select(0, 0);
            txtBankAddress.Select(0, 0);
        }
    }
}