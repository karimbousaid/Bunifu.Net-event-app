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
    public partial class PlatAndMaterial : Form
    {
        public PlatAndMaterial()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            CommandeForm f = new CommandeForm();
            f.ShowDialog();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Material m = new Material();
            m.ShowDialog();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
