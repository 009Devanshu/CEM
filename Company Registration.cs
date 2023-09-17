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
    public partial class Company_Registration : DevExpress.XtraEditors.XtraForm
    {
        private static Company_Registration _instance;
        public Company_Registration()
        {
            InitializeComponent();
        }
        public static Company_Registration Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Company_Registration();
                return _instance;
            }
        }
        private void textEdit17_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit15_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}