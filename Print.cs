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

namespace CEM
{
    public partial class Print : DevExpress.XtraEditors.XtraForm
    {
        public Print()
        {
            InitializeComponent();
        }
        public void PrintInvoice(string your_company,string client_name, string your_gst, string your_lut, string your_cin,string your_email,  string ClientCompany, string ClientAddress, 
            string ClientGST, double amount,string cgst, string sgst, string igst,string CGSTText,string SGSTText,string IGSTText,string AccountName,string AccountNumber,string IFSC,string SWIFT,string BankName,string BankAddress)
        {
            InvoiceReport report = new InvoiceReport();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
                p.Visible = false;
            report.InitData(your_company,client_name,your_gst,your_lut,your_cin,your_email,ClientCompany,ClientAddress,ClientGST,amount,cgst,sgst,igst,CGSTText,SGSTText,IGSTText,AccountName,AccountNumber,IFSC,SWIFT,BankName,BankAddress);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        private void Print_Load(object sender, EventArgs e)
        {

        }
    }
}