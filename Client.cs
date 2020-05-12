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
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ProjectTest
{
    public partial class Client : Form
    {
       
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Client c = new Client();
            c.Show();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Nomtxt.Text = "";
            prenomtxt.Text = "";
            adresstxt.Text = "";
            tlftxt.Text = "";
          
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {    
            DialogResult dialogResult = MessageBox.Show("Tu veux le Passée l'etape suivant pour effectuée le Rendez-Vous!!", "étape Suivant", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {           
                this.Hide();
                RDV r = new RDV();            
                r.ShowDialog();              
            }
        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }
        public bool IsValid(string emailaddress)
        {
                try
                {
                if (emailaddress == "")
                {
                    label5.Text = "* champs obligatoire";
                }
                else
                {
                    MailAddress m = new MailAddress(emailaddress);
                }
                return true;
                }
                catch (FormatException)
                {
                    return false;
                }
        }
       
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {          
                try
                {
                if (Nomtxt.Text == string.Empty || prenomtxt.Text == string.Empty || adresstxt.Text == string.Empty || emailtxt.Text == string.Empty || eventtxt.Text== string.Empty)
                {
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label1.Text = "* champs obligatoire";
                    label2.Text = "* champs obligatoire";
                    label3.Text = "* champs obligatoire";
                    label4.Text = "* champs obligatoire";
                    label5.Text = "* champs obligatoire";
                    label6.Text = "* champs obligatoire";
                }             
               else
                {
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    string req1 = "INSERT INTO Client VALUES('" + Nomtxt.Text + "','" + prenomtxt.Text + "','" + adresstxt.Text + "'," + tlftxt.Text + ",'" + emailtxt.Text + "','" + eventtxt.Text + "')";
                    ClassConnection.Excute(req1);                    
                    SuccessDialog s = new SuccessDialog();
                    s.ShowDialog();                 
                }
                }
                catch
                {
                    MessageBox.Show("Ereur d'ajouter le client", "Ereur", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
            }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Nomtxt.Text = "";
            prenomtxt.Text = "";
            adresstxt.Text = "";
            tlftxt.Text = "";
            emailtxt.Text = "";
            eventtxt.Text = "";
            Nomtxt.Focus();
        }

        private void tlftxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
                label4.Visible = false;
            }
            else
            {
                e.Handled = true;
                label4.Text = "** Tu doit entré un Numero";
                label4.Visible = true;
            }
        }
        private void Nomtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                label1.Text = "** Tu doit entré un text";
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }
        }

        private void prenomtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                label2.Text = "** Tu doit entré un text";
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }

        private void adresstxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                label3.Text = "** Tu doit entré un text";
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
        }

        private void emailtxt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                label6.Text = "** Tu doit entré un text";
                label6.Visible = true;
            }
            else
            {
                label6.Visible = false;
            }
        }

        private void emailtxt_Leave(object sender, EventArgs e)
        {
            if (IsValid(emailtxt.Text) == false)
            {
                label5.Visible = true;
                label5.Text = "Email doit contient caractére '@'";
            }
            else
            {
                label5.Visible = false;
                label5.Text = "";
            }
        }

        private void eventtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                label6.Text = "** Tu doit entré un text";
                label6.Visible = true;
            }
            else
            {
                label6.Visible = false;
            }
        }
    }
}
