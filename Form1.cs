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
            frmMain frm = new frmMain();
            frm.MdiParent = this;
            frm.Show();
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
    }
}
