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
        public string client_name;
        public string company_name;
        public string Invoice_Number;
        public string display_block;
        public string preferred_block;
        public string address;
        public string country;
        public string contact;
        public string email;
        public string gst;
        public int invoice_number;

       

        string path = System.Configuration.ConfigurationManager.
        ConnectionStrings["mydb"].ConnectionString;
        private SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;

        SqlConnection sqlConnection;
        public frmMain2()
        {
            InitializeComponent();
            conn = new SqlConnection(path
               );
            //AllDisplay();
        }
       /* public void AllDisplay()
        {
            try
            {

                dt = new System.Data.DataTable();
                conn.Open();
                adpt = new SqlDataAdapter("exec LoadClient", conn);
                adpt.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtClientName.Text==""||txtCompanyName.Text==""||txtDisplay.Text==""||txtPreferred.Text==""||txtAddress.Text==""||txtCountry.Text==""
                ||txtContact.Text==""||txtContact.Text==""||txtEmail.Text==""||txtGST.Text=="")
            {
                MessageBox.Show("Please fill in the  fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            client_name = txtClientName.Text;
            company_name = txtCompanyName.Text;
            display_block = txtDisplay.Text;
            preferred_block = txtPreferred.Text;
            address = txtAddress.Text;
            country = txtCountry.Text;
            contact = txtContact.Text;
            email = txtEmail.Text;
            gst = txtGST.Text;
            try
            {
                conn.Open();
                string query = "exec InsertClient @name,@company,@display_block, @preferred_block, @address, @country, @contact,  @email,  @gst,@invoice_number";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", client_name);
                cmd.Parameters.AddWithValue("@company", company_name);
                cmd.Parameters.AddWithValue("@display_block", display_block);
                cmd.Parameters.AddWithValue("@preferred_block", preferred_block);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@gst", gst);
                cmd.Parameters.AddWithValue("@invoice_number", 1);

                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data Successfully Inserted");
                   
                    //AllDisplay(); // Refresh the DataGridView

                }
                else
                {
                    MessageBox.Show("Data Insertion Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close(); // Make sure to close the connection in the finally block
            }
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       /* private void frmMain2_Load(object sender, EventArgs e)
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
        }*/

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            try
            {
                using (SqlConnection connection = new SqlConnection(path))
                {
                    connection.Open();
                    string client = txtClientName.Text;
                    string company = txtCompanyName.Text;
                    string display = txtDisplay.Text;
                    string preferred = txtPreferred.Text;
                    string address = txtAddress.Text;
                    string country = txtCountry.Text;
                    string contact = txtContact.Text;
                    string email = txtEmail.Text;
                    string gst = txtGST.Text;

                    string query = "exec UpdateClient @name,@display,@preferred,@contact,@email,@gst";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", client);
                        cmd.Parameters.AddWithValue("@display", display);
                        cmd.Parameters.AddWithValue("@preferred", preferred);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@gst", gst);

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Employee data updated successfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClientName.ReadOnly = true;
            txtCompanyName.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtCountry.ReadOnly = true;
            txtGST.ReadOnly = true;

           /* txtClientName.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCompanyName.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDisplay.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPreferred.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAddress.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtCountry.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtContact.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtEmail.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtGST.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();*/
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Are You sure to delete?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(path))
                    {
                        connection.Open();


                        string name = txtClientName.Text;
                        string company = txtCompanyName.Text;

                        // Use a parameterized query to prevent SQL injection
                        string query = "delete from client where name=@name AND company=@company";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {

                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@company",company);

                            cmd.ExecuteNonQuery(); // Execute the stored procedure
                        }

                        MessageBox.Show("Employee data deleted successfully");
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            this.Close();
        }

       /* private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
                client_name=dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                company_name=dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                Invoice_Number= dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                address =dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                country=dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                contact = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                email = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                gst = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }*/

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Generate Invoice")
            {
                Invoice_Form o = new Invoice_Form();
                /*o.StartPosition = FormStartPosition.Manual;
                o.Location = new Point(x, y);*/

                o.Show();

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtClientName.Text == "" || txtCompanyName.Text == "" || txtDisplay.Text == "" || txtPreferred.Text == "" || txtAddress.Text == "" || txtCountry.Text == ""
               || txtContact.Text == "" || txtContact.Text == "" || txtEmail.Text == "" || txtGST.Text == "")
            {
                MessageBox.Show("Please fill in the  fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            client_name = txtClientName.Text;
            company_name = txtCompanyName.Text;
            display_block = txtDisplay.Text;
            preferred_block = txtPreferred.Text;
            address = txtAddress.Text;
            country = txtCountry.Text;
            contact = txtContact.Text;
            email = txtEmail.Text;
            gst = txtGST.Text;
            try
            {
                conn.Open();
                string query = "exec InsertClient @name,@company,@display_block, @preferred_block, @address, @country, @contact,  @email,  @gst, @IsDeleted";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", client_name);
                cmd.Parameters.AddWithValue("@company", company_name);
                cmd.Parameters.AddWithValue("@display_block", display_block);
                cmd.Parameters.AddWithValue("@preferred_block", preferred_block);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@gst", gst);
                cmd.Parameters.AddWithValue("@IsDeleted", 1);


                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (rowsAffected > 0)
                {
                    
                    MessageBox.Show("Data Successfully Inserted");
                    ClientDetails clientForm = Application.OpenForms["ClientDetails"] as ClientDetails;
                    clientForm.RefreshDataGridView();
                    clientForm.NoBlueColored();

                }
                else
                {
                    MessageBox.Show("Data Insertion Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close(); // Make sure to close the connection in the finally block
            }
            this.Close();

            
        }

        private void frmMain2_Load(object sender, EventArgs e)
        {

        }
    }
}