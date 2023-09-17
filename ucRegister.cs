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
    public partial class ucRegister : DevExpress.XtraEditors.XtraUserControl
    {
        private static ucRegister _instance;

        public static ucRegister Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucRegister();
                return _instance;
            }
        }
        public ucRegister()
        {
            InitializeComponent();
        }

        private void ucRegister_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
