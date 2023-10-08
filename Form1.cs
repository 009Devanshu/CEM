using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CEM
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Company_Details company_Details = new Company_Details();
            company_Details.MdiParent = this;
            company_Details.Show();

            /* frmMain frm = new frmMain();
             frm.MdiParent = this;
             frm.Show();*/
           /* if (!container.Controls.Contains(ucRegister.Instance))
            {
                container.Controls.Add(ucRegister.Instance);
                ucRegister.Instance.Dock = DockStyle.Fill;
                ucRegister.Instance.BringToFront();
            }
            ucRegister.Instance.BringToFront();*/
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain2 frm = new frmMain2();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Demo Loading Data
            for(int i = 0; i < 100; i++)
            {
                Thread.Sleep(30);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClientDetails Client_Details = new ClientDetails();
            Client_Details.MdiParent = this;
            Client_Details.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InvoiceDetails Invoice_Details = new InvoiceDetails();
            Invoice_Details.MdiParent = this;
            Invoice_Details.Show();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Home home = new Home();
            home.MdiParent = this;
            home.Show();
        }

        private void barButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem4_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainForm home = new MainForm();
            
            home.Show();
        }
    }
}
