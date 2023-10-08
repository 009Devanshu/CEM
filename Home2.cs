using iText.Kernel.Pdf;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using iText.Forms.Fields;
using iText.Forms;
using iText.Layout;
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
using System.Xml.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using System.Linq.Expressions;

namespace CEM
{
    public partial class Home2 : DevExpress.XtraEditors.XtraForm
    {
        //For sliding datagrid
        private bool isDragging = false;
        private int initialMouseY;
        private int initialScrollValue;
        /*---------------------*/


        public string EmpName;

        public string Designation;
        public DateTime DateOfJoining;
        public string EmpCode;
        public string Pan;
        public string EmpAddress;
        public string EmpBasic;
        public string EmpHra;
        public string EmpTA;
        public string OtherAllowance;
        public string MedicalAllowance;
        public string RemoteWorkAllowance;
        public string TotalCTC;
        public string Bonus;
        public string PF;
        public string ESIC;
        public string Loan;
        public string Advance;
        public string Other;
        public string TDS;
        public string TotalEarnings;
        public string TotalDeductions;
        public string NetPayable;
        //string Path2 = "Data Source=Devanshu\\MSSQLSERVER01;Initial Catalog=Emp_Data;User ID=user;Password=7935";
        public string EmployeeName;
        public static string s;
        string path = System.Configuration.ConfigurationManager.
    ConnectionStrings["mydb"].ConnectionString;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        System.Data.DataTable dt;
        public Home2()
        {
            InitializeComponent();
            conn = new SqlConnection(path);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainForm2 mainForm = new MainForm2();
            mainForm.Show();
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
                /*
                 Hiding Some columns of datagrid
                */
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[23].Visible = false;
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
                adpt = new SqlDataAdapter("exec LoadAllEmp", conn);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;

                /*
                Hiding Some columns of datagrid
               */
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[16].Visible = false;
                dataGridView1.Columns[17].Visible = false;
                dataGridView1.Columns[18].Visible = false;
                dataGridView1.Columns[19].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[23].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Home2_Load(object sender, EventArgs e)
        {
            AllDisplay();

            dataGridView1.Columns[0].Width = 320;
            dataGridView1.Columns[1].Width = 320;
            dataGridView1.Columns[2].Width = 320;
            dataGridView1.Columns[3].Width = 320;
            //dataGridView1.Columns[4].Width = 300;
            dataGridView1.Columns[5].Width = 320;
            dataGridView1.Columns[6].Width = 320;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                adpt = new SqlDataAdapter("exec Search_DB '" + btnsearch2.Text + "'", conn);

                dt = new DataTable();
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 320;
                dataGridView1.Columns[1].Width = 320;
                dataGridView1.Columns[2].Width = 320;
                dataGridView1.Columns[3].Width = 320;
                dataGridView1.Columns[4].Width = 320;
                dataGridView1.Columns[5].Width = 320;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EmpName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                EmpCode = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Designation = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                DateOfJoining = (DateTime)(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                Pan = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                EmpAddress = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                TotalCTC = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                EmpBasic = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                EmpHra = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                EmpTA = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                OtherAllowance = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                MedicalAllowance = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                RemoteWorkAllowance = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                Bonus = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                PF = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
                ESIC = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
                Loan = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
                Advance = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
                Other = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
                TDS = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();

                TotalEarnings = dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString();
                TotalDeductions = dataGridView1.Rows[e.RowIndex].Cells[22].Value.ToString();
                NetPayable = dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString();
            }
        }

        private void barButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OtherDetails otherDetails = new OtherDetails();
            otherDetails.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Employee_Update_Form employee_Update_Form = new Employee_Update_Form();
            employee_Update_Form.Show();
        }
    }
}