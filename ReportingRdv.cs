using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTest
{
    public partial class ReportingRdv : Form
    {
        public ReportingRdv()
        {
            InitializeComponent();
        }
     
       
        int variable;
        public void Pass(int n1)
        {
            variable = n1;
        }
        private void ReportingRdv_Load(object sender, EventArgs e)
        {
            CrystalReport4 r = new CrystalReport4();
            r.SetParameterValue("idc",variable);
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }
    }
}
