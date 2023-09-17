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
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(ucRegister.Instance))
            {
                container.Controls.Add(ucRegister.Instance);
                ucRegister.Instance.Dock = DockStyle.Fill;
                ucRegister.Instance.BringToFront();
            }
            ucRegister.Instance.BringToFront();
           /* Company_Registration company_Registration = new Company_Registration();
            company_Registration.Show();*/
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void aceDetails_Click(object sender, EventArgs e)
        {
            if (!container.Controls.Contains(ucDetails.Instance))
            {
                container.Controls.Add(ucDetails.Instance);
                ucDetails.Instance.Dock = DockStyle.Fill;
                ucDetails.Instance.BringToFront();
            }
            ucDetails.Instance.BringToFront();
        }

        private void container_Click(object sender, EventArgs e)
        {

        }
    }
}