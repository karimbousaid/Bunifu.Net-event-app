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
    public partial class SuccessDialog : Form
    {
        public SuccessDialog()
        {
            InitializeComponent();
        }
        string value;

 
        private void SuccessDialog_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            icon.Enabled = false;
            timer1.Stop();
        }

        private void bunifuFormFadeTransition1_TransitionEnd(object sender, EventArgs e)
        {
            timer1.Start();
            icon.Enabled = true;
            bunifuFlatButton1.Visible = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           
            Commande s = new Commande();
            s.ShowDialog();
            this.Hide();
        }

        private void icon_Click(object sender, EventArgs e)
        {

        }
    }
}
