using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Utilities;

namespace CEM
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        double totalctc;
        string name;
        string designation;
        DateTime dateofjoining;
        string empcode;
        string pan;
        string address;
        public double basic;
        public double hra;
        public double ta;
        public double other_allowance;
        public double medical_allowance;
        public double remote_work_allowance;
        public double bonus;
        public double pf;
        public double esic;
        public double loan;
        public double advance;
        public double other;
        public double tds;
        public double monthlysalary;
        public double remainingmonthlysalary;
        public double TotalEarnings;
        public double Deductions;
        public double NetPayable;
        public bool radio;
        public string radio2;

        string month;
        string year;
        int attendance;
        int totaldaysinmonth;

        public int MaxTDSAttendance;

        string path = System.Configuration.ConfigurationManager.
    ConnectionStrings["mydb"].ConnectionString;
        private SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;

        public MainForm()
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
                adpt = new SqlDataAdapter("exec LoadAllEmp", conn);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            AllDisplay();
            txtta.Text = "0";
            txtotherallowance.Text = "0";
            txtremoteworkallowance.Text = "0";
            txtbonus.Text = "0";
            txtpf.Text = "0";
            txtesic.Text = "0";
            txtloan.Text = "0";
            txtadvance.Text = "0";
            txtother.Text = "0";
            txttds.Text = "0";

            //Accessing MaxAttendace from OtherDetails Form
            /*Form f = Application.OpenForms["OtherDetails"];
            MaxTDSAttendance = ((OtherDetails)f).MaxMonthlyAttendance;
            comboattended.Text = MaxTDSAttendance.ToString();*/

            rbtnno.Checked = true;
        }
        private bool IsDuplicateEmpCode(string empCode)
        {
            using (SqlConnection conn = new SqlConnection(path))
            {
                conn.Open();

                // Check if there is a record with the same EmpCode
                string query = "SELECT COUNT(*) FROM employee WHERE EmpCode = @EmpCode";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpCode", empCode);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = txtname.Text;
            designation = txtdesignation.Text;
            dateofjoining = DateTime.Parse(dateTimePicker1.Text);
            empcode = txtempcode.Text;
            string empCode = empcode.Trim();
            if (rbtnyes.Checked == true)
            {
                radio = true;
            }
            else if (rbtnno.Checked == true)
            {
                radio = false;
            }
            if (IsDuplicateEmpCode(empCode))
            {
                MessageBox.Show("You are entering a duplicate EmpCode.", "Duplicate EmpCode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pan = txtpan.Text;
            address = txtaddress.Text;

            if (txtctc.Text == "")
            {
                txtctc.Text = "0";
                totalctc = double.Parse(txtctc.Text);

            }
            else
            {
                totalctc = double.Parse(txtctc.Text);
            }
            if (txtbasic.Text == "")
            {
                txtbasic.Text = "0";
                basic = double.Parse(txtbasic.Text);

            }
            else
            {
                basic = double.Parse(txtbasic.Text);
            }

            if (txthra.Text == "")
            {
                txthra.Text = "0";
                hra = double.Parse(txthra.Text);
            }
            else
            {
                hra = double.Parse(txthra.Text);
            }

            if (txtta.Text == "")
            {
                txtta.Text = "0";
                ta = double.Parse(txtta.Text);
            }
            else
            {
                ta = double.Parse(txtta.Text);
            }
            if (txtotherallowance.Text == "")
            {
                txtotherallowance.Text = "0";
                other_allowance = double.Parse(txtotherallowance.Text);
            }
            else
            {
                other_allowance = double.Parse(txtotherallowance.Text);
            }
            if (txtmedicalallowance.Text == "")
            {
                txtmedicalallowance.Text = "0";
                medical_allowance = double.Parse(txtmedicalallowance.Text);
            }
            else
            {
                medical_allowance = double.Parse(txtmedicalallowance.Text);
            }

            if (txtremoteworkallowance.Text == "")
            {
                txtremoteworkallowance.Text = "0";
                remote_work_allowance = double.Parse(txtremoteworkallowance.Text);
            }
            else
            {
                remote_work_allowance = double.Parse(txtremoteworkallowance.Text);

            }
            if (txtbonus.Text == "")
            {
                txtbonus.Text = "0";
                bonus = double.Parse(txtbonus.Text);
            }
            else
            {
                bonus = double.Parse(txtbonus.Text);
            }
            if (txtpf.Text == "")
            {
                txtpf.Text = "0";
                pf = double.Parse(txtpf.Text);
            }
            else
            {
                pf = double.Parse(txtpf.Text);
            }
            if (txtesic.Text == "")
            {
                txtesic.Text = "0";
                esic = double.Parse(txtesic.Text);
            }
            else
            {
                esic = double.Parse(txtesic.Text);
            }
            if (txtloan.Text == "")
            {
                txtloan.Text = "0";
                loan = double.Parse(txtloan.Text);
            }
            else
            {
                loan = double.Parse(txtloan.Text);
            }
            if (txtadvance.Text == "")
            {
                txtadvance.Text = "0";
                advance = double.Parse(txtadvance.Text);
            }
            else
            {
                advance = double.Parse(txtadvance.Text);
            }
            if (txtother.Text == "")
            {
                txtother.Text = "0";
                other = double.Parse(txtother.Text);
            }
            else
            {
                other = double.Parse(txtother.Text);
            }

            if (txttds.Text == "")
            {
                txttds.Text = "0";
                tds = double.Parse(txttds.Text);
            }
            else
            {
                tds = double.Parse(txttds.Text);
            }
            if (txtearnings.Text == "")
            {
                txtearnings.Text = "0";
                TotalEarnings = double.Parse(txtearnings.Text);
            }
            else
            {
                TotalEarnings = double.Parse(txtearnings.Text);
            }
            if (txtdeductions.Text == "")
            {
                txtdeductions.Text = "0";
                Deductions = double.Parse(txtdeductions.Text);
            }
            else
            {
                Deductions = double.Parse(txtdeductions.Text);
            }
            if (txtnet.Text == "")
            {
                txtnet.Text = "0";
                NetPayable = double.Parse(txtnet.Text);
            }
            else
            {
                NetPayable = double.Parse(txtnet.Text);
            }
            if (name == "" || designation == "" || empcode == "" || pan == "")
            {
                MessageBox.Show("Please Fill in the blanks");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "exec InsertDetails @Basic, @HRA, @TA, @OtherAllowance, @MedicalAllowance, @RemoteWorkAllowance," +
                        "@Bonus, @PF, @ESIC, @Loan, @Other, @Advance,@TDS,@TotalCTC,@TotalEarnings,@TotalDeducations,@NetPayable,@Name,@Designation,@DateOfJoining,@EmpCode,@PAN,@Address,@Remote";

                    cmd = new SqlCommand(query, conn);

                    // Add parameters to the command

                    cmd.Parameters.AddWithValue("@Basic", basic);
                    cmd.Parameters.AddWithValue("@HRA", hra);
                    cmd.Parameters.AddWithValue("@TA", ta);
                    cmd.Parameters.AddWithValue("@OtherAllowance", other_allowance);
                    cmd.Parameters.AddWithValue("@MedicalAllowance", medical_allowance);
                    cmd.Parameters.AddWithValue("@RemoteWorkAllowance", remote_work_allowance);
                    cmd.Parameters.AddWithValue("@Bonus", bonus);
                    cmd.Parameters.AddWithValue("@PF", pf);
                    cmd.Parameters.AddWithValue("@ESIC", esic);
                    cmd.Parameters.AddWithValue("@Loan", loan);
                    cmd.Parameters.AddWithValue("@Other", other);
                    cmd.Parameters.AddWithValue("@Advance", advance);
                    cmd.Parameters.AddWithValue("@TDS", tds);
                    cmd.Parameters.AddWithValue("@TotalCTC", totalctc);
                    cmd.Parameters.AddWithValue("@TotalEarnings", TotalEarnings);
                    cmd.Parameters.AddWithValue("@TotalDeducations", Deductions);
                    cmd.Parameters.AddWithValue("@NetPayable", NetPayable);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Designation", designation);
                    cmd.Parameters.AddWithValue("@DateOfJoining", dateofjoining);
                    cmd.Parameters.AddWithValue("@EmpCode", empcode);
                    cmd.Parameters.AddWithValue("@PAN", pan);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Remote", radio);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Successfully Inserted");
                        Home home = new Home();
                        home.Refresh();
                        AllDisplay(); // Refresh the DataGridView

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
            }
            Home homeForm = Application.OpenForms["Home"] as Home;

            if (homeForm != null)
            {
                homeForm.RefreshDataGridView();
            }
            this.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtmedicalallowance.Text = "0";
                return;
            }
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }
            if (txtmedicalallowance.Text == null)
            {
                txtmedicalallowance.Text = "0";
            }
            medical_allowance = double.Parse(txtmedicalallowance.Text);

            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                adpt = new SqlDataAdapter("exec LoadAllEmpBySearch '" + txtsearch.Text + "'", conn);

                dt = new DataTable();
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtctc_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty

                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }

            totalctc = double.Parse(txtctc.Text);

            // Calculate monthly salary
            //monthlysalary = totalctc / 12;

            // txtearnings.Text = Math.Round(monthlysalary).ToString();



            txtbasic.Text = Math.Round((totalctc * 1.0 / 24)).ToString();
            basic = Math.Round((totalctc * 1.0 / 24), 2);


            txthra.Text = Math.Round(((basic * 2) / 5)).ToString();
            hra = Math.Round(((totalctc * 1.0) / 60), 2);

            txtmedicalallowance.Text = 1000.ToString();
            medical_allowance = double.Parse(txtmedicalallowance.Text);

            // Calculate remainingmonthlysalary as a decimal
            remainingmonthlysalary = (totalctc * (1.0 / 12)) - (totalctc * (1.0 / 24) + totalctc * (1.0 / 60) + 1000);


            if (remainingmonthlysalary < 0)
            {
                remainingmonthlysalary = 0;
            }

            // Calculate TA (Transport Allowance)
            ta = Math.Round(((remainingmonthlysalary * 2) / 5), 2);
            if (ta < 0)
            {
                ta = 0;
            }
            // Calculate other_allowance
            other_allowance = Math.Round(((remainingmonthlysalary * 3) / 5), 2);
            if (other_allowance < 0)
            {
                other_allowance = 0;
            }
            txtta.Text = ta.ToString();
            txtotherallowance.Text = other_allowance.ToString();


            monthlysalary = (basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);

            txtearnings.Text = Math.Round(monthlysalary).ToString();


            txtdeductions.Text = (Math.Round((pf + esic + loan + advance + other + tds))).ToString();
            double deduce = double.Parse(txtdeductions.Text);
            double monthdeduce = (monthlysalary - deduce);
            txtnet.Text = Math.Round(monthdeduce).ToString();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtempcode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtdesignation.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //dateTimePicker1.Text = (DateTime)(dataGridView1.Rows[e.RowIndex].Cells[3].Value);

            txtpan.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            radio2 = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (radio2 == "True")
            {
                rbtnyes.Checked = true;
            }
            else
            {
                rbtnno.Checked = true;
            }
            txtctc.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtbasic.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txthra.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtta.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtotherallowance.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtmedicalallowance.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtremoteworkallowance.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtbonus.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtpf.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            txtesic.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
            txtloan.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
            txtadvance.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtother.Text = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
            txttds.Text = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(path))
                {
                    connection.Open();
                    string designationupdate = txtdesignation.Text;
                    double basicupdate = double.Parse(txtbasic.Text);
                    double hraupdate = double.Parse(txthra.Text);
                    double taupdate = double.Parse(txtta.Text);
                    double otherallowanceupdate = double.Parse(txtotherallowance.Text);
                    double medicalallowanceupdate = double.Parse(txtmedicalallowance.Text);
                    double remoteworkallowanceupdate = double.Parse(txtremoteworkallowance.Text);
                    double bonusupdate = double.Parse(txtbonus.Text);
                    double pfupdate = double.Parse(txtpf.Text);
                    double esicupdate = double.Parse(txtesic.Text);
                    double loanupdate = double.Parse(txtloan.Text);
                    double advanceupdate = double.Parse(txtadvance.Text);
                    double otherupdate = double.Parse(txtother.Text);
                    double tdsupdate = double.Parse(txttds.Text);
                    double totalctcupdate = double.Parse(txtctc.Text);
                    double totalearningsupdate = double.Parse(txtearnings.Text);
                    double totaldeductionsupdate = double.Parse(txtdeductions.Text);
                    double totalnetpayableupdate = double.Parse(txtnet.Text);
                    string empcode = txtempcode.Text;

                    // Use a parameterized query to prevent SQL injection
                    string query = "exec UpdateEmp_Data @Designation,@Basic, @HRA, @TA, @OtherAllowance, @MedicalAllowance, @RemoteWorkAllowance, @Bonus, @PF, @ESIC, @Loan, @Advance, @Other, @TDS, @TotalCTC,@TotalEarnings,@TotalDeductions,@NetPayable,@Remote,@EmpCode";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Designation", designationupdate);

                        cmd.Parameters.AddWithValue("@Basic", basicupdate);
                        cmd.Parameters.AddWithValue("@HRA", hraupdate);
                        cmd.Parameters.AddWithValue("@TA", taupdate);
                        cmd.Parameters.AddWithValue("@OtherAllowance", otherallowanceupdate);
                        cmd.Parameters.AddWithValue("@MedicalAllowance", medicalallowanceupdate);
                        cmd.Parameters.AddWithValue("@RemoteWorkAllowance", remoteworkallowanceupdate);
                        cmd.Parameters.AddWithValue("@Bonus", bonusupdate);
                        cmd.Parameters.AddWithValue("@PF", pfupdate);
                        cmd.Parameters.AddWithValue("@ESIC", esicupdate);
                        cmd.Parameters.AddWithValue("@Loan", loanupdate);
                        cmd.Parameters.AddWithValue("@Advance", advanceupdate);
                        cmd.Parameters.AddWithValue("@Other", otherupdate);
                        cmd.Parameters.AddWithValue("@TDS", tdsupdate);
                        cmd.Parameters.AddWithValue("@TotalCTC", totalctcupdate);
                        cmd.Parameters.AddWithValue("@TotalEarnings", totalearningsupdate);
                        cmd.Parameters.AddWithValue("@TotalDeductions", totaldeductionsupdate);
                        cmd.Parameters.AddWithValue("@NetPayable", totalnetpayableupdate);
                        cmd.Parameters.AddWithValue("@Remote", radio);
                        cmd.Parameters.AddWithValue("@EmpCode", empcode);

                        cmd.ExecuteNonQuery(); // Execute the stored procedure
                    }

                    MessageBox.Show("Employee data updated successfully");
                    Home home = new Home();
                    home.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Home homeForm = Application.OpenForms["Home"] as Home;
            if (homeForm != null)
            {
                homeForm.RefreshDataGridView();
            }
         
            this.Close();
        }

        private void txtbasic_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtbasic.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }


            basic = double.Parse(txtbasic.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txthra_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txthra.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }

            hra = double.Parse(txthra.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txtremoteworkallowance_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtremoteworkallowance.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }

            remote_work_allowance = double.Parse(txtremoteworkallowance.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txtbonus_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtbonus.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }


            bonus = double.Parse(txtbonus.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txtpf_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtpf.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }


            pf = double.Parse(txtpf.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txtesic_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtesic.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }

            esic = double.Parse(txtesic.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txtloan_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtloan.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }

            loan = double.Parse(txtloan.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txtadvance_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtadvance.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }
            advance = double.Parse(txtadvance.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txtother_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtother.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }
            other = double.Parse(txtother.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txttds_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txttds.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }

            tds = double.Parse(txttds.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txtearnings_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtearnings.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void txtdeductions_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtdeductions.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure to delete?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(path))
                    {
                        connection.Open();


                        string empcode = txtempcode.Text;

                        // Use a parameterized query to prevent SQL injection
                        string query = "delete from employee where EmpCode=@EmpCode";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {

                            cmd.Parameters.AddWithValue("@EmpCode", empcode);

                            cmd.ExecuteNonQuery(); // Execute the stored procedure
                        }

                        MessageBox.Show("Employee data deleted successfully");
                        
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Home homeForm = Application.OpenForms["Home"] as Home;
                if (homeForm != null)
                {
                    homeForm.RefreshDataGridView();
                }
               
                this.Close();
            }

        }

        private void txtotherallowance_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtotherallowance.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }

            other_allowance = double.Parse(txtotherallowance.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void txtta_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                // Handle the case when input is empty
                txtta.Text = "0";
                return;
            }

            // Validate input using regular expression
            if (!Regex.IsMatch(input, @"^\d+(\.\d*)?$"))
            {
                // Display an error message or change border color
                textBox.Text = ""; // Clear invalid input
                textBox.BackColor = System.Drawing.Color.LightPink; // Example color
                MessageBox.Show("Please provide a valid numeric input");
                return;
            }
            else
            {
                // Reset border color if input is valid
                textBox.BackColor = System.Drawing.SystemColors.Window;
            }

            ta = double.Parse(txtta.Text);
            monthlysalary = Math.Round(basic + hra + ta + other_allowance + medical_allowance + remote_work_allowance + bonus);
            txtearnings.Text = monthlysalary.ToString();
            txtdeductions.Text = Math.Round((pf + esic + loan + advance + other + tds)).ToString();
            txtnet.Text = Math.Round((monthlysalary - (pf + esic + loan + advance + other + tds))).ToString();
        }

        private void rbtnyes_CheckedChanged(object sender, EventArgs e)
        {
            if (remainingmonthlysalary < 0)
            {
                remainingmonthlysalary = 0;
            }

            // Calculate TA (Transport Allowance)
            ta = Math.Round(((remainingmonthlysalary * 1.0) / 4), 2);
            if (ta < 0)
            {
                ta = 0;
            }
            // Calculate other_allowance
            other_allowance = Math.Round(((remainingmonthlysalary * 2.0) / 5), 2);
            if (other_allowance < 0)
            {
                other_allowance = 0;
            }
            remote_work_allowance = Math.Round(((remainingmonthlysalary * 7) / 20), 2);
            if (remote_work_allowance < 0)
            {
                remote_work_allowance = 0;
            }
            txtta.Text = ta.ToString();
            txtotherallowance.Text = other_allowance.ToString();
            txtremoteworkallowance.Text = remote_work_allowance.ToString();
        }

        private void rbtnno_CheckedChanged(object sender, EventArgs e)
        {
            if (remainingmonthlysalary < 0)
            {
                remainingmonthlysalary = 0;
            }

            // Calculate TA (Transport Allowance)
            ta = Math.Round(((remainingmonthlysalary * 2) / 5), 2);
            if (ta < 0)
            {
                ta = 0;
            }
            // Calculate other_allowance
            other_allowance = Math.Round(((remainingmonthlysalary * 3) / 5), 2);
            if (other_allowance < 0)
            {
                other_allowance = 0;
            }
            txtta.Text = ta.ToString();
            txtotherallowance.Text = other_allowance.ToString();
            txtremoteworkallowance.Text = "0";
        }
    }
}