using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ProjectTest
{
    public partial class RDV : Form
    {
        public RDV()
        {
            InitializeComponent();
        }
       private int id_c;

        public int Id_c { get => id_c; set => id_c = value; }

        public void Pass(int idc)
        {
            this.id_c = idc;
        }
        private void RDV_Load(object sender, EventArgs e)
        {
            bunifuImageButton2.Visible = false;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string req = "insert into RDV values('" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "'," + this.id_c + ")";
                ClassConnection.Excute(req);
                MessageBox.Show("le Rendez_vous effectuer a cette commande", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Problem d'ajouté le Rendez_vous", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            string req = "select * from RDV where dateDRV='" + dateTimePicker1.Value + "' and HeurRDV='" + dateTimePicker2.Value + "'";
            SqlDataReader dr3 = ClassConnection.FillDataReader(req);
            if(dr3.Read())
            {              
                MessageBox.Show("le Rendez_vous exist chois un autre Rendez_vous", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dr3.Close();
                MessageBox.Show("aucan Rendez_vous effectuer a cette commande", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bunifuImageButton2.Visible = true;
            }
           
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            ReportingRdv r = new ReportingRdv();
            r.Pass(id_c);
            r.ShowDialog();
        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {
           
            
        }
    }
}
