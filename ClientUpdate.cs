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
    public partial class Client_Update_Form : DevExpress.XtraEditors.XtraForm
    {
        //Declaring Variables for your company
        string client_name;
        string company_name;
        string display_block;
        string preferred_block;
        string client_address;
        string client_country;

        //Declaring variables for account details
        string contact_number;
        string client_email;
        string client_gst;
       


        //Declaring datasource fields
        string path = System.Configuration.ConfigurationManager.
                                            ConnectionStrings["mydb"].ConnectionString;
        private SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;

        SqlConnection sqlConnection;
        public Client_Update_Form()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(path))
                {
                    connection.Open();
                    string client = txtClientName.Text;
                    string company = txtCompName.Text;
                    string display = txtDisplay.Text;
                    string preferred = textEdit1.Text;
                    string address = txtAddress.Text;
                    string country = textEdit2.Text;
                    string contact = txtContact.Text;
                    string email = txtEmail.Text;
                    string gst = txtGST.Text;

                   

                    string query = "exec UpdateClient @name,@company,@display,@preferred,@address,@country,@contact,@email,@gst";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", client);
                        cmd.Parameters.AddWithValue("@company", company);
                        cmd.Parameters.AddWithValue("@display", display);
                        cmd.Parameters.AddWithValue("@preferred", preferred);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@country", country);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@gst", gst);

                        cmd.ExecuteNonQuery();
                    }
                   
                    MessageBox.Show("Employee data updated successfully");
                    ClientDetails clientForm = Application.OpenForms["ClientDetails"] as ClientDetails;
                    clientForm.RefreshDataGridView();
                    clientForm.NoBlueColored();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void Client_Update_Form_Load(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["ClientDetails"];
            client_name=((ClientDetails)f).client_name;
            company_name=((ClientDetails)f).company_name;
            display_block=((ClientDetails)f).display_block;
            preferred_block=((ClientDetails)f).preferred_block;
            client_address=((ClientDetails)f).client_address;
            client_country=((ClientDetails)f).client_country;
            contact_number=((ClientDetails)f).contact_number;
            client_email=((ClientDetails)f).client_email;
            client_gst=((ClientDetails)f).client_gst;

            txtClientName.Text = client_name;
            txtCompName.Text = company_name;
            txtDisplay.Text = display_block;
            textEdit1.Text = preferred_block;
            txtAddress.Text = client_address;
            textEdit2.Text = client_country;
            txtContact.Text = contact_number;
            txtEmail.Text = client_email;
            txtGST.Text = client_gst;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}